namespace 进销存管理系统.基础信息维护
{
    partial class GoodTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodTypeForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.增加AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numberText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.parentText = new System.Windows.Forms.TextBox();
            this.tipText = new System.Windows.Forms.TextBox();
            this.parentNameText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(248, 442);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加AToolStripMenuItem,
            this.修改SToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 增加AToolStripMenuItem
            // 
            this.增加AToolStripMenuItem.Name = "增加AToolStripMenuItem";
            this.增加AToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.增加AToolStripMenuItem.Text = "增加";
            this.增加AToolStripMenuItem.Click += new System.EventHandler(this.增加AToolStripMenuItem_Click);
            // 
            // 修改SToolStripMenuItem
            // 
            this.修改SToolStripMenuItem.Name = "修改SToolStripMenuItem";
            this.修改SToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.修改SToolStripMenuItem.Text = "修改";
            this.修改SToolStripMenuItem.Click += new System.EventHandler(this.修改SToolStripMenuItem_Click);
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.删除DToolStripMenuItem.Text = "删除";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(270, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "父类编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(270, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "编    号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(270, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "类别名称";
            // 
            // numberText
            // 
            this.numberText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numberText.Location = new System.Drawing.Point(383, 240);
            this.numberText.Name = "numberText";
            this.numberText.ReadOnly = true;
            this.numberText.Size = new System.Drawing.Size(152, 30);
            this.numberText.TabIndex = 6;
            // 
            // nameText
            // 
            this.nameText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameText.Location = new System.Drawing.Point(383, 284);
            this.nameText.Name = "nameText";
            this.nameText.ReadOnly = true;
            this.nameText.Size = new System.Drawing.Size(152, 30);
            this.nameText.TabIndex = 7;
            // 
            // parentText
            // 
            this.parentText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.parentText.Location = new System.Drawing.Point(383, 157);
            this.parentText.Name = "parentText";
            this.parentText.ReadOnly = true;
            this.parentText.Size = new System.Drawing.Size(152, 30);
            this.parentText.TabIndex = 5;
            // 
            // tipText
            // 
            this.tipText.Location = new System.Drawing.Point(274, 41);
            this.tipText.Multiline = true;
            this.tipText.Name = "tipText";
            this.tipText.ReadOnly = true;
            this.tipText.Size = new System.Drawing.Size(261, 97);
            this.tipText.TabIndex = 8;
            // 
            // parentNameText
            // 
            this.parentNameText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.parentNameText.Location = new System.Drawing.Point(383, 201);
            this.parentNameText.Name = "parentNameText";
            this.parentNameText.ReadOnly = true;
            this.parentNameText.Size = new System.Drawing.Size(152, 30);
            this.parentNameText.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(270, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "父类名称";
            // 
            // GoodTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 470);
            this.Controls.Add(this.parentNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.numberText);
            this.Controls.Add(this.parentText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GoodTypeForm";
            this.Text = "商品类别维护";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoodType_FormClosing);
            this.Load += new System.EventHandler(this.GoodType_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox parentText;
        private System.Windows.Forms.TextBox tipText;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.TextBox parentNameText;
        private System.Windows.Forms.Label label4;
    }
}