namespace 进销存管理系统.统计与报表
{
    partial class YueXiaoShouZhuangKuang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YueXiaoShouZhuangKuang));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供应商进货统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.yearLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.导出目前图片YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询SToolStripMenuItem,
            this.供应商进货统计ToolStripMenuItem,
            this.导出目前图片YToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询SToolStripMenuItem
            // 
            this.查询SToolStripMenuItem.Name = "查询SToolStripMenuItem";
            this.查询SToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.查询SToolStripMenuItem.Text = "商品类别销售饼图 (&A)";
            this.查询SToolStripMenuItem.Click += new System.EventHandler(this.查询SToolStripMenuItem_Click);
            // 
            // 供应商进货统计ToolStripMenuItem
            // 
            this.供应商进货统计ToolStripMenuItem.Name = "供应商进货统计ToolStripMenuItem";
            this.供应商进货统计ToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.供应商进货统计ToolStripMenuItem.Text = "客户购买量饼图 (&S)";
            this.供应商进货统计ToolStripMenuItem.Click += new System.EventHandler(this.供应商进货统计ToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "注：不计入已经退货的销售数据";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 68);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Label = "#VALX #VAL";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 350);
            this.chart1.TabIndex = 33;
            this.chart1.Text = "chart1";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(15, 39);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(39, 15);
            this.yearLabel.TabIndex = 36;
            this.yearLabel.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "年度";
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(116, 39);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(23, 15);
            this.monthLabel.TabIndex = 38;
            this.monthLabel.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "月份统计数据";
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
            // 导出目前图片YToolStripMenuItem
            // 
            this.导出目前图片YToolStripMenuItem.Name = "导出目前图片YToolStripMenuItem";
            this.导出目前图片YToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.导出目前图片YToolStripMenuItem.Text = "导出目前图片 (&Y)";
            this.导出目前图片YToolStripMenuItem.Click += new System.EventHandler(this.导出目前图片YToolStripMenuItem_Click);
            // 
            // YueXiaoShouZhuangKuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YueXiaoShouZhuangKuang";
            this.Text = "本月销售状况";
            this.Load += new System.EventHandler(this.YueXiaoShouZhuangKuang_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 供应商进货统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label label4;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 导出目前图片YToolStripMenuItem;
    }
}