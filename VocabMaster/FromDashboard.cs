using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormDashboard : Form
    {
        private DatabaseHelper _db = new DatabaseHelper();

        #region Khởi tạo & Form Load
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FromDashboard_Load(object sender, EventArgs e)
        {
            LoadOverview();
            LoadPieChart();
            LoadLineChart();
            LoadTopTuKho();
        }
        #endregion

        #region 1. Tổng quan (Overview)
        private void LoadOverview()
        {
            // Lấy tổng số từ
            DataTable dtTong = _db.LayDuLieu("SELECT COUNT(*) FROM TuVung");
            int tongTu = Convert.ToInt32(dtTong.Rows[0][0]);
            lblTongSoTu.Text = tongTu.ToString();

            // Lấy số từ đã thuộc
            DataTable dtDaThuoc = _db.LayDuLieu("SELECT COUNT(*) FROM TuVung WHERE DaThuoc = 1");
            int daThuoc = Convert.ToInt32(dtDaThuoc.Rows[0][0]);
            lblSoTuDaThuoc.Text = daThuoc.ToString();

            // Tính % tiến độ
            if (tongTu > 0)
            {
                double phanTram = (double)daThuoc / tongTu * 100;
                lblPhanTramThuoc.Text = $"+{Math.Round(phanTram, 1)}% tổng";
                lblTienDo.Text = $"{Math.Round(phanTram, 1)}%";

                // Cập nhật: Trả về giá trị từ 0 đến 1 cho AntdUI Progress
                prgTienDo.Value = (float)daThuoc / tongTu;
            }

            // Lấy điểm trung bình
            DataTable dtDiem = _db.LayDuLieu("SELECT ISNULL(AVG(TiLePhanTram), 0) FROM LichSuHocTap");
            double diemTB = Convert.ToDouble(dtDiem.Rows[0][0]);
            lblDiemTrungBinh.Text = $"{Math.Round(diemTB / 10, 1)}/10";
        }
        #endregion

        #region 2. Biểu đồ Tròn (Pie Chart)
        private void LoadPieChart()
        {
            chartPie.Datasets.Clear();
            var dataset = new AntdUI.ChartDataset("Vocab Distribution");

            // Lấy danh sách xếp hạng chủ đề theo số lượng từ giảm dần
            string sql = @"
                SELECT ISNULL(c.TenChuDe, N'Chưa phân loại') AS TenChuDe, COUNT(t.IdTuVung) as SoLuong 
                FROM TuVung t 
                LEFT JOIN ChuDe c ON t.IdChuDe = c.IdChuDe 
                GROUP BY c.TenChuDe
                ORDER BY SoLuong DESC";

            DataTable dt = _db.LayDuLieu(sql);

            // Bảng màu Pastel chuẩn (Màu thứ 6 dành cho Others)
            Color[] colors = {
                Color.FromArgb(135, 187, 245), Color.FromArgb(162, 216, 182),
                Color.FromArgb(255, 198, 153), Color.FromArgb(203, 178, 238),
                Color.FromArgb(255, 179, 198), Color.FromArgb(220, 220, 220)
            };

            double othersCount = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double soLuong = Convert.ToDouble(dt.Rows[i]["SoLuong"]);

                if (i < 5)
                {
                    // 5 chủ đề top đầu
                    string tenChuDe = dt.Rows[i]["TenChuDe"].ToString();
                    dataset.AddPoint(new AntdUI.ChartDataPoint(tenChuDe, 0, soLuong)
                    {
                        Color = colors[i]
                    });
                }
                else
                {
                    // Gộp phần còn lại vào Others
                    othersCount += soLuong;
                }
            }

            // Thêm mục Others nếu có dữ liệu
            if (othersCount > 0)
            {
                dataset.AddPoint(new AntdUI.ChartDataPoint("Others", 0, othersCount)
                {
                    Color = colors[5] // Gán màu xám nhạt
                });
            }

            chartPie.Datasets.Add(dataset);

            // Cấu hình hiển thị biểu đồ
            chartPie.ChartType = AntdUI.TChartType.Pie;
            chartPie.ShowAxes = false;
            chartPie.ShowGrid = false;
            chartPie.ShowLegend = false;
            chartPie.Padding = 0;
            chartPie.ShowXAxisLabels = false;
            chartPie.ShowYAxisLabels = false;
            chartPie.LegendPosition = ContentAlignment.MiddleRight;

            chartPie.Invalidate();
        }
        #endregion

        #region 3. Biểu đồ Đường (Line Chart)
        private void LoadLineChart()
        {
            chartLine.Datasets.Clear();
            chartLine.YMax = 10;
            chartLine.YMin = 0;

            var dataset = new AntdUI.ChartDataset("Điểm số");
            dataset.BorderColor = Color.FromArgb(22, 119, 255);
            dataset.BorderWidth = 2;
            dataset.FillColor = Color.FromArgb(22, 119, 255);

            // Lấy 7 bài làm gần nhất, sắp xếp lại theo chiều tăng của thời gian để vẽ từ trái sang phải
            string sql = @"
                SELECT * FROM (
                    SELECT TOP 7 NgayHoc, TiLePhanTram 
                    FROM LichSuHocTap 
                    ORDER BY NgayHoc DESC
                ) AS T ORDER BY NgayHoc ASC";

            DataTable dt = _db.LayDuLieu(sql);

            int xIndex = 1;
            foreach (DataRow row in dt.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["NgayHoc"]);
                // Quy đổi tỷ lệ phần trăm (0-100) sang thang điểm 10
                double diem = Convert.ToDouble(row["TiLePhanTram"]) / 10.0;

                dataset.AddPoint(ngay.ToString("dd/MM"), xIndex, diem);
                xIndex++;
            }

            chartLine.Datasets.Add(dataset);

            chartLine.ChartType = AntdUI.TChartType.Line;
            chartLine.ShowAxes = true;
            chartLine.ShowGrid = true;
            chartLine.ShowLegend = false;

            chartLine.Invalidate();
        }
        #endregion

        #region 4. Bảng Từ khó (Table)
        private void LoadTopTuKho()     // Lấy 5 từ vựng có số lần sai nhiều nhất
        {
            string sql = @"
                SELECT TOP 5 
                    t.TiengAnh as [Từ Vựng], 
                    t.TiengViet as [Nghĩa], 
                    tk.SoLanSai as [Số Lần Sai]
                FROM TuVungKho tk
                JOIN TuVung t ON tk.IdTuVung = t.IdTuVung
                ORDER BY tk.SoLanSai DESC";

            DataTable dt = _db.LayDuLieu(sql);
            table1.DataSource = dt;
        }
        #endregion
    }
}