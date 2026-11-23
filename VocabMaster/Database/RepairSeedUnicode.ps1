param(
    [Parameter(Mandatory = $true)]
    [string] $ConnectionString,

    [string] $BackupPath = (Join-Path $PSScriptRoot ('UnicodeSeedBackup-' + (Get-Date -Format 'yyyyMMdd-HHmmss') + '.json'))
)

$ErrorActionPreference = 'Stop'

$seedPath = Join-Path $PSScriptRoot 'SQLSchemaData.sql'
$seedSql = Get-Content -LiteralPath $seedPath -Raw -Encoding UTF8
$pattern = "(?m)^\(N'(?<english>[^']+)',\s*N'(?<ipa>[^']*)',\s*N'(?<vietnamese>[^']*)',\s*N'[^']+',\s*[01],\s*@\w+\)[,;]"
$seedRows = [regex]::Matches($seedSql, $pattern)
if ($seedRows.Count -ne 42) {
    throw "Expected 42 seed words, found $($seedRows.Count). No data was changed."
}

Add-Type -AssemblyName System.Data
$connection = [System.Data.SqlClient.SqlConnection]::new($ConnectionString)
try {
    $connection.Open()
    $select = $connection.CreateCommand()
    $select.CommandText = 'SELECT IdTuVung, TiengAnh, TiengViet, PhienAm FROM dbo.TuVung WHERE IdTuVung BETWEEN 1 AND 42 ORDER BY IdTuVung'
    $reader = $select.ExecuteReader()
    $currentRows = @()
    while ($reader.Read()) {
        $currentRows += [pscustomobject]@{
            IdTuVung = $reader.GetInt32(0)
            TiengAnh = $reader.GetString(1)
            TiengViet = $reader.GetString(2)
            PhienAm = if ($reader.IsDBNull(3)) { $null } else { $reader.GetString(3) }
        }
    }
    $reader.Close()

    if ($currentRows.Count -ne 42) {
        throw "Expected 42 original seed rows, found $($currentRows.Count). No data was changed."
    }
    for ($i = 0; $i -lt 42; $i++) {
        if ($currentRows[$i].IdTuVung -ne $i + 1 -or
            $currentRows[$i].TiengAnh -cne $seedRows[$i].Groups['english'].Value) {
            throw "Seed row $($i + 1) does not match the database. No data was changed."
        }
    }

    $damagedRows = @($currentRows | Where-Object {
        $_.TiengViet.Contains('?') -or ($null -ne $_.PhienAm -and $_.PhienAm.Contains('?'))
    })
    if ($damagedRows.Count -eq 0) {
        Write-Output 'No damaged seed words found.'
        return
    }

    $backupDirectory = Split-Path -Parent $BackupPath
    if ($backupDirectory -and -not (Test-Path -LiteralPath $backupDirectory)) {
        New-Item -ItemType Directory -Path $backupDirectory | Out-Null
    }
    $currentRows | ConvertTo-Json -Depth 3 | Set-Content -LiteralPath $BackupPath -Encoding UTF8

    $transaction = $connection.BeginTransaction()
    try {
        $update = $connection.CreateCommand()
        $update.Transaction = $transaction
        $update.Parameters.Add('@Vietnamese', [System.Data.SqlDbType]::NVarChar, 255) | Out-Null
        $update.Parameters.Add('@Ipa', [System.Data.SqlDbType]::NVarChar, 100) | Out-Null
        $update.Parameters.Add('@Id', [System.Data.SqlDbType]::Int) | Out-Null
        $update.Parameters.Add('@English', [System.Data.SqlDbType]::NVarChar, 100) | Out-Null
        $update.Parameters.Add('@OriginalVietnamese', [System.Data.SqlDbType]::NVarChar, 255) | Out-Null
        $update.Parameters.Add('@OriginalIpa', [System.Data.SqlDbType]::NVarChar, 100) | Out-Null

        # Compare the exact snapshot, including case, accents, trailing spaces and NULL.
        $snapshotCondition = @'
 WHERE IdTuVung = @Id
 AND DATALENGTH(TiengAnh) = DATALENGTH(@English)
 AND CONVERT(varbinary(max), TiengAnh) = CONVERT(varbinary(max), @English)
 AND ((TiengViet IS NULL AND @OriginalVietnamese IS NULL) OR
      (DATALENGTH(TiengViet) = DATALENGTH(@OriginalVietnamese)
       AND CONVERT(varbinary(max), TiengViet) = CONVERT(varbinary(max), @OriginalVietnamese)))
 AND ((PhienAm IS NULL AND @OriginalIpa IS NULL) OR
      (DATALENGTH(PhienAm) = DATALENGTH(@OriginalIpa)
       AND CONVERT(varbinary(max), PhienAm) = CONVERT(varbinary(max), @OriginalIpa)))
'@

        foreach ($row in $damagedRows) {
            $seed = $seedRows[$row.IdTuVung - 1]
            $assignments = @()
            if ($row.TiengViet.Contains('?')) { $assignments += 'TiengViet = @Vietnamese' }
            if ($null -ne $row.PhienAm -and $row.PhienAm.Contains('?')) { $assignments += 'PhienAm = @Ipa' }
            $update.CommandText = 'UPDATE dbo.TuVung SET ' + ($assignments -join ', ') + $snapshotCondition
            $update.Parameters['@Vietnamese'].Value = $seed.Groups['vietnamese'].Value
            $update.Parameters['@Ipa'].Value = $seed.Groups['ipa'].Value
            $update.Parameters['@Id'].Value = $row.IdTuVung
            $update.Parameters['@English'].Value = $row.TiengAnh
            $update.Parameters['@OriginalVietnamese'].Value = $row.TiengViet
            $update.Parameters['@OriginalIpa'].Value = if ($null -eq $row.PhienAm) { [DBNull]::Value } else { $row.PhienAm }
            if ($update.ExecuteNonQuery() -ne 1) {
                throw "Could not update seed row $($row.IdTuVung)."
            }
        }
        $transaction.Commit()
    }
    catch {
        $transaction.Rollback()
        throw
    }

    Write-Output "Repaired $($damagedRows.Count) seed words. Backup: $BackupPath"
}
finally {
    $connection.Dispose()
}
