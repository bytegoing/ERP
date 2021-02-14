namespace 进销存管理系统.进销存
{
    partial class StockQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockQuery));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.findBtn = new System.Windows.Forms.Button();
            this.warehouseNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.goodTypeText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.goodNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.exportBtn = new System.Windows.Forms.Button();
            this.findGoodBtn = new System.Windows.Forms.Button();
            this.findGoodTypeBtn = new System.Windows.Forms.Button();
            this.findWarehouseNameBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.findWarehouseNameBtn);
            this.groupBox1.Controls.Add(this.findGoodTypeBtn);
            this.groupBox1.Controls.Add(this.findGoodBtn);
            this.groupBox1.Controls.Add(this.exportBtn);
            this.groupBox1.Controls.Add(this.exitBtn);
            this.groupBox1.Controls.Add(this.findBtn);
            this.groupBox1.Controls.Add(this.warehouseNameText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.goodTypeText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.goodNameText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(993, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(912, 21);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 28);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(667, 23);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 28);
            this.findBtn.TabIndex = 8;
            this.findBtn.Text = "查找";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // warehouseNameText
            // 
            this.warehouseNameText.Location = new System.Drawing.Point(524, 23);
            this.warehouseNameText.Name = "warehouseNameText";
            this.warehouseNameText.Size = new System.Drawing.Size(113, 25);
            this.warehouseNameText.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "仓库名称";
            // 
            // goodTypeText
            // 
            this.goodTypeText.Location = new System.Drawing.Point(307, 23);
            this.goodTypeText.Name = "goodTypeText";
            this.goodTypeText.Size = new System.Drawing.Size(116, 25);
            this.goodTypeText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "商品类别";
            // 
            // goodNameText
            // 
            this.goodNameText.Location = new System.Drawing.Point(79, 23);
            this.goodNameText.Name = "goodNameText";
            this.goodNameText.Size = new System.Drawing.Size(125, 25);
            this.goodNameText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名称";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(993, 437);
            this.dataGridView1.TabIndex = 1;
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
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(748, 21);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(158, 29);
            this.exportBtn.TabIndex = 10;
            this.exportBtn.Text = "导出当前表格数据";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // findGoodBtn
            // 
            this.findGoodBtn.Location = new System.Drawing.Point(206, 25);
            this.findGoodBtn.Name = "findGoodBtn";
            this.findGoodBtn.Size = new System.Drawing.Size(22, 21);
            this.findGoodBtn.TabIndex = 11;
            this.findGoodBtn.Text = "...";
            this.findGoodBtn.UseVisualStyleBackColor = true;
            this.findGoodBtn.Click += new System.EventHandler(this.FindGoodBtn_Click);
            // 
            // findGoodTypeBtn
            // 
            this.findGoodTypeBtn.Location = new System.Drawing.Point(426, 26);
            this.findGoodTypeBtn.Name = "findGoodTypeBtn";
            this.findGoodTypeBtn.Size = new System.Drawing.Size(22, 21);
            this.findGoodTypeBtn.TabIndex = 12;
            this.findGoodTypeBtn.Text = "...";
            this.findGoodTypeBtn.UseVisualStyleBackColor = true;
            this.findGoodTypeBtn.Click += new System.EventHandler(this.FindGoodTypeBtn_Click);
            // 
            // findWarehouseNameBtn
            // 
            this.findWarehouseNameBtn.Location = new System.Drawing.Point(639, 25);
            this.findWarehouseNameBtn.Name = "findWarehouseNameBtn";
            this.findWarehouseNameBtn.Size = new System.Drawing.Size(22, 21);
            this.findWarehouseNameBtn.TabIndex = 12;
            this.findWarehouseNameBtn.Text = "...";
            this.findWarehouseNameBtn.UseVisualStyleBackColor = true;
            this.findWarehouseNameBtn.Click += new System.EventHandler(this.FindWarehouseNameBtn_Click);
            // 
            // StockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 529);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockQuery";
            this.Text = "当前库存查询";
            this.Load += new System.EventHandler(this.Record_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox goodTypeText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox goodNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox warehouseNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button findBtn;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button findWarehouseNameBtn;
        private System.Windows.Forms.Button findGoodTypeBtn;
        private System.Windows.Forms.Button findGoodBtn;
    }
}