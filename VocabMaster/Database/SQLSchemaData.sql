USE VocabMasterDB;
GO
-- Vui lòng cập nhật biến _chuoiKetNoi trong file DatabaseHelper.cs cho đúng SQL Server instance.

-- 1) Xóa bảng cũ (nếu có)
IF OBJECT_ID(N'dbo.TuVungKho', N'U') IS NOT NULL DROP TABLE dbo.TuVungKho;
IF OBJECT_ID(N'dbo.LichSuHocTap', N'U') IS NOT NULL DROP TABLE dbo.LichSuHocTap;
IF OBJECT_ID(N'dbo.TuVung', N'U') IS NOT NULL DROP TABLE dbo.TuVung;
IF OBJECT_ID(N'dbo.ChuDe', N'U') IS NOT NULL DROP TABLE dbo.ChuDe;
GO

-- 2) Tạo bảng
CREATE TABLE dbo.ChuDe
(
    IdChuDe INT IDENTITY(1,1) PRIMARY KEY,
    TenChuDe NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE dbo.TuVung
(
    IdTuVung INT IDENTITY(1,1) PRIMARY KEY,
    TiengAnh NVARCHAR(100) NOT NULL,
    PhienAm NVARCHAR(100) NULL,
    TiengViet NVARCHAR(255) NOT NULL,
    LoaiTu NVARCHAR(50) NULL,
    DaThuoc BIT NOT NULL CONSTRAINT DF_TuVung_DaThuoc DEFAULT (0),
    IdChuDe INT NULL,
    CONSTRAINT FK_TuVung_ChuDe
        FOREIGN KEY (IdChuDe) REFERENCES dbo.ChuDe(IdChuDe)
);
GO

CREATE TABLE dbo.TuVungKho
(
    IdTuVung INT PRIMARY KEY,
    SoLanSai INT NOT NULL CONSTRAINT DF_TuVungKho_SoLanSai DEFAULT (0),
    NgaySaiCuoiCung DATETIME NOT NULL CONSTRAINT DF_TuVungKho_NgaySai DEFAULT (GETDATE()),
    CONSTRAINT FK_TuVungKho_TuVung
        FOREIGN KEY (IdTuVung) REFERENCES dbo.TuVung(IdTuVung) ON DELETE CASCADE
);
GO

CREATE TABLE dbo.LichSuHocTap
(
    IdLichSu INT IDENTITY(1,1) PRIMARY KEY,
    NgayHoc DATETIME NOT NULL CONSTRAINT DF_LichSuHocTap_NgayHoc DEFAULT (GETDATE()),
    SoCauDung INT NOT NULL,
    TongSoCau INT NOT NULL,
    -- Quan trọng: code hiện tại chỉ INSERT (SoCauDung, TongSoCau)
    -- nên TiLePhanTram để computed column cho khớp ứng dụng
    TiLePhanTram AS (
        CASE 
            WHEN TongSoCau = 0 THEN 0
            ELSE (CAST(SoCauDung AS FLOAT) / CAST(TongSoCau AS FLOAT)) * 100
        END
    )
);
GO

-- 3) Seed chủ đề
INSERT INTO dbo.ChuDe (TenChuDe) VALUES
(N'Technology'),
(N'Business'),
(N'Food'),
(N'Travel'),
(N'Education'),
(N'Health'),
(N'Daily Life'),
(N'Chưa phân loại');
GO

DECLARE @Technology INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Technology');
DECLARE @Business   INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Business');
DECLARE @Food       INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Food');
DECLARE @Travel     INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Travel');
DECLARE @Education  INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Education');
DECLARE @Health     INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Health');
DECLARE @DailyLife  INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Daily Life');
DECLARE @Uncat      INT = (SELECT IdChuDe FROM dbo.ChuDe WHERE TenChuDe = N'Chưa phân loại');

-- 4) Seed từ vựng
INSERT INTO dbo.TuVung (TiengAnh, PhienAm, TiengViet, LoaiTu, DaThuoc, IdChuDe) VALUES
(N'Algorithm',       N'/ˈælɡərɪðəm/', N'Thuật toán',             N'noun', 1, @Technology),
(N'Database',        N'/ˈdeɪtəbeɪs/', N'Cơ sở dữ liệu',          N'noun', 1, @Technology),
(N'Framework',       N'/ˈfreɪmwɜːk/', N'Khung phát triển',       N'noun', 0, @Technology),
(N'Debug',           N'/diːˈbʌɡ/',    N'Gỡ lỗi',                 N'verb', 0, @Technology),
(N'Feature',         N'/ˈfiːtʃər/',   N'Tính năng',              N'noun', 1, @Technology),
(N'Security',        N'/sɪˈkjʊərəti/',N'Bảo mật',                N'noun', 0, @Technology),

(N'Proposal',        N'/prəˈpəʊzl/',  N'Bản đề xuất',            N'noun', 1, @Business),
(N'Revenue',         N'/ˈrevənjuː/',  N'Doanh thu',              N'noun', 0, @Business),
(N'Budget',          N'/ˈbʌdʒɪt/',    N'Ngân sách',              N'noun', 1, @Business),
(N'Negotiate',       N'/nɪˈɡəʊʃieɪt/',N'Đàm phán',               N'verb', 0, @Business),
(N'Client',          N'/ˈklaɪənt/',   N'Khách hàng',             N'noun', 1, @Business),
(N'Contract',        N'/ˈkɒntrækt/',  N'Hợp đồng',               N'noun', 0, @Business),

(N'Beverage',        N'/ˈbevərɪdʒ/',  N'Đồ uống',                N'noun', 1, @Food),
(N'Recipe',          N'/ˈresəpi/',    N'Công thức',              N'noun', 0, @Food),
(N'Ingredient',      N'/ɪnˈɡriːdiənt/',N'Nguyên liệu',           N'noun', 1, @Food),
(N'Flavor',          N'/ˈfleɪvər/',   N'Hương vị',               N'noun', 0, @Food),
(N'Boil',            N'/bɔɪl/',       N'Luộc',                   N'verb', 0, @Food),
(N'Grill',           N'/ɡrɪl/',       N'Nướng',                  N'verb', 1, @Food),

(N'Itinerary',       N'/aɪˈtɪnərəri/',N'Lịch trình',             N'noun', 1, @Travel),
(N'Passport',        N'/ˈpɑːspɔːrt/', N'Hộ chiếu',               N'noun', 1, @Travel),
(N'Luggage',         N'/ˈlʌɡɪdʒ/',    N'Hành lý',                N'noun', 0, @Travel),
(N'Departure',       N'/dɪˈpɑːrtʃər/',N'Khởi hành',              N'noun', 0, @Travel),
(N'Destination',     N'/ˌdestɪˈneɪʃn/',N'Điểm đến',             N'noun', 1, @Travel),
(N'Accommodation',   N'/əˌkɒməˈdeɪʃn/',N'Chỗ ở',                N'noun', 0, @Travel),

(N'Syllabus',        N'/ˈsɪləbəs/',   N'Đề cương',               N'noun', 0, @Education),
(N'Assignment',      N'/əˈsaɪnmənt/', N'Bài tập',                N'noun', 1, @Education),
(N'Evaluate',        N'/ɪˈvæljueɪt/', N'Đánh giá',               N'verb', 0, @Education),
(N'Scholarship',     N'/ˈskɒlərʃɪp/', N'Học bổng',               N'noun', 1, @Education),
(N'Curriculum',      N'/kəˈrɪkjələm/',N'Chương trình học',       N'noun', 0, @Education),
(N'Lecture',         N'/ˈlektʃər/',   N'Bài giảng',              N'noun', 1, @Education),

(N'Exercise',        N'/ˈeksərsaɪz/', N'Tập thể dục',            N'noun', 1, @Health),
(N'Nutrition',       N'/nuˈtrɪʃn/',   N'Dinh dưỡng',             N'noun', 0, @Health),
(N'Vaccine',         N'/ˈvæksiːn/',   N'Vắc-xin',                N'noun', 1, @Health),
(N'Symptom',         N'/ˈsɪmptəm/',   N'Triệu chứng',            N'noun', 0, @Health),
(N'Treatment',       N'/ˈtriːtmənt/', N'Điều trị',               N'noun', 0, @Health),
(N'Recovery',        N'/rɪˈkʌvəri/',  N'Hồi phục',               N'noun', 1, @Health),

(N'Routine',         N'/ruːˈtiːn/',   N'Thói quen',              N'noun', 1, @DailyLife),
(N'Chore',           N'/tʃɔːr/',      N'Việc vặt',               N'noun', 0, @DailyLife),
(N'Appointment',     N'/əˈpɔɪntmənt/',N'Cuộc hẹn',              N'noun', 1, @DailyLife),
(N'Neighbor',        N'/ˈneɪbər/',    N'Hàng xóm',               N'noun', 0, @DailyLife),

(N'Ambiguous',       N'/æmˈbɪɡjuəs/', N'Mơ hồ',                  N'adjective', 0, @Uncat),
(N'Outcome',         N'/ˈaʊtkʌm/',    N'Kết quả',                N'noun', 1, @Uncat);
GO

-- 5) Seed từ vựng khó
INSERT INTO dbo.TuVungKho (IdTuVung, SoLanSai, NgaySaiCuoiCung)
SELECT IdTuVung, SoLanSai, NgaySaiCuoiCung
FROM
(
    SELECT N'Implement' AS WordKey, 14 AS SoLanSai, DATEADD(DAY, -1, GETDATE()) AS NgaySaiCuoiCung
    UNION ALL SELECT N'Revenue', 11, DATEADD(DAY, -2, GETDATE())
    UNION ALL SELECT N'Recipe',  9, DATEADD(DAY, -1, GETDATE())
    UNION ALL SELECT N'Evaluate', 8, DATEADD(DAY, -3, GETDATE())
    UNION ALL SELECT N'Ambiguous', 13, GETDATE()
    UNION ALL SELECT N'Framework', 7, DATEADD(DAY, -4, GETDATE())
    UNION ALL SELECT N'Nutrition', 6, DATEADD(DAY, -2, GETDATE())
) s
JOIN dbo.TuVung t ON t.TiengAnh = s.WordKey;
GO

-- 6) Seed lịch sử học tập
INSERT INTO dbo.LichSuHocTap (NgayHoc, SoCauDung, TongSoCau) VALUES
(DATEADD(DAY, -12, GETDATE()), 4, 10),
(DATEADD(DAY, -11, GETDATE()), 5, 10),
(DATEADD(DAY, -10, GETDATE()), 6, 10),
(DATEADD(DAY, -9,  GETDATE()), 7, 10),
(DATEADD(DAY, -8,  GETDATE()), 5, 10),
(DATEADD(DAY, -7,  GETDATE()), 8, 10),
(DATEADD(DAY, -6,  GETDATE()), 6, 10),
(DATEADD(DAY, -5,  GETDATE()), 7, 10),
(DATEADD(DAY, -4,  GETDATE()), 8, 10),
(DATEADD(DAY, -3,  GETDATE()), 9, 10),
(DATEADD(DAY, -2,  GETDATE()), 7, 10),
(DATEADD(DAY, -1,  GETDATE()), 8, 10),
(GETDATE(),                        9, 10);
GO

-- 7) Kiểm tra nhanh
SELECT COUNT(*) AS TongChuDe FROM dbo.ChuDe;
SELECT COUNT(*) AS TongTuVung FROM dbo.TuVung;
SELECT COUNT(*) AS TongTuKho  FROM dbo.TuVungKho;
SELECT TOP 7 NgayHoc, SoCauDung, TongSoCau, TiLePhanTram
FROM dbo.LichSuHocTap
ORDER BY NgayHoc DESC;
GO