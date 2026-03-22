using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FromDashboard : Form
    {
        public FromDashboard()
        {
            InitializeComponent();
        }

        private void FromDashboard_Load(object sender, EventArgs e)
        {
            LoadPieChart();
        }

        private void LoadPieChart()
        {
            chartPie.Datasets.Clear();
            var dataset = new AntdUI.ChartDataset("Vocab Distribution");

            // Ép màu trực tiếp cho từng điểm dữ liệu
            dataset.AddPoint(new AntdUI.ChartDataPoint("Technology", 0, 35) { Color = Color.FromArgb(22, 119, 255) }); // Xanh dương
            dataset.AddPoint(new AntdUI.ChartDataPoint("Business", 0, 20) { Color = Color.FromArgb(82, 196, 26) });   // Xanh lá
            dataset.AddPoint(new AntdUI.ChartDataPoint("Food", 0, 20) { Color = Color.FromArgb(250, 140, 22) });     // Cam
            dataset.AddPoint(new AntdUI.ChartDataPoint("Travel", 0, 10) { Color = Color.FromArgb(114, 46, 209) });   // Tím
            dataset.AddPoint(new AntdUI.ChartDataPoint("Others", 0, 15) { Color = Color.FromArgb(235, 47, 150) });   // Hồng

            chartPie.Datasets.Add(dataset);

            // Cấu hình hiển thị sạch sẽ
            chartPie.ChartType = AntdUI.TChartType.Pie;
            chartPie.ShowAxes = false;
            chartPie.ShowGrid = false;
            chartPie.ShowLegend = false;
            chartPie.Padding = 0;
            chartPie.ShowXAxisLabels = false;
            chartPie.ShowYAxisLabels = false;
            chartPie.LegendPosition = ContentAlignment.MiddleRight; // Đẩy chú thích sang phải cho đỡ vướng

            chartPie.Invalidate();
        }
    }
}
