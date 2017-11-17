namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.typepack = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.destip = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.sourceip = new System.Windows.Forms.TextBox();
            this.len2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.len1 = new System.Windows.Forms.TextBox();
            this.No2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.No1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.rowscount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 479);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button5.Location = new System.Drawing.Point(381, 399);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 33);
            this.button5.TabIndex = 2;
            this.button5.Text = "Browse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(63, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Interface to start capturing. Or browse a pcap file.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(688, 297);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rowscount);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.typepack);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.destip);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.sourceip);
            this.panel2.Controls.Add(this.len2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.len1);
            this.panel2.Controls.Add(this.No2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.No1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 479);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button4.Location = new System.Drawing.Point(331, 439);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 22;
            this.button4.Text = "Stats";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(530, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "Type";
            // 
            // typepack
            // 
            this.typepack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.typepack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.typepack.Location = new System.Drawing.Point(576, 43);
            this.typepack.Name = "typepack";
            this.typepack.Size = new System.Drawing.Size(134, 26);
            this.typepack.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(252, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Destination";
            // 
            // destip
            // 
            this.destip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.destip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.destip.Location = new System.Drawing.Point(331, 88);
            this.destip.Name = "destip";
            this.destip.Size = new System.Drawing.Size(134, 26);
            this.destip.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(269, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Source";
            // 
            // sourceip
            // 
            this.sourceip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sourceip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sourceip.Location = new System.Drawing.Point(331, 44);
            this.sourceip.Name = "sourceip";
            this.sourceip.Size = new System.Drawing.Size(134, 26);
            this.sourceip.TabIndex = 2;
            // 
            // len2
            // 
            this.len2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.len2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.len2.Location = new System.Drawing.Point(184, 88);
            this.len2.Name = "len2";
            this.len2.Size = new System.Drawing.Size(50, 26);
            this.len2.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(70, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Length";
            // 
            // len1
            // 
            this.len1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.len1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.len1.Location = new System.Drawing.Point(128, 89);
            this.len1.Name = "len1";
            this.len1.Size = new System.Drawing.Size(50, 26);
            this.len1.TabIndex = 4;
            // 
            // No2
            // 
            this.No2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.No2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.No2.Location = new System.Drawing.Point(184, 43);
            this.No2.Name = "No2";
            this.No2.Size = new System.Drawing.Size(50, 26);
            this.No2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(94, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "No";
            // 
            // No1
            // 
            this.No1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.No1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.No1.Location = new System.Drawing.Point(128, 43);
            this.No1.Name = "No1";
            this.No1.Size = new System.Drawing.Size(50, 26);
            this.No1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(9, 6);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(5);
            this.button3.Size = new System.Drawing.Size(20, 17);
            this.button3.TabIndex = 4;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(35, 3);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(5);
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 3;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(417, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.Location = new System.Drawing.Point(9, 130);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(793, 291);
            this.dataGridView2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(524, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Rows";
            // 
            // rowscount
            // 
            this.rowscount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rowscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rowscount.Location = new System.Drawing.Point(576, 87);
            this.rowscount.Name = "rowscount";
            this.rowscount.Size = new System.Drawing.Size(134, 26);
            this.rowscount.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Interface";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox No2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox No1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sourceip;
        private System.Windows.Forms.TextBox len2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox len1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox typepack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox destip;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rowscount;
    }
}

