using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FormClosing += Form2_FormClosing;
            chart1.Series["Weightage"].Name = "No Of Packets";
            columnchart.CheckedChanged += Columnchart_CheckedChanged;
            pichart.CheckedChanged += Columnchart_CheckedChanged;
            List.CheckedChanged += Columnchart_CheckedChanged;
            pyramid.CheckedChanged += Columnchart_CheckedChanged;
            chart1.Series["No Of Packets"].IsVisibleInLegend = false;
            dataGridView1.Visible = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Load += Form2_Load;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(125, 125, 255);
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void Columnchart_CheckedChanged(object sender, System.EventArgs e)
        {
            chart1.Series["No Of Packets"].IsVisibleInLegend = true;
            chart1.Visible = true;
            dataGridView1.Visible = false;
            if (columnchart.Checked)
            {
                chart1.Series["No Of Packets"].IsVisibleInLegend = false;
                chart1.Series["No Of Packets"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (pichart.Checked)
            {
                chart1.Series["No Of Packets"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series["No Of Packets"]["PieLabelStyle"] = "Disabled";
            }
            if (pyramid.Checked)
                chart1.Series["No Of Packets"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pyramid;
            if (List.Checked)
            {
                chart1.Visible = false;
                dataGridView1.Visible = true;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        public void update(DataTable table)
        {
            chart1.Series["No Of Packets"].Points.Clear();
            if (table.Rows.Count == 0)
                return;
            foreach (DataRow item in table.Rows)
            {
                chart1.Series["No Of Packets"].Points.AddXY(item["Name"], int.Parse(item["Count"].ToString()));
            }
            dataGridView1.DataSource = table;
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView1.Columns["Color"].Visible = false;
        }
    }
}
