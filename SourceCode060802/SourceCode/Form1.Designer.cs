namespace HID_PnP_Demo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ANxVoltage_lbl = new System.Windows.Forms.Label();
            this.StatusBox_lbl = new System.Windows.Forms.Label();
            this.StatusBox_txtbx = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ReadWriteThread = new System.ComponentModel.BackgroundWorker();
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ANxVoltageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ToggleLEDToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PushbuttonStateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PushbuttonState_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txGet = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.cb_com_typeab = new System.Windows.Forms.ComboBox();
            this.cb_ch_mod = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.tb_smecid_read = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.tb_key_val = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tb_read_num = new System.Windows.Forms.TextBox();
            this.tb_num = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ANxVoltage_lbl
            // 
            this.ANxVoltage_lbl.AutoSize = true;
            this.ANxVoltage_lbl.Enabled = false;
            this.ANxVoltage_lbl.ForeColor = System.Drawing.Color.Yellow;
            this.ANxVoltage_lbl.Location = new System.Drawing.Point(3, 45);
            this.ANxVoltage_lbl.Name = "ANxVoltage_lbl";
            this.ANxVoltage_lbl.Size = new System.Drawing.Size(53, 12);
            this.ANxVoltage_lbl.TabIndex = 23;
            this.ANxVoltage_lbl.Text = "AD读出值";
            // 
            // StatusBox_lbl
            // 
            this.StatusBox_lbl.AutoSize = true;
            this.StatusBox_lbl.ForeColor = System.Drawing.Color.Yellow;
            this.StatusBox_lbl.Location = new System.Drawing.Point(3, 15);
            this.StatusBox_lbl.Name = "StatusBox_lbl";
            this.StatusBox_lbl.Size = new System.Drawing.Size(53, 12);
            this.StatusBox_lbl.TabIndex = 22;
            this.StatusBox_lbl.Text = "连接状态";
            // 
            // StatusBox_txtbx
            // 
            this.StatusBox_txtbx.BackColor = System.Drawing.SystemColors.Window;
            this.StatusBox_txtbx.Location = new System.Drawing.Point(62, 12);
            this.StatusBox_txtbx.Name = "StatusBox_txtbx";
            this.StatusBox_txtbx.ReadOnly = true;
            this.StatusBox_txtbx.Size = new System.Drawing.Size(298, 21);
            this.StatusBox_txtbx.TabIndex = 21;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(131, 40);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Maximum = 4096;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(229, 21);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 20;
            // 
            // ReadWriteThread
            // 
            this.ReadWriteThread.WorkerReportsProgress = true;
            this.ReadWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadWriteThread_DoWork);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 6;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // ANxVoltageToolTip
            // 
            this.ANxVoltageToolTip.AutomaticDelay = 20;
            this.ANxVoltageToolTip.AutoPopDelay = 20000;
            this.ANxVoltageToolTip.InitialDelay = 15;
            this.ANxVoltageToolTip.ReshowDelay = 15;
            this.ANxVoltageToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ANxVoltageToolTip_Popup);
            // 
            // ToggleLEDToolTip
            // 
            this.ToggleLEDToolTip.AutomaticDelay = 2000;
            this.ToggleLEDToolTip.AutoPopDelay = 20000;
            this.ToggleLEDToolTip.InitialDelay = 15;
            this.ToggleLEDToolTip.ReshowDelay = 15;
            // 
            // PushbuttonStateTooltip
            // 
            this.PushbuttonStateTooltip.AutomaticDelay = 20;
            this.PushbuttonStateTooltip.AutoPopDelay = 20000;
            this.PushbuttonStateTooltip.InitialDelay = 15;
            this.PushbuttonStateTooltip.ReshowDelay = 15;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 2000;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 15;
            this.toolTip1.ReshowDelay = 15;
            // 
            // toolTip2
            // 
            this.toolTip2.AutomaticDelay = 20;
            this.toolTip2.AutoPopDelay = 20000;
            this.toolTip2.InitialDelay = 15;
            this.toolTip2.ReshowDelay = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 24);
            this.button1.TabIndex = 26;
            this.button1.Text = "LED On";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(62, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(298, 21);
            this.textBox2.TabIndex = 29;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(105, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 24);
            this.button3.TabIndex = 30;
            this.button3.Text = "LED off";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Cyan;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(273, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "label1";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(62, 39);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(63, 21);
            this.textBox11.TabIndex = 50;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1035, 63);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(190, 153);
            this.chart1.TabIndex = 53;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // PushbuttonState_lbl
            // 
            this.PushbuttonState_lbl.AutoSize = true;
            this.PushbuttonState_lbl.Enabled = false;
            this.PushbuttonState_lbl.Location = new System.Drawing.Point(738, 9);
            this.PushbuttonState_lbl.Name = "PushbuttonState_lbl";
            this.PushbuttonState_lbl.Size = new System.Drawing.Size(155, 12);
            this.PushbuttonState_lbl.TabIndex = 25;
            this.PushbuttonState_lbl.Text = "Pushbutton State: Unknown";
            this.PushbuttonState_lbl.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "USB读回值";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(311, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(68, 24);
            this.button5.TabIndex = 57;
            this.button5.Text = "清除图表";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(190, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "单次指令用时";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(228, 94);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 24);
            this.button6.TabIndex = 59;
            this.button6.Text = "读AD值";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "800",
            "1000",
            "2000",
            "3000",
            "5000",
            "8000",
            "10000"});
            this.comboBox1.Location = new System.Drawing.Point(12, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(64, 20);
            this.comboBox1.TabIndex = 60;
            this.comboBox1.Text = "100";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0.01",
            "0.1",
            "1",
            "10",
            "100",
            "1000"});
            this.comboBox2.Location = new System.Drawing.Point(92, 141);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 20);
            this.comboBox2.TabIndex = 61;
            this.comboBox2.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "图表深度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(90, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "读值频率(Hz)";
            // 
            // txGet
            // 
            this.txGet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txGet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txGet.Location = new System.Drawing.Point(2, 168);
            this.txGet.Multiline = true;
            this.txGet.Name = "txGet";
            this.txGet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txGet.Size = new System.Drawing.Size(377, 465);
            this.txGet.TabIndex = 64;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label26, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label27, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label28, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label29, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.label30, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.label31, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.label32, 5, 8);
            this.tableLayoutPanel1.Controls.Add(this.label33, 5, 9);
            this.tableLayoutPanel1.Controls.Add(this.label34, 5, 10);
            this.tableLayoutPanel1.Controls.Add(this.label35, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.label37, 5, 12);
            this.tableLayoutPanel1.Controls.Add(this.label39, 5, 13);
            this.tableLayoutPanel1.Controls.Add(this.label38, 5, 14);
            this.tableLayoutPanel1.Controls.Add(this.label36, 5, 15);
            this.tableLayoutPanel1.Controls.Add(this.label42, 5, 16);
            this.tableLayoutPanel1.Controls.Add(this.label40, 5, 17);
            this.tableLayoutPanel1.Controls.Add(this.label41, 5, 18);
            this.tableLayoutPanel1.Controls.Add(this.label43, 5, 19);
            this.tableLayoutPanel1.Controls.Add(this.label48, 5, 20);
            this.tableLayoutPanel1.Controls.Add(this.label47, 5, 21);
            this.tableLayoutPanel1.Controls.Add(this.cb_com_typeab, 4, 22);
            this.tableLayoutPanel1.Controls.Add(this.cb_ch_mod, 1, 20);
            this.tableLayoutPanel1.Controls.Add(this.label52, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.tb_smecid_read, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label53, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tb_key_val, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button2, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.button12, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button10, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.button8, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tb_read_num, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.tb_num, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(409, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 23;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 630);
            this.tableLayoutPanel1.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(142, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "0-35";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "<0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(218, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = ">35";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(278, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "-20~-10";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "湿度订正";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(342, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "1M";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(342, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 12);
            this.label26.TabIndex = 1;
            this.label26.Text = "2M";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(342, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 12);
            this.label27.TabIndex = 1;
            this.label27.Text = "3M";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(342, 108);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 1;
            this.label28.Text = "4M";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(342, 135);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 1;
            this.label29.Text = "5M";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(342, 162);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 1;
            this.label30.Text = "6M";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(342, 189);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 1;
            this.label31.Text = "7M";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(342, 216);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(17, 12);
            this.label32.TabIndex = 1;
            this.label32.Text = "8M";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(342, 243);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 12);
            this.label33.TabIndex = 1;
            this.label33.Text = "9M";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(342, 270);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(23, 12);
            this.label34.TabIndex = 1;
            this.label34.Text = "10M";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(342, 297);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 12);
            this.label35.TabIndex = 1;
            this.label35.Text = "11M";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(342, 324);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(23, 12);
            this.label37.TabIndex = 15;
            this.label37.Text = "12M";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(342, 351);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(23, 12);
            this.label39.TabIndex = 17;
            this.label39.Text = "13M";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(342, 378);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(23, 12);
            this.label38.TabIndex = 16;
            this.label38.Text = "14M";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(342, 405);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 12);
            this.label36.TabIndex = 14;
            this.label36.Text = "15M";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(342, 432);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(23, 12);
            this.label42.TabIndex = 20;
            this.label42.Text = "16M";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(342, 459);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(23, 12);
            this.label40.TabIndex = 18;
            this.label40.Text = "17M";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(342, 486);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(23, 12);
            this.label41.TabIndex = 19;
            this.label41.Text = "18M";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(342, 513);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(23, 12);
            this.label43.TabIndex = 21;
            this.label43.Text = "19M";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(342, 540);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(23, 12);
            this.label48.TabIndex = 26;
            this.label48.Text = "20M";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(342, 567);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(23, 12);
            this.label47.TabIndex = 25;
            this.label47.Text = "21M";
            // 
            // cb_com_typeab
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cb_com_typeab, 2);
            this.cb_com_typeab.FormattingEnabled = true;
            this.cb_com_typeab.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cb_com_typeab.Location = new System.Drawing.Point(278, 597);
            this.cb_com_typeab.Name = "cb_com_typeab";
            this.cb_com_typeab.Size = new System.Drawing.Size(66, 20);
            this.cb_com_typeab.TabIndex = 29;
            this.cb_com_typeab.Visible = false;
            // 
            // cb_ch_mod
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cb_ch_mod, 2);
            this.cb_ch_mod.FormattingEnabled = true;
            this.cb_ch_mod.Items.AddRange(new object[] {
            "12K_30K_40K",
            "12K_30K",
            "30K_41K",
            "12K_41K",
            "12K",
            "30K",
            "41K"});
            this.cb_ch_mod.Location = new System.Drawing.Point(83, 543);
            this.cb_ch_mod.Name = "cb_ch_mod";
            this.cb_ch_mod.Size = new System.Drawing.Size(127, 20);
            this.cb_ch_mod.TabIndex = 28;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(3, 540);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(53, 12);
            this.label52.TabIndex = 31;
            this.label52.Text = "工作通道";
            // 
            // tb_smecid_read
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_smecid_read, 2);
            this.tb_smecid_read.Location = new System.Drawing.Point(83, 57);
            this.tb_smecid_read.Name = "tb_smecid_read";
            this.tb_smecid_read.Size = new System.Drawing.Size(129, 21);
            this.tb_smecid_read.TabIndex = 33;
            this.tb_smecid_read.Text = "10001";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 32;
            this.label15.Text = "读出ID";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(3, 81);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 12);
            this.label53.TabIndex = 32;
            this.label53.Text = "写入ID";
            // 
            // tb_key_val
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_key_val, 2);
            this.tb_key_val.Location = new System.Drawing.Point(83, 84);
            this.tb_key_val.Name = "tb_key_val";
            this.tb_key_val.Size = new System.Drawing.Size(127, 21);
            this.tb_key_val.TabIndex = 33;
            this.tb_key_val.Text = "10001";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "减";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(142, 111);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(53, 21);
            this.button12.TabIndex = 2;
            this.button12.Text = "加";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(83, 111);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 21);
            this.button10.TabIndex = 2;
            this.button10.Text = "写ID";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 111);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 21);
            this.button9.TabIndex = 2;
            this.button9.Text = "读取";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 192);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 21);
            this.button4.TabIndex = 2;
            this.button4.Text = "读取头";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 219);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(74, 21);
            this.button7.TabIndex = 2;
            this.button7.Text = "读取全部";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(3, 246);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(74, 21);
            this.button8.TabIndex = 2;
            this.button8.Text = "读取单帧";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tb_read_num
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_read_num, 2);
            this.tb_read_num.Location = new System.Drawing.Point(83, 246);
            this.tb_read_num.Name = "tb_read_num";
            this.tb_read_num.Size = new System.Drawing.Size(127, 21);
            this.tb_read_num.TabIndex = 34;
            this.tb_read_num.Text = "0";
            // 
            // tb_num
            // 
            this.tb_num.Location = new System.Drawing.Point(83, 192);
            this.tb_num.Name = "tb_num";
            this.tb_num.Size = new System.Drawing.Size(53, 21);
            this.tb_num.TabIndex = 34;
            this.tb_num.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1167, 679);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txGet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PushbuttonState_lbl);
            this.Controls.Add(this.ANxVoltage_lbl);
            this.Controls.Add(this.StatusBox_lbl);
            this.Controls.Add(this.StatusBox_txtbx);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STM32开发板测试程序 V1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ANxVoltage_lbl;
        private System.Windows.Forms.Label StatusBox_lbl;
        private System.Windows.Forms.TextBox StatusBox_txtbx;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker ReadWriteThread;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.ToolTip ANxVoltageToolTip;
        private System.Windows.Forms.ToolTip ToggleLEDToolTip;
        private System.Windows.Forms.ToolTip PushbuttonStateTooltip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label PushbuttonState_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txGet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cb_com_typeab;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cb_ch_mod;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox tb_key_val;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox tb_smecid_read;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tb_read_num;
        private System.Windows.Forms.TextBox tb_num;
    }
}

