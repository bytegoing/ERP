namespace 进销存管理系统.进销存
{
    partial class OutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutForm));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.label9 = new System.Windows.Forms.Label();
            this.findWarehouseBtn = new System.Windows.Forms.Button();
            this.findGoodBtn = new System.Windows.Forms.Button();
            this.businessUnitNameText = new System.Windows.Forms.TextBox();
            this.warehouseNameText = new System.Windows.Forms.TextBox();
            this.goodNameText = new System.Windows.Forms.TextBox();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findBusinessUnitBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.businessUnitNoText = new System.Windows.Forms.TextBox();
            this.businessUnitLabel = new System.Windows.Forms.Label();
            this.outTotalPriceText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.outSinglePriceText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.outCountText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reasonText = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.typeText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.warehouseNoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.goodNoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(18, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(676, 15);
            this.label9.TabIndex = 57;
            this.label9.Text = "出库数量仅支持整数,出库单价仅支持小数点后两位.超过部分自动截除!请务必注意上方自动计算总价";
            // 
            // findWarehouseBtn
            // 
            this.findWarehouseBtn.Location = new System.Drawing.Point(644, 46);
            this.findWarehouseBtn.Name = "findWarehouseBtn";
            this.findWarehouseBtn.Size = new System.Drawing.Size(23, 23);
            this.findWarehouseBtn.TabIndex = 55;
            this.findWarehouseBtn.Text = "...";
            this.findWarehouseBtn.UseVisualStyleBackColor = true;
            this.findWarehouseBtn.Click += new System.EventHandler(this.FindWarehouseBtn_Click);
            // 
            // findGoodBtn
            // 
            this.findGoodBtn.Location = new System.Drawing.Point(308, 46);
            this.findGoodBtn.Name = "findGoodBtn";
            this.findGoodBtn.Size = new System.Drawing.Size(23, 23);
            this.findGoodBtn.TabIndex = 54;
            this.findGoodBtn.Text = "...";
            this.findGoodBtn.UseVisualStyleBackColor = true;
            this.findGoodBtn.Click += new System.EventHandler(this.FindGoodBtn_Click);
            // 
            // businessUnitNameText
            // 
            this.businessUnitNameText.Enabled = false;
            this.businessUnitNameText.Location = new System.Drawing.Point(197, 195);
            this.businessUnitNameText.Name = "businessUnitNameText";
            this.businessUnitNameText.Size = new System.Drawing.Size(149, 25);
            this.businessUnitNameText.TabIndex = 53;
            // 
            // warehouseNameText
            // 
            this.warehouseNameText.Enabled = false;
            this.warehouseNameText.Location = new System.Drawing.Point(498, 44);
            this.warehouseNameText.Name = "warehouseNameText";
            this.warehouseNameText.Size = new System.Drawing.Size(140, 25);
            this.warehouseNameText.TabIndex = 52;
            // 
            // goodNameText
            // 
            this.goodNameText.Enabled = false;
            this.goodNameText.Location = new System.Drawing.Point(167, 45);
            this.goodNameText.Name = "goodNameText";
            this.goodNameText.Size = new System.Drawing.Size(135, 25);
            this.goodNameText.TabIndex = 51;
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.保存SToolStripMenuItem.Text = "保存 (&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // findBusinessUnitBtn
            // 
            this.findBusinessUnitBtn.Location = new System.Drawing.Point(352, 196);
            this.findBusinessUnitBtn.Name = "findBusinessUnitBtn";
            this.findBusinessUnitBtn.Size = new System.Drawing.Size(23, 23);
            this.findBusinessUnitBtn.TabIndex = 56;
            this.findBusinessUnitBtn.Text = "...";
            this.findBusinessUnitBtn.UseVisualStyleBackColor = true;
            this.findBusinessUnitBtn.Click += new System.EventHandler(this.FindBusinessUnitBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存SToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 28);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM-dd";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(504, 195);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 25);
            this.date.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 48;
            this.label8.Text = "业务发生日期";
            // 
            // businessUnitNoText
            // 
            this.businessUnitNoText.Enabled = false;
            this.businessUnitNoText.Location = new System.Drawing.Point(122, 195);
            this.businessUnitNoText.Name = "businessUnitNoText";
            this.businessUnitNoText.Size = new System.Drawing.Size(69, 25);
            this.businessUnitNoText.TabIndex = 47;
            this.businessUnitNoText.Text = "-1";
            this.businessUnitNoText.TextChanged += new System.EventHandler(this.BusinessUnitNoText_TextChanged);
            // 
            // businessUnitLabel
            // 
            this.businessUnitLabel.AutoSize = true;
            this.businessUnitLabel.Location = new System.Drawing.Point(19, 200);
            this.businessUnitLabel.Name = "businessUnitLabel";
            this.businessUnitLabel.Size = new System.Drawing.Size(97, 15);
            this.businessUnitLabel.TabIndex = 46;
            this.businessUnitLabel.Text = "往来单位编号";
            // 
            // outTotalPriceText
            // 
            this.outTotalPriceText.Enabled = false;
            this.outTotalPriceText.Location = new System.Drawing.Point(579, 132);
            this.outTotalPriceText.Name = "outTotalPriceText";
            this.outTotalPriceText.Size = new System.Drawing.Size(125, 25);
            this.outTotalPriceText.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(506, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "出库总价";
            // 
            // outSinglePriceText
            // 
            this.outSinglePriceText.Location = new System.Drawing.Point(338, 131);
            this.outSinglePriceText.Name = "outSinglePriceText";
            this.outSinglePriceText.Size = new System.Drawing.Size(125, 25);
            this.outSinglePriceText.TabIndex = 43;
            this.outSinglePriceText.TextChanged += new System.EventHandler(this.OutSinglePriceText_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "出库单价";
            // 
            // outCountText
            // 
            this.outCountText.Location = new System.Drawing.Point(92, 130);
            this.outCountText.Name = "outCountText";
            this.outCountText.Size = new System.Drawing.Size(125, 25);
            this.outCountText.TabIndex = 41;
            this.outCountText.TextChanged += new System.EventHandler(this.OutCountText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "出库数量";
            // 
            // reasonText
            // 
            this.reasonText.Location = new System.Drawing.Point(338, 87);
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(125, 25);
            this.reasonText.TabIndex = 39;
            this.reasonText.Visible = false;
            this.reasonText.TextChanged += new System.EventHandler(this.ReasonText_TextChanged);
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(265, 92);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(37, 15);
            this.reasonLabel.TabIndex = 38;
            this.reasonLabel.Text = "原因";
            this.reasonLabel.Visible = false;
            // 
            // typeText
            // 
            this.typeText.Enabled = false;
            this.typeText.Location = new System.Drawing.Point(92, 86);
            this.typeText.Name = "typeText";
            this.typeText.Size = new System.Drawing.Size(125, 25);
            this.typeText.TabIndex = 37;
            this.typeText.TextChanged += new System.EventHandler(this.TypeText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "类型";
            // 
            // warehouseNoText
            // 
            this.warehouseNoText.Enabled = false;
            this.warehouseNoText.Location = new System.Drawing.Point(430, 44);
            this.warehouseNoText.Name = "warehouseNoText";
            this.warehouseNoText.Size = new System.Drawing.Size(62, 25);
            this.warehouseNoText.TabIndex = 35;
            this.warehouseNoText.TextChanged += new System.EventHandler(this.WarehouseNoText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "仓库";
            // 
            // goodNoText
            // 
            this.goodNoText.Enabled = false;
            this.goodNoText.Location = new System.Drawing.Point(92, 45);
            this.goodNoText.Name = "goodNoText";
            this.goodNoText.Size = new System.Drawing.Size(69, 25);
            this.goodNoText.TabIndex = 33;
            this.goodNoText.TextChanged += new System.EventHandler(this.GoodNoText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "商品";
            // 
            // OutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 240);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.findWarehouseBtn);
            this.Controls.Add(this.findGoodBtn);
            this.Controls.Add(this.businessUnitNameText);
            this.Controls.Add(this.warehouseNameText);
            this.Controls.Add(this.goodNameText);
            this.Controls.Add(this.findBusinessUnitBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.businessUnitNoText);
            this.Controls.Add(this.businessUnitLabel);
            this.Controls.Add(this.outTotalPriceText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.outSinglePriceText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outCountText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reasonText);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.typeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.warehouseNoText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goodNoText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OutForm";
            this.Text = "出库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutForm_FormClosing);
            this.Load += new System.EventHandler(this.OutForm_Load);
            this.Shown += new System.EventHandler(this.OutForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button findWarehouseBtn;
        private System.Windows.Forms.Button findGoodBtn;
        public System.Windows.Forms.TextBox businessUnitNameText;
        public System.Windows.Forms.TextBox warehouseNameText;
        public System.Windows.Forms.TextBox goodNameText;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.Button findBusinessUnitBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox businessUnitNoText;
        private System.Windows.Forms.Label businessUnitLabel;
        private System.Windows.Forms.TextBox outTotalPriceText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox outSinglePriceText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox outCountText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.TextBox typeText;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox warehouseNoText;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox goodNoText;
        private System.Windows.Forms.Label label1;
    }
}