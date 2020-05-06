namespace HID_PnP_Demo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsimiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btGenerateCurve = new System.Windows.Forms.Button();
            this.btClearParam = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.tlpRightTop = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDataList = new System.Windows.Forms.DataGridView();
            this.CNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CQinJiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSJZT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRightTopPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zgcChart = new ZedGraph.ZedGraphControl();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsState = new System.Windows.Forms.ToolStripStatusLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.btGetCount = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.tsUSB = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).BeginInit();
            this.pRightTopPanel.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1214, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsimiFileExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(58, 21);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsimiFileExit
            // 
            this.tsimiFileExit.Name = "tsimiFileExit";
            this.tsimiFileExit.Size = new System.Drawing.Size(115, 22);
            this.tsimiFileExit.Text = "退出(&E)";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 675F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRightTop, 1, 0);
            this.tlpMain.Controls.Add(this.zgcChart, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 27);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1214, 942);
            this.tlpMain.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btEdit, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.btGetCount, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btGenerateCurve, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btClearParam, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbCount, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 392);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbTitle, 6);
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbTitle.Location = new System.Drawing.Point(3, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(663, 65);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "钻井轨迹基础参数";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btGenerateCurve
            // 
            this.btGenerateCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btGenerateCurve.Location = new System.Drawing.Point(449, 263);
            this.btGenerateCurve.Name = "btGenerateCurve";
            this.btGenerateCurve.Size = new System.Drawing.Size(106, 59);
            this.btGenerateCurve.TabIndex = 1;
            this.btGenerateCurve.Text = "生成曲线";
            this.btGenerateCurve.UseVisualStyleBackColor = true;
            this.btGenerateCurve.Click += new System.EventHandler(this.btGenerateCurve_Click);
            // 
            // btClearParam
            // 
            this.btClearParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClearParam.Location = new System.Drawing.Point(561, 263);
            this.btClearParam.Name = "btClearParam";
            this.btClearParam.Size = new System.Drawing.Size(105, 59);
            this.btClearParam.TabIndex = 2;
            this.btClearParam.Text = "清除参数";
            this.btClearParam.UseVisualStyleBackColor = true;
            this.btClearParam.Click += new System.EventHandler(this.btClearParam_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "杆号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "深度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "水平距离：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "垂直距离：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "倾角：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(449, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "数据状态：";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(115, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(105, 23);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Location = new System.Drawing.Point(338, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 23);
            this.textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Location = new System.Drawing.Point(561, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(105, 23);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Location = new System.Drawing.Point(115, 133);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(105, 23);
            this.textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox5.Location = new System.Drawing.Point(338, 133);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(105, 23);
            this.textBox5.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox6.Location = new System.Drawing.Point(561, 133);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(105, 23);
            this.textBox6.TabIndex = 16;
            // 
            // tlpRightTop
            // 
            this.tlpRightTop.ColumnCount = 1;
            this.tlpRightTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpRightTop.Controls.Add(this.dgvDataList, 0, 1);
            this.tlpRightTop.Controls.Add(this.pRightTopPanel, 0, 0);
            this.tlpRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightTop.Location = new System.Drawing.Point(678, 4);
            this.tlpRightTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpRightTop.Name = "tlpRightTop";
            this.tlpRightTop.RowCount = 2;
            this.tlpRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightTop.Size = new System.Drawing.Size(533, 392);
            this.tlpRightTop.TabIndex = 1;
            // 
            // dgvDataList
            // 
            this.dgvDataList.AllowUserToAddRows = false;
            this.dgvDataList.AllowUserToDeleteRows = false;
            this.dgvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNUM,
            this.CDeep,
            this.CPosition,
            this.CZDeep,
            this.CQinJiao,
            this.CSJZT,
            this.CTest});
            this.dgvDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataList.Location = new System.Drawing.Point(3, 44);
            this.dgvDataList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDataList.Name = "dgvDataList";
            this.dgvDataList.ReadOnly = true;
            this.dgvDataList.RowHeadersWidth = 51;
            this.dgvDataList.RowTemplate.Height = 27;
            this.dgvDataList.Size = new System.Drawing.Size(527, 344);
            this.dgvDataList.TabIndex = 0;
            this.dgvDataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellClick);
            // 
            // CNUM
            // 
            this.CNUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNUM.DataPropertyName = "GH";
            this.CNUM.HeaderText = "杆号";
            this.CNUM.MinimumWidth = 6;
            this.CNUM.Name = "CNUM";
            this.CNUM.ReadOnly = true;
            // 
            // CDeep
            // 
            this.CDeep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CDeep.DataPropertyName = "Deep";
            this.CDeep.HeaderText = "深度";
            this.CDeep.MinimumWidth = 6;
            this.CDeep.Name = "CDeep";
            this.CDeep.ReadOnly = true;
            // 
            // CPosition
            // 
            this.CPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CPosition.DataPropertyName = "Position";
            this.CPosition.HeaderText = "水平距离";
            this.CPosition.MinimumWidth = 6;
            this.CPosition.Name = "CPosition";
            this.CPosition.ReadOnly = true;
            // 
            // CZDeep
            // 
            this.CZDeep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CZDeep.DataPropertyName = "ZDeep";
            this.CZDeep.HeaderText = "垂直距离";
            this.CZDeep.MinimumWidth = 6;
            this.CZDeep.Name = "CZDeep";
            this.CZDeep.ReadOnly = true;
            // 
            // CQinJiao
            // 
            this.CQinJiao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CQinJiao.DataPropertyName = "QingJiao";
            this.CQinJiao.HeaderText = "倾角";
            this.CQinJiao.MinimumWidth = 6;
            this.CQinJiao.Name = "CQinJiao";
            this.CQinJiao.ReadOnly = true;
            // 
            // CSJZT
            // 
            this.CSJZT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CSJZT.DataPropertyName = "SJZT";
            this.CSJZT.HeaderText = "数据状态";
            this.CSJZT.MinimumWidth = 6;
            this.CSJZT.Name = "CSJZT";
            this.CSJZT.ReadOnly = true;
            // 
            // CTest
            // 
            this.CTest.DataPropertyName = "TestString";
            this.CTest.HeaderText = "测试字符串";
            this.CTest.MinimumWidth = 6;
            this.CTest.Name = "CTest";
            this.CTest.ReadOnly = true;
            this.CTest.Visible = false;
            this.CTest.Width = 125;
            // 
            // pRightTopPanel
            // 
            this.pRightTopPanel.Controls.Add(this.label3);
            this.pRightTopPanel.Controls.Add(this.label2);
            this.pRightTopPanel.Controls.Add(this.label1);
            this.pRightTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRightTopPanel.Location = new System.Drawing.Point(3, 3);
            this.pRightTopPanel.Name = "pRightTopPanel";
            this.pRightTopPanel.Size = new System.Drawing.Size(527, 34);
            this.pRightTopPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "地点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "工程名称：";
            // 
            // zgcChart
            // 
            this.tlpMain.SetColumnSpan(this.zgcChart, 2);
            this.zgcChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcChart.Location = new System.Drawing.Point(4, 405);
            this.zgcChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zgcChart.Name = "zgcChart";
            this.zgcChart.ScrollGrace = 0D;
            this.zgcChart.ScrollMaxX = 0D;
            this.zgcChart.ScrollMaxY = 0D;
            this.zgcChart.ScrollMaxY2 = 0D;
            this.zgcChart.ScrollMinX = 0D;
            this.zgcChart.ScrollMinY = 0D;
            this.zgcChart.ScrollMinY2 = 0D;
            this.zgcChart.Size = new System.Drawing.Size(1206, 532);
            this.zgcChart.TabIndex = 2;
            this.zgcChart.UseExtendedPrintDialog = true;
            this.zgcChart.Load += new System.EventHandler(this.zgcChart_Load);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUSB,
            this.tsState});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 947);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1214, 22);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // tsState
            // 
            this.tsState.Name = "tsState";
            this.tsState.Size = new System.Drawing.Size(44, 17);
            this.tsState.Text = "Ready";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "总数量";
            // 
            // tbCount
            // 
            this.tbCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCount.Location = new System.Drawing.Point(115, 263);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(105, 23);
            this.tbCount.TabIndex = 20;
            this.tbCount.Text = "0";
            // 
            // btGetCount
            // 
            this.btGetCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btGetCount.Location = new System.Drawing.Point(226, 263);
            this.btGetCount.Name = "btGetCount";
            this.btGetCount.Size = new System.Drawing.Size(106, 59);
            this.btGetCount.TabIndex = 21;
            this.btGetCount.Text = "读取数量";
            this.btGetCount.UseVisualStyleBackColor = true;
            this.btGetCount.Click += new System.EventHandler(this.btGetCount_Click);
            // 
            // btEdit
            // 
            this.btEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEdit.Location = new System.Drawing.Point(561, 198);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(105, 59);
            this.btEdit.TabIndex = 22;
            this.btEdit.Text = "修改数据";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // tsUSB
            // 
            this.tsUSB.Name = "tsUSB";
            this.tsUSB.Size = new System.Drawing.Size(44, 17);
            this.tsUSB.Text = "未连接";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 969);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据监视工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).EndInit();
            this.pRightTopPanel.ResumeLayout(false);
            this.pRightTopPanel.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsimiFileExit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpRightTop;
        private System.Windows.Forms.DataGridView dgvDataList;
        private ZedGraph.ZedGraphControl zgcChart;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pRightTopPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGenerateCurve;
        private System.Windows.Forms.Button btClearParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDeep;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn CZDeep;
        private System.Windows.Forms.DataGridViewTextBoxColumn CQinJiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSJZT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsState;
        private System.Windows.Forms.Button btGetCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.ToolStripStatusLabel tsUSB;
    }
}