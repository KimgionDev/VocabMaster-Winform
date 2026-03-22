USE VocabMasterDB;
GO

-- 1. XÓA DỮ LIỆU CŨ 
-- Phải xóa bảng con trước, bảng cha sau để tránh lỗi khóa ngoại
DELETE FROM TuVungKho;
DELETE FROM TuVung;
DELETE FROM ChuDe;
DELETE FROM LichSuHocTap;

-- Reset bộ đếm ID về 0
DBCC CHECKIDENT ('TuVung', RESEED, 0);
DBCC CHECKIDENT ('ChuDe', RESEED, 0);
DBCC CHECKIDENT ('LichSuHocTap', RESEED, 0);
GO

-- 2. THÊM DỮ LIỆU GIẢ ĐỊNH
-- Thêm Chủ đề
INSERT INTO ChuDe (TenChuDe) VALUES 
(N'Technology'), (N'Business'), (N'Food'), (N'Travel'), (N'Education'), (N'Chưa phân loại');

-- Thêm Từ vựng (DaThuoc: 1 là thuộc, 0 là chưa)
INSERT INTO TuVung (TiengAnh, PhienAm, TiengViet, LoaiTu, DaThuoc, IdChuDe) VALUES
('Algorithm', '/ˈælɡərɪðəm/', N'Thuật toán', 'noun', 1, 1),
('Database', '/ˈdeɪtəbeɪs/', N'Cơ sở dữ liệu', 'noun', 1, 1),
('Implement', '/ˈɪmplɪmənt/', N'Thực hiện', 'verb', 0, 1),
('Proposal', '/prəˈpəʊzl/', N'Bản đề xuất', 'noun', 1, 2),
('Revenue', '/ˈrevənjuː/', N'Doanh thu', 'noun', 0, 2),
('Beverage', '/ˈbevərɪdʒ/', N'Đồ uống', 'noun', 1, 3),
('Recipe', '/ˈresəpi/', N'Công thức', 'noun', 0, 3),
('Itinerary', '/aɪˈtɪnərəri/', N'Lịch trình', 'noun', 1, 4),
('Evaluate', '/ɪˈvæljueɪt/', N'Đánh giá', 'verb', 0, 5),
('Syllabus', '/ˈsɪləbəs/', N'Đề cương', 'noun', 0, 5),
('Ambiguous', '/æmˈbɪɡjuəs/', N'Mơ hồ', 'adj', 0, 6);

-- Thêm Từ vựng khó (Tham chiếu ID từ bảng TuVung vừa tạo ở trên)
INSERT INTO TuVungKho (IdTuVung, SoLanSai, NgaySaiCuoiCung) VALUES
(3, 12, GETDATE() - 1),  -- Implement
(5, 8, GETDATE() - 2),   -- Revenue
(7, 15, GETDATE() - 1),  -- Recipe
(9, 5, GETDATE() - 3),   -- Evaluate
(11, 26, GETDATE());     -- Ambiguous

-- Thêm Lịch sử học tập (Lùi ngày để vẽ biểu đồ đường Line Chart)
INSERT INTO LichSuHocTap (NgayHoc, SoCauDung, TongSoCau) VALUES
(GETDATE() - 6, 4, 10),
(GETDATE() - 5, 5, 10),
(GETDATE() - 4, 8, 10),
(GETDATE() - 3, 5, 10),
(GETDATE() - 2, 8, 10),
(GETDATE() - 1, 7, 10),
(GETDATE(), 9, 10);
GO