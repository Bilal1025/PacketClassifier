using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using System.ComponentModel;
using System;
using System.Data;
using System.Xml;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
        DataTable data1 = new DataTable(), filterddata = new DataTable();
        BackgroundWorker worker = new BackgroundWorker(), searchhandler = new BackgroundWorker();
        XmlDocument xmlDoc = new XmlDocument();
        Boolean searchagain = false;
        int selected = 0, type = 0;
        DataTable classifier;
        string filename = "";
        Form2 form;
        public Form1()
        {
            InitializeComponent();
            rowscount.Text = "100";
            Load += Form1_Load;
            searchhandler.DoWork += Searchhandler_DoWork;
            searchhandler.RunWorkerCompleted += Searchhandler_RunWorkerCompleted;
            searchhandler.WorkerReportsProgress = false;
            searchhandler.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += Worker_ProgressChanged;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (allDevices.Count == 0)
            {
                MessageBox.Show("No Interface Found.");
                Application.Exit();
            }
            dataGridView1.DataSource = allDevices;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].DisplayIndex = 0;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            data1.Columns.Add("No", typeof(int));
            data1.Columns.Add("Source");
            data1.Columns.Add("Destination");
            data1.Columns.Add("Length", typeof(int));
            data1.Columns.Add("Type");
            data1.Columns.Add("Color", typeof(Color));
            data1.Columns.Add("Time", typeof(DateTime));
            filterddata.Columns.Add("No", typeof(int));
            filterddata.Columns.Add("Source");
            filterddata.Columns.Add("Destination");
            filterddata.Columns.Add("Length", typeof(int));
            filterddata.Columns.Add("Type");
            filterddata.Columns.Add("Color", typeof(Color));
            filterddata.Columns.Add("Time", typeof(DateTime));
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            try
            {
                xmlDoc.Load(Environment.CurrentDirectory + @"/XMLFile1.xml"); // Load the XML document from the specified file
            }
            catch
            {
                MessageBox.Show("Classifier Not Found.");
                Close();
            }
            classifier = new DataTable();
            classifier.Columns.Add("Name");
            classifier.Columns.Add("Count", typeof(int));
            classifier.Columns.Add("Color", typeof(Color));
            classifier.PrimaryKey = new DataColumn[] { classifier.Columns[0] };
            No1.KeyPress += MaskedTextBox1_KeyPress;
            No2.KeyPress += MaskedTextBox1_KeyPress;
            len1.KeyPress += MaskedTextBox1_KeyPress;
            len2.KeyPress += MaskedTextBox1_KeyPress;
            foreach (Control item1 in Controls)
            {
                if (item1 is Panel)
                {
                    foreach (Control item2 in item1.Controls)
                    {
                        if (item2 is TextBox)
                        {
                            ((TextBox)item2).TextAlign = HorizontalAlignment.Center;
                            ((TextBox)item2).KeyDown += Item_KeyDown;
                        }
                        if (item2 is MaskedTextBox)
                        {
                            ((MaskedTextBox)item2).TextAlign = HorizontalAlignment.Center;
                            ((MaskedTextBox)item2).KeyDown += Item_KeyDown;
                        }
                    }
                }
                if (item1 is TextBox)
                {
                    ((TextBox)item1).TextAlign = HorizontalAlignment.Center;
                    ((TextBox)item1).KeyDown += Item_KeyDown;
                }
            }
            No1.TextChanged += No1_TextChanged;
            No2.TextChanged += No1_TextChanged;
            len1.TextChanged += No1_TextChanged;
            len2.TextChanged += No1_TextChanged;
            sourceip.TextChanged += No1_TextChanged;
            destip.TextChanged += No1_TextChanged;
            typepack.TextChanged += No1_TextChanged;
            rowscount.TextChanged+= No1_TextChanged;
            form = new Form2();
            dataGridView2.VirtualMode = true;
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "No", HeaderText = "No", ValueType = typeof(int) });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Source", HeaderText = "Source" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Destination", HeaderText = "Destination" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Length", HeaderText = "Length" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Type", HeaderText = "Type" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Color", HeaderText = "Color", ValueType = typeof(Color) });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Time", HeaderText = "Time", ValueType = typeof(DateTime) });
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.CellFormatting += DataGridView2_CellFormatting;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            foreach (DataGridViewColumn item in dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.FillWeight = 5;
                item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView2.Columns["No"].FillWeight = 1;
            dataGridView2.Columns["Length"].FillWeight = 2;
            dataGridView2.Columns["Color"].Visible = false;
            dataGridView2.CellValueNeeded += dataGridView1_CellValueNeeded;
            dataGridView2.RowCount = 0;
        }
        private void Searchhandler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (searchagain)
            {
                searchagain = false;
                searchhandler.RunWorkerAsync();
                return;
            }
            int count = filterddata.Rows.Count;
            DataTable coll = e.Result as DataTable;
            if (e.Result != null && coll.Rows.Count > 0)
                filterddata = coll;
            else
                filterddata.Rows.Clear();
            if (Math.Abs(count - filterddata.Rows.Count) > 300)
                dataGridView2.Rows.Clear();
            dataGridView2.RowCount = filterddata.Rows.Count;
            dataGridView2.Refresh();
        }
        private void Searchhandler_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(300);
            if (e.Cancel)
                return;
                try
                {
                    e.Result = data1.AsEnumerable().Where(x =>
                        int.Parse(x["No"].ToString()) > int.Parse(String.IsNullOrEmpty(No1.Text) ? "0" : No1.Text)
                        && int.Parse(x["No"].ToString()) <= int.Parse(String.IsNullOrEmpty(No2.Text) ? int.MaxValue.ToString() : No2.Text)
                            && int.Parse(x["Length"].ToString()) >= int.Parse(String.IsNullOrEmpty(len1.Text) ? "0" : len1.Text)
                            && int.Parse(x["Length"].ToString()) <= int.Parse(String.IsNullOrEmpty(len2.Text) ? int.MaxValue.ToString() : len2.Text)
                            && x["Source"].ToString().Contains(sourceip.Text)
                            && x["Destination"].ToString().Contains(destip.Text)
                            && Regex.IsMatch(x["Type"].ToString().ToLower(), "\\b" + typepack.Text + "\\b", RegexOptions.IgnoreCase)).Take(int.Parse(string.IsNullOrEmpty(rowscount.Text) ? int.MaxValue.ToString() : rowscount.Text)).CopyToDataTable();
                    
                }
                catch
                {
                     e.Result = null;
                }
            
        }
        private void No1_TextChanged(object sender, EventArgs e)
        {
            if (data1.Rows.Count == 0)
                return;
            if (searchhandler.IsBusy)
            {
                searchhandler.CancelAsync();
                searchagain = true;
            }
            else
                searchhandler.RunWorkerAsync();
        }
        private void Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.Back)
            {
                e.Handled = true;
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow r = (sender as DataGridView).Rows[e.RowIndex];
            r.DefaultCellStyle.BackColor = Color.LightGreen;
            r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(125, 125, 255);
            r.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (dataGridView1.CurrentCell == null)
                    return;
                type = 0;
                button2.Visible = true;
                button3.Visible = true;
                worker.RunWorkerAsync(dataGridView1.CurrentCell.RowIndex);
                selected = dataGridView1.CurrentCell.RowIndex;
                panel1.Hide();
                panel2.Show();
                Text = "Capturing";
            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            type = 0;
            button2.Visible = true;
            button3.Visible = true;
            worker.RunWorkerAsync(e.RowIndex);
            selected = e.RowIndex;
            panel1.Hide();
            panel2.Show();
            Text = "Capturing";
        }
        private void dataGridView1_CellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= filterddata.Rows.Count)
                return;
            if (e.RowIndex == dataGridView2.Rows.Count)
                return;
            DataRow customerTmp;
            customerTmp = this.filterddata.Rows[e.RowIndex];
            switch (this.dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "No":
                    e.Value = customerTmp["No"];
                    break;
                case "Length":
                    e.Value = customerTmp["Length"];
                    break;
                case "Color":
                    e.Value = customerTmp["Color"];
                    break;
                case "Source":
                    e.Value = customerTmp["Source"];
                    break;
                case "Destination":
                    e.Value = customerTmp["Destination"];
                    break;
                case "Type":
                    e.Value = customerTmp["Type"];
                    break;
                case "Time":
                    e.Value = customerTmp["Time"];
                    break;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            form.Show();
            form.Focus();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PCAP Files (*.pcap)|*.pcap";
            dialog.DefaultExt = "pcap";
            dialog.AddExtension = true;
            dialog.Multiselect = false;
            DialogResult res = dialog.ShowDialog();
            button3.Visible = false;
            button2.Visible = false;
            if (res == DialogResult.OK)
            {
                filename = dialog.FileName;
                type = 1;
                panel1.Hide();
                panel2.Show();
                worker.RunWorkerAsync(filename);
                Text = "Capturing";
            }
        }
        private void DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow r = (sender as DataGridView).Rows[e.RowIndex];
                r.DefaultCellStyle.BackColor = (Color)r.Cells["Color"].Value;
                r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(125, 125, 255);
                r.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            catch
            {

            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker rowshandler = new BackgroundWorker();
            rowshandler.DoWork += Rowshandler_DoWork;
            rowshandler.RunWorkerCompleted += Rowshandler_RunWorkerCompleted;
            rowshandler.RunWorkerAsync(e.UserState);
            BackgroundWorker classifierhandler = new BackgroundWorker();
            classifierhandler.DoWork += Classifierhandler_DoWork;
            classifierhandler.RunWorkerCompleted += Classifierhandler_RunWorkerCompleted;
            classifierhandler.RunWorkerAsync(e.UserState);
        }
        private void Classifierhandler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            DataRow row1 = e.Result as DataRow;
            if (row1.ItemArray.Length != 3)
            {
                foreach (DataRow item in classifier.Rows)
                {
                    if (item["Name"].ToString().Equals(row1["Type"].ToString()))
                        item["Count"] = int.Parse(item["Count"].ToString()) + 1;
                }
            }
            else
            {
                try
                {
                    classifier.Rows.Add(row1);
                }
                catch
                {
                    foreach (DataRow item in classifier.Rows)
                    {
                        if (item["Name"].ToString().Equals(row1["Name"].ToString()))
                            item["Count"] = int.Parse(item["Count"].ToString()) + 1;
                    }
                }
            }
            form.update(classifier);
        }
        private void Classifierhandler_DoWork(object sender, DoWorkEventArgs e)
        {
            DataRow row1 = e.Argument as DataRow;
            try
            {
                if (!classifier.AsEnumerable().Any(x => x["Name"].ToString().Equals(row1["Type"].ToString())))
                {
                    DataRow cl = classifier.NewRow();
                    cl["Name"] = row1["Type"];
                    cl["Count"] = 1;
                    cl["Color"] = row1["Color"];
                    e.Result = cl;
                }
                else
                {
                    e.Result = row1;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }
        private void Rowshandler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            DataRow row1 = filterddata.NewRow();
            if (e.Result != null)
            {
                row1.ItemArray = e.Result as object[];
                filterddata.Rows.Add(row1);
                filterddata.DefaultView.Sort = "No asc";
                filterddata = filterddata.DefaultView.ToTable();
                dataGridView2.RowCount = filterddata.Rows.Count;
            }
        }
        private void Rowshandler_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataRow row = e.Argument as DataRow;
                if (filterddata.Rows.Count < int.Parse(string.IsNullOrEmpty(rowscount.Text) ? int.MaxValue.ToString() : rowscount.Text))
                {
                    if (row.Field<int>("No") >= int.Parse(String.IsNullOrEmpty(No1.Text) ? "0" : No1.Text)
                      && row.Field<int>("No") <= int.Parse(String.IsNullOrEmpty(No2.Text) ? int.MaxValue.ToString() : No2.Text)
                      && row.Field<int>("Length") >= int.Parse(String.IsNullOrEmpty(len1.Text) ? "0" : len1.Text)
                      && row.Field<int>("Length") <= int.Parse(String.IsNullOrEmpty(len2.Text) ? int.MaxValue.ToString() : len2.Text)
                      && row.Field<String>("Source").Contains(sourceip.Text)
                      && row.Field<String>("Destination").Contains(destip.Text)
                      && Regex.IsMatch(row.Field<string>("Type").ToLower(), "\\b" + typepack.Text + "\\b", RegexOptions.IgnoreCase))
                    {
                        e.Result = row.ItemArray;
                        return;
                    }
                }
                e.Result = null;
            }
            catch
            {
                e.Cancel = true;
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            PacketDevice selectedDevice = null;
            if (type == 0)
                selectedDevice = allDevices[int.Parse(e.Argument.ToString())];
            else
                selectedDevice = new OfflinePacketDevice(e.Argument.ToString());
            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                Packet packet;
                do
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            continue;
                        case PacketCommunicatorReceiveResult.Ok:
                            try
                            {
                                DataRow row = data1.NewRow();
                                row.SetField<int>("No", data1.Rows.Count + 1);
                                row.SetField("Source", packet.Ethernet.IpV4.Source + ":" + packet.Ethernet.IpV4.Udp.SourcePort);
                                row.SetField("Destination", packet.Ethernet.IpV4.Destination + ":" + packet.Ethernet.IpV4.Udp.DestinationPort);
                                row.SetField("Time", packet.Timestamp);
                                row.SetField("Length", packet.Length);
                                string name = "";
                                try
                                {
                                    name = xmlDoc.FirstChild.ChildNodes.OfType<XmlElement>().Where(x => x.ChildNodes[3].InnerText.Equals(packet.Ethernet.IpV4.Udp.SourcePort.ToString())).Select(x => x.ChildNodes[0].InnerText).First();
                                    row.SetField("Type", name);
                                }
                                catch
                                {
                                    try
                                    {
                                        name = xmlDoc.FirstChild.ChildNodes.OfType<XmlElement>().Where(x => x.ChildNodes[3].InnerText.Equals(packet.Ethernet.IpV4.Udp.DestinationPort.ToString())).Select(x => x.ChildNodes[0].InnerText).First();
                                        row.SetField("Type", name);
                                    }
                                    catch
                                    {
                                        name = "Not Classified";
                                        row.SetField("Type", "Not Classified");
                                    }
                                }
                                row["Color"] = Color.LightBlue;
                                data1.Rows.Add(row);
                                (sender as BackgroundWorker).ReportProgress(50, row);
                            }
                            catch
                            {

                            }
                            break;
                        default:
                            (sender as BackgroundWorker).CancelAsync();
                            break;
                    }
                } while (!(sender as BackgroundWorker).CancellationPending);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
            panel1.Show();
            panel2.Hide();
            data1.Clear();
            rowscount.Text = "100";
            filterddata.Clear();
            classifier.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.RowCount = 0;
            form.Hide();
            Text = "Select Interface";
        }
        private void MaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync(selected);
        }
    }
}