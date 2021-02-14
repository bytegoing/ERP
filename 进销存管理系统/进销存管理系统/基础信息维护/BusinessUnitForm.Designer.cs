namespace 进销存管理系统.基础信息维护
{
    partial class BusinessUnitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessUnitForm));
            this.findText = new System.Windows.Forms.TextBox();
            this.queryBtn = new System.Windows.Forms.Button();
            this.conditionCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.导出YToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findText
            // 
            this.findText.Location = new System.Drawing.Point(262, 47);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(258, 25);
            this.findText.TabIndex = 30;
            // 
            // queryBtn
            // 
            this.queryBtn.Location = new System.Drawing.Point(526, 44);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(77, 31);
            this.queryBtn.TabIndex = 28;
            this.queryBtn.Text = "查询";
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // conditionCombo
            // 
            this.conditionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionCombo.FormattingEnabled = true;
            this.conditionCombo.Items.AddRange(new object[] {
            "不筛选",
            "名称",
            "联系人姓名"});
            this.conditionCombo.Location = new System.Drawing.Point(96, 48);
            this.conditionCombo.Name = "conditionCombo";
            this.conditionCombo.Size = new System.Drawing.Size(145, 23);
            this.conditionCombo.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "查询字段: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 364);
            this.dataGridView1.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建AToolStripMenuItem,
            this.修改SToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.导出YToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建AToolStripMenuItem
            // 
            this.新建AToolStripMenuItem.Name = "新建AToolStripMenuItem";
            this.新建AToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.新建AToolStripMenuItem.Text = "新建 (&A)";
            this.新建AToolStripMenuItem.Click += new System.EventHandler(this.新建AToolStripMenuItem_Click);
            // 
            // 修改SToolStripMenuItem
            // 
            this.修改SToolStripMenuItem.Name = "修改SToolStripMenuItem";
            this.修改SToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.修改SToolStripMenuItem.Text = "修改 (&S)";
            this.修改SToolStripMenuItem.Click += new System.EventHandler(this.修改SToolStripMenuItem_Click);
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.删除DToolStripMenuItem.Text = "删除 (&D)";
            this.删除DToolStripMenuItem.Click += new System.EventHandler(this.删除DToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
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
            // 导出YToolStripMenuItem
            // 
            this.导出YToolStripMenuItem.Name = "导出YToolStripMenuItem";
            this.导出YToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.导出YToolStripMenuItem.Text = "导出当前表格数据 (&Y)";
            this.导出YToolStripMenuItem.Click += new System.EventHandler(this.导出YToolStripMenuItem_Click);
            // 
            // BusinessUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.findText);
            this.Controls.Add(this.queryBtn);
            this.Controls.Add(this.conditionCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BusinessUnitForm";
            this.Text = "往来单位信息维护";
            this.Load += new System.EventHandler(this.BusinessUnitForm_Load);
            this.Shown += new System.EventHandler(this.BusinessUnitForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.ComboBox conditionCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 导出YToolStripMenuItem;
    }
}