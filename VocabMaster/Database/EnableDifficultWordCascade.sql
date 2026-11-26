SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @ChildTable int = OBJECT_ID(N'dbo.TuVungKho', N'U');
    DECLARE @ParentTable int = OBJECT_ID(N'dbo.TuVung', N'U');

    IF @ChildTable IS NULL OR @ParentTable IS NULL
        THROW 50001, 'Select a VocabMaster database with TuVung and TuVungKho before running this script.', 1;

    DECLARE @ForeignKeyName sysname;
    DECLARE @DeleteAction tinyint;
    DECLARE @IsDisabled bit;
    DECLARE @IsNotTrusted bit;

    SELECT
        @ForeignKeyName = fk.name,
        @DeleteAction = fk.delete_referential_action,
        @IsDisabled = fk.is_disabled,
        @IsNotTrusted = fk.is_not_trusted
    FROM sys.foreign_keys AS fk
    INNER JOIN sys.foreign_key_columns AS fkc ON fkc.constraint_object_id = fk.object_id
    WHERE fk.parent_object_id = @ChildTable
        AND fk.referenced_object_id = @ParentTable
        AND COL_NAME(@ChildTable, fkc.parent_column_id) = N'IdTuVung'
        AND COL_NAME(@ParentTable, fkc.referenced_column_id) = N'IdTuVung'
        AND NOT EXISTS (
            SELECT 1
            FROM sys.foreign_key_columns AS other_column
            WHERE other_column.constraint_object_id = fk.object_id
                AND other_column.constraint_column_id > 1
        );

    IF @@ROWCOUNT <> 1
        THROW 50002, 'Expected exactly one foreign key from TuVungKho.IdTuVung to TuVung.IdTuVung.', 1;

    IF @DeleteAction <> 1
    BEGIN
        DECLARE @QuotedName nvarchar(258) = QUOTENAME(@ForeignKeyName);
        DECLARE @Sql nvarchar(max) =
            N'ALTER TABLE dbo.TuVungKho DROP CONSTRAINT ' + @QuotedName + N';
              ALTER TABLE dbo.TuVungKho WITH CHECK ADD CONSTRAINT ' + @QuotedName + N'
                  FOREIGN KEY (IdTuVung) REFERENCES dbo.TuVung (IdTuVung) ON DELETE CASCADE;';
        EXEC sys.sp_executesql @Sql;
    END
    ELSE IF @IsDisabled = 1 OR @IsNotTrusted = 1
    BEGIN
        DECLARE @ValidateSql nvarchar(max) =
            N'ALTER TABLE dbo.TuVungKho WITH CHECK CHECK CONSTRAINT ' + QUOTENAME(@ForeignKeyName) + N';';
        EXEC sys.sp_executesql @ValidateSql;
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
