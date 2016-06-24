namespace SupercellProxy
{
    partial class ProxyUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxyUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.aPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logo = new System.Windows.Forms.PictureBox();
            this.generalInfo = new System.Windows.Forms.GroupBox();
            this.versionTxt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalPacketsTxt = new System.Windows.Forms.Label();
            this.timeTxt = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.eventBox = new System.Windows.Forms.RichTextBox();
            this.packetView = new System.Windows.Forms.DataGridView();
            this.clearPacketViewBtn = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayloadLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.generalInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetView)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(710, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // aPIToolStripMenuItem
            // 
            this.aPIToolStripMenuItem.Name = "aPIToolStripMenuItem";
            this.aPIToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.aPIToolStripMenuItem.Text = "API";
            this.aPIToolStripMenuItem.Click += new System.EventHandler(this.aPIToolStripMenuItem_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(56, 19);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(99, 103);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // generalInfo
            // 
            this.generalInfo.BackColor = System.Drawing.SystemColors.Control;
            this.generalInfo.Controls.Add(this.logo);
            this.generalInfo.Controls.Add(this.versionTxt);
            this.generalInfo.Location = new System.Drawing.Point(248, 27);
            this.generalInfo.Name = "generalInfo";
            this.generalInfo.Size = new System.Drawing.Size(211, 179);
            this.generalInfo.TabIndex = 2;
            this.generalInfo.TabStop = false;
            // 
            // versionTxt
            // 
            this.versionTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionTxt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionTxt.Location = new System.Drawing.Point(3, 125);
            this.versionTxt.Name = "versionTxt";
            this.versionTxt.Size = new System.Drawing.Size(205, 51);
            this.versionTxt.TabIndex = 2;
            this.versionTxt.Text = "Version";
            this.versionTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stopBtn);
            this.groupBox1.Controls.Add(this.startBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 279);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "______________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "______________________";
            // 
            // stopBtn
            // 
            this.stopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopBtn.Image")));
            this.stopBtn.Location = new System.Drawing.Point(18, 129);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(185, 50);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.TabStop = false;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Location = new System.Drawing.Point(18, 73);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(185, 50);
            this.startBtn.TabIndex = 0;
            this.startBtn.TabStop = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalPacketsTxt);
            this.groupBox2.Controls.Add(this.timeTxt);
            this.groupBox2.Location = new System.Drawing.Point(222, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 94);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // totalPacketsTxt
            // 
            this.totalPacketsTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalPacketsTxt.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.totalPacketsTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.totalPacketsTxt.Location = new System.Drawing.Point(3, 50);
            this.totalPacketsTxt.Name = "totalPacketsTxt";
            this.totalPacketsTxt.Size = new System.Drawing.Size(261, 34);
            this.totalPacketsTxt.TabIndex = 1;
            this.totalPacketsTxt.Text = "0 total packet(s)";
            this.totalPacketsTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTxt
            // 
            this.timeTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeTxt.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.timeTxt.Location = new System.Drawing.Point(3, 16);
            this.timeTxt.Name = "timeTxt";
            this.timeTxt.Size = new System.Drawing.Size(261, 34);
            this.timeTxt.TabIndex = 0;
            this.timeTxt.Text = "Time";
            this.timeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.eventBox);
            this.groupBox3.Location = new System.Drawing.Point(495, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 279);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // eventBox
            // 
            this.eventBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.eventBox.Location = new System.Drawing.Point(6, 11);
            this.eventBox.Name = "eventBox";
            this.eventBox.ReadOnly = true;
            this.eventBox.Size = new System.Drawing.Size(191, 262);
            this.eventBox.TabIndex = 5;
            this.eventBox.Text = "              ==================\n                      EVENT LOG\n              ==" +
    "================\n\n";
            // 
            // packetView
            // 
            this.packetView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.packetView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.packetView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.packetView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PayloadLength,
            this.Direction,
            this.Timestamp,
            this.Payload});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.packetView.DefaultCellStyle = dataGridViewCellStyle2;
            this.packetView.Location = new System.Drawing.Point(0, 312);
            this.packetView.Name = "packetView";
            this.packetView.Size = new System.Drawing.Size(710, 252);
            this.packetView.TabIndex = 5;
            // 
            // clearPacketViewBtn
            // 
            this.clearPacketViewBtn.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.clearPacketViewBtn.Location = new System.Drawing.Point(222, 570);
            this.clearPacketViewBtn.Name = "clearPacketViewBtn";
            this.clearPacketViewBtn.Size = new System.Drawing.Size(267, 26);
            this.clearPacketViewBtn.TabIndex = 6;
            this.clearPacketViewBtn.Text = "Clear packet view";
            this.clearPacketViewBtn.UseVisualStyleBackColor = true;
            this.clearPacketViewBtn.Click += new System.EventHandler(this.clearPacketViewBtn_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "Packet ID";
            this.ID.Name = "ID";
            this.ID.Width = 65;
            // 
            // PayloadLength
            // 
            this.PayloadLength.HeaderText = "Length";
            this.PayloadLength.Name = "PayloadLength";
            this.PayloadLength.Width = 45;
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Direction";
            this.Direction.Name = "Direction";
            // 
            // Timestamp
            // 
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Width = 150;
            // 
            // Payload
            // 
            this.Payload.HeaderText = "Payload";
            this.Payload.Name = "Payload";
            this.Payload.Width = 322;
            // 
            // ProxyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 602);
            this.Controls.Add(this.clearPacketViewBtn);
            this.Controls.Add(this.packetView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generalInfo);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "ProxyUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supercell Proxy UI ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProxyUI_FormClosing);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.generalInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.packetView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.GroupBox generalInfo;
        private System.Windows.Forms.Label versionTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox eventBox;
        private System.Windows.Forms.Label totalPacketsTxt;
        private System.Windows.Forms.Label timeTxt;
        private System.Windows.Forms.ToolStripMenuItem aPIToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox stopBtn;
        private System.Windows.Forms.PictureBox startBtn;
        private System.Windows.Forms.DataGridView packetView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearPacketViewBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayloadLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payload;
    }
}