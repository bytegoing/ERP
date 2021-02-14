namespace 进销存管理系统.统计与报表
{
    partial class JinHuoTongJi
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JinHuoTongJi));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toMonthText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toYearText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromMonthText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromYearText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品类别进货饼图SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供应商进货统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.导出目前图片YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "注：时间跨度最多六个月,每项取前三名,进货统计会自动将退货数据扣除";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(422, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "注：若想查询某个年度整个n月份的统计数据,此处应输入n+1月";
            // 
            // toMonthText
            // 
            this.toMonthText.Location = new System.Drawing.Point(580, 60);
            this.toMonthText.Name = "toMonthText";
            this.toMonthText.Size = new System.Drawing.Size(100, 25);
            this.toMonthText.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "月份 (不包括本月)";
            // 
            // toYearText
            // 
            this.toYearText.Location = new System.Drawing.Point(431, 60);
            this.toYearText.Name = "toYearText";
            this.toYearText.Size = new System.Drawing.Size(100, 25);
            this.toYearText.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "年度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "到";
            // 
            // fromMonthText
            // 
            this.fromMonthText.Location = new System.Drawing.Point(168, 60);
            this.fromMonthText.Name = "fromMonthText";
            this.fromMonthText.Size = new System.Drawing.Size(100, 25);
            this.fromMonthText.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "月份";
            // 
            // fromYearText
            // 
            this.fromYearText.Location = new System.Drawing.Point(19, 60);
            this.fromYearText.Name = "fromYearText";
            this.fromYearText.Size = new System.Drawing.Size(100, 25);
            this.fromYearText.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "年度";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询SToolStripMenuItem,
            this.商品类别进货饼图SToolStripMenuItem,
            this.供应商进货统计ToolStripMenuItem,
            this.导出目前图片YToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 28);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询SToolStripMenuItem
            // 
            this.查询SToolStripMenuItem.Name = "查询SToolStripMenuItem";
            this.查询SToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.查询SToolStripMenuItem.Text = "总商品进货量月表 (&A)";
            this.查询SToolStripMenuItem.Click += new System.EventHandler(this.查询SToolStripMenuItem_Click);
            // 
            // 商品类别进货饼图SToolStripMenuItem
            // 
            this.商品类别进货饼图SToolStripMenuItem.Name = "商品类别进货饼图SToolStripMenuItem";
            this.商品类别进货饼图SToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.商品类别进货饼图SToolStripMenuItem.Text = "商品类别进货量月表 (&S)";
            this.商品类别进货饼图SToolStripMenuItem.Click += new System.EventHandler(this.商品类别进货饼图SToolStripMenuItem_Click);
            // 
            // 供应商进货统计ToolStripMenuItem
            // 
            this.供应商进货统计ToolStripMenuItem.Name = "供应商进货统计ToolStripMenuItem";
            this.供应商进货统计ToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.供应商进货统计ToolStripMenuItem.Text = "供应商进货量统计月表 (&D)";
            this.供应商进货统计ToolStripMenuItem.Click += new System.EventHandler(this.供应商进货统计ToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 97);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Label = "#VAL";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(888, 403);
            this.chart1.TabIndex = 24;
            this.chart1.Text = "chart1";
            // 
            // 导出目前图片YToolStripMenuItem
            // 
            this.导出目前图片YToolStripMenuItem.Name = "导出目前图片YToolStripMenuItem";
            this.导出目前图片YToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.导出目前图片YToolStripMenuItem.Text = "导出目前图片 (&Y)";
            this.导出目前图片YToolStripMenuItem.Click += new System.EventHandler(this.导出目前图片YToolStripMenuItem_Click);
            // 
            // JinHuoTongJi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 530);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toMonthText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toYearText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromMonthText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromYearText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JinHuoTongJi";
            this.Text = "进货统计与分析";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox toMonthText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox toYearText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fromMonthText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromYearText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem 供应商进货统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品类别进货饼图SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出目前图片YToolStripMenuItem;
    }
}