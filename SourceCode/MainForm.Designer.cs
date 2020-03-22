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
            this.tlpRightTop = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDataList = new System.Windows.Forms.DataGridView();
            this.pRightTopPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zgcChart = new ZedGraph.ZedGraphControl();
            this.CNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CZDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CQinJiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSJZT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).BeginInit();
            this.pRightTopPanel.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1214, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsimiFileExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(71, 24);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsimiFileExit
            // 
            this.tsimiFileExit.Name = "tsimiFileExit";
            this.tsimiFileExit.Size = new System.Drawing.Size(140, 26);
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
            this.tlpMain.Location = new System.Drawing.Point(0, 30);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1214, 939);
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
            this.tableLayoutPanel1.Controls.Add(this.lbTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btGenerateCurve, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btClearParam, 3, 4);
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
            this.tableLayoutPanel1.SetColumnSpan(this.btGenerateCurve, 2);
            this.btGenerateCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btGenerateCurve.Location = new System.Drawing.Point(115, 263);
            this.btGenerateCurve.Name = "btGenerateCurve";
            this.btGenerateCurve.Size = new System.Drawing.Size(217, 59);
            this.btGenerateCurve.TabIndex = 1;
            this.btGenerateCurve.Text = "生成曲线";
            this.btGenerateCurve.UseVisualStyleBackColor = true;
            this.btGenerateCurve.Click += new System.EventHandler(this.btGenerateCurve_Click);
            // 
            // btClearParam
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btClearParam, 2);
            this.btClearParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClearParam.Location = new System.Drawing.Point(338, 263);
            this.btClearParam.Name = "btClearParam";
            this.btClearParam.Size = new System.Drawing.Size(217, 59);
            this.btClearParam.TabIndex = 2;
            this.btClearParam.Text = "清除参数";
            this.btClearParam.UseVisualStyleBackColor = true;
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
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "地点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
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
            this.zgcChart.Size = new System.Drawing.Size(1206, 529);
            this.zgcChart.TabIndex = 2;
            this.zgcChart.UseExtendedPrintDialog = true;
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
            this.CTest.Width = 125;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 969);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
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
    }
}