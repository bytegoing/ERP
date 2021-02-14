namespace 进销存管理系统.进销存
{
    partial class InForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InForm));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.warehouseNoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.goodNoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typeText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reasonText = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.inCountText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inSinglePriceText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inTotalPriceText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.businessUnitNoText = new System.Windows.Forms.TextBox();
            this.businessUnitLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodNameText = new System.Windows.Forms.TextBox();
            this.warehouseNameText = new System.Windows.Forms.TextBox();
            this.businessUnitNameText = new System.Windows.Forms.TextBox();
            this.findGoodBtn = new System.Windows.Forms.Button();
            this.findWarehouseBtn = new System.Windows.Forms.Button();
            this.findBusinessUnitBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
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
            // warehouseNoText
            // 
            this.warehouseNoText.Enabled = false;
            this.warehouseNoText.Location = new System.Drawing.Point(422, 49);
            this.warehouseNoText.Name = "warehouseNoText";
            this.warehouseNoText.Size = new System.Drawing.Size(62, 25);
            this.warehouseNoText.TabIndex = 9;
            this.warehouseNoText.TextChanged += new System.EventHandler(this.WarehouseNoText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "仓库";
            // 
            // goodNoText
            // 
            this.goodNoText.Enabled = false;
            this.goodNoText.Location = new System.Drawing.Point(84, 50);
            this.goodNoText.Name = "goodNoText";
            this.goodNoText.Size = new System.Drawing.Size(69, 25);
            this.goodNoText.TabIndex = 7;
            this.goodNoText.TextChanged += new System.EventHandler(this.GoodNoText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "商品";
            // 
            // typeText
            // 
            this.typeText.Enabled = false;
            this.typeText.Location = new System.Drawing.Point(84, 91);
            this.typeText.Name = "typeText";
            this.typeText.Size = new System.Drawing.Size(125, 25);
            this.typeText.TabIndex = 11;
            this.typeText.TextChanged += new System.EventHandler(this.TypeText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "类型";
            // 
            // reasonText
            // 
            this.reasonText.Location = new System.Drawing.Point(330, 92);
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(125, 25);
            this.reasonText.TabIndex = 13;
            this.reasonText.Visible = false;
            this.reasonText.TextChanged += new System.EventHandler(this.ReasonText_TextChanged);
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(257, 97);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(37, 15);
            this.reasonLabel.TabIndex = 12;
            this.reasonLabel.Text = "原因";
            this.reasonLabel.Visible = false;
            // 
            // inCountText
            // 
            this.inCountText.Location = new System.Drawing.Point(84, 135);
            this.inCountText.Name = "inCountText";
            this.inCountText.Size = new System.Drawing.Size(125, 25);
            this.inCountText.TabIndex = 15;
            this.inCountText.TextChanged += new System.EventHandler(this.InCountText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "入库数量";
            // 
            // inSinglePriceText
            // 
            this.inSinglePriceText.Location = new System.Drawing.Point(330, 136);
            this.inSinglePriceText.Name = "inSinglePriceText";
            this.inSinglePriceText.Size = new System.Drawing.Size(125, 25);
            this.inSinglePriceText.TabIndex = 17;
            this.inSinglePriceText.TextChanged += new System.EventHandler(this.InSinglePriceText_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "入库单价";
            // 
            // inTotalPriceText
            // 
            this.inTotalPriceText.Enabled = false;
            this.inTotalPriceText.Location = new System.Drawing.Point(571, 137);
            this.inTotalPriceText.Name = "inTotalPriceText";
            this.inTotalPriceText.Size = new System.Drawing.Size(125, 25);
            this.inTotalPriceText.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(498, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "入库总价";
            // 
            // businessUnitNoText
            // 
            this.businessUnitNoText.Enabled = false;
            this.businessUnitNoText.Location = new System.Drawing.Point(114, 200);
            this.businessUnitNoText.Name = "businessUnitNoText";
            this.businessUnitNoText.Size = new System.Drawing.Size(69, 25);
            this.businessUnitNoText.TabIndex = 21;
            this.businessUnitNoText.Text = "-1";
            this.businessUnitNoText.TextChanged += new System.EventHandler(this.BusinessUnitNoText_TextChanged);
            // 
            // businessUnitLabel
            // 
            this.businessUnitLabel.AutoSize = true;
            this.businessUnitLabel.Location = new System.Drawing.Point(11, 205);
            this.businessUnitLabel.Name = "businessUnitLabel";
            this.businessUnitLabel.Size = new System.Drawing.Size(97, 15);
            this.businessUnitLabel.TabIndex = 20;
            this.businessUnitLabel.Text = "往来单位编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "业务发生日期";
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM-dd";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(496, 200);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 25);
            this.date.TabIndex = 23;
            this.date.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(717, 28);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.保存SToolStripMenuItem.Text = "保存 (&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // goodNameText
            // 
            this.goodNameText.Enabled = false;
            this.goodNameText.Location = new System.Drawing.Point(159, 50);
            this.goodNameText.Name = "goodNameText";
            this.goodNameText.Size = new System.Drawing.Size(135, 25);
            this.goodNameText.TabIndex = 25;
            // 
            // warehouseNameText
            // 
            this.warehouseNameText.Enabled = false;
            this.warehouseNameText.Location = new System.Drawing.Point(490, 49);
            this.warehouseNameText.Name = "warehouseNameText";
            this.warehouseNameText.Size = new System.Drawing.Size(140, 25);
            this.warehouseNameText.TabIndex = 26;
            // 
            // businessUnitNameText
            // 
            this.businessUnitNameText.Enabled = false;
            this.businessUnitNameText.Location = new System.Drawing.Point(189, 200);
            this.businessUnitNameText.Name = "businessUnitNameText";
            this.businessUnitNameText.Size = new System.Drawing.Size(149, 25);
            this.businessUnitNameText.TabIndex = 27;
            // 
            // findGoodBtn
            // 
            this.findGoodBtn.Location = new System.Drawing.Point(300, 51);
            this.findGoodBtn.Name = "findGoodBtn";
            this.findGoodBtn.Size = new System.Drawing.Size(23, 23);
            this.findGoodBtn.TabIndex = 28;
            this.findGoodBtn.Text = "...";
            this.findGoodBtn.UseVisualStyleBackColor = true;
            this.findGoodBtn.Click += new System.EventHandler(this.FindGoodBtn_Click);
            // 
            // findWarehouseBtn
            // 
            this.findWarehouseBtn.Location = new System.Drawing.Point(636, 51);
            this.findWarehouseBtn.Name = "findWarehouseBtn";
            this.findWarehouseBtn.Size = new System.Drawing.Size(23, 23);
            this.findWarehouseBtn.TabIndex = 29;
            this.findWarehouseBtn.Text = "...";
            this.findWarehouseBtn.UseVisualStyleBackColor = true;
            this.findWarehouseBtn.Click += new System.EventHandler(this.FindWarehouseBtn_Click);
            // 
            // findBusinessUnitBtn
            // 
            this.findBusinessUnitBtn.Location = new System.Drawing.Point(344, 201);
            this.findBusinessUnitBtn.Name = "findBusinessUnitBtn";
            this.findBusinessUnitBtn.Size = new System.Drawing.Size(23, 23);
            this.findBusinessUnitBtn.TabIndex = 30;
            this.findBusinessUnitBtn.Text = "...";
            this.findBusinessUnitBtn.UseVisualStyleBackColor = true;
            this.findBusinessUnitBtn.Click += new System.EventHandler(this.FindBusinessUnitBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(10, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(676, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "入库数量仅支持整数,入库单价仅支持小数点后两位.超过部分自动截除!请务必注意上方自动计算总价";
            // 
            // InForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 247);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.findBusinessUnitBtn);
            this.Controls.Add(this.findWarehouseBtn);
            this.Controls.Add(this.findGoodBtn);
            this.Controls.Add(this.businessUnitNameText);
            this.Controls.Add(this.warehouseNameText);
            this.Controls.Add(this.goodNameText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.businessUnitNoText);
            this.Controls.Add(this.businessUnitLabel);
            this.Controls.Add(this.inTotalPriceText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inSinglePriceText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inCountText);
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
            this.Name = "InForm";
            this.Text = "入库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InForm_FormClosing);
            this.Load += new System.EventHandler(this.InForm_Load);
            this.Shown += new System.EventHandler(this.InForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox typeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.TextBox inCountText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inSinglePriceText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inTotalPriceText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label businessUnitLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.Button findGoodBtn;
        private System.Windows.Forms.Button findWarehouseBtn;
        private System.Windows.Forms.Button findBusinessUnitBtn;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox warehouseNoText;
        public System.Windows.Forms.TextBox goodNoText;
        public System.Windows.Forms.TextBox businessUnitNoText;
        public System.Windows.Forms.TextBox goodNameText;
        public System.Windows.Forms.TextBox warehouseNameText;
        public System.Windows.Forms.TextBox businessUnitNameText;
    }
}