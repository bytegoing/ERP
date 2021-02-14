namespace 进销存管理系统.基础信息维护
{
    partial class SingleGoodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleGoodForm));
            this.label1 = new System.Windows.Forms.Label();
            this.noText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.packageText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.unitCombo = new System.Windows.Forms.ComboBox();
            this.minText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maxText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.typeText = new System.Windows.Forms.TextBox();
            this.findTypeBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.remarkText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.typeNameText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品编号";
            // 
            // noText
            // 
            this.noText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.noText.Location = new System.Drawing.Point(118, 43);
            this.noText.Name = "noText";
            this.noText.ReadOnly = true;
            this.noText.Size = new System.Drawing.Size(253, 30);
            this.noText.TabIndex = 1;
            // 
            // nameText
            // 
            this.nameText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameText.Location = new System.Drawing.Point(118, 86);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(253, 30);
            this.nameText.TabIndex = 2;
            this.nameText.TextChanged += new System.EventHandler(this.NameText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "*商品名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "商品规格";
            // 
            // packageText
            // 
            this.packageText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.packageText.Location = new System.Drawing.Point(118, 165);
            this.packageText.Name = "packageText";
            this.packageText.Size = new System.Drawing.Size(126, 30);
            this.packageText.TabIndex = 5;
            this.packageText.TextChanged += new System.EventHandler(this.PackageText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(250, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "例:250g,500ml等";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "商品单位";
            // 
            // unitCombo
            // 
            this.unitCombo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unitCombo.FormattingEnabled = true;
            this.unitCombo.Items.AddRange(new object[] {
            "个",
            "袋",
            "箱",
            "瓶"});
            this.unitCombo.Location = new System.Drawing.Point(118, 207);
            this.unitCombo.Name = "unitCombo";
            this.unitCombo.Size = new System.Drawing.Size(126, 28);
            this.unitCombo.TabIndex = 8;
            this.unitCombo.SelectedIndexChanged += new System.EventHandler(this.UnitCombo_SelectedIndexChanged);
            // 
            // minText
            // 
            this.minText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minText.Location = new System.Drawing.Point(118, 253);
            this.minText.Name = "minText";
            this.minText.Size = new System.Drawing.Size(79, 30);
            this.minText.TabIndex = 10;
            this.minText.TextChanged += new System.EventHandler(this.MinText_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "最小库存";
            // 
            // maxText
            // 
            this.maxText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maxText.Location = new System.Drawing.Point(315, 253);
            this.maxText.Name = "maxText";
            this.maxText.Size = new System.Drawing.Size(79, 30);
            this.maxText.TabIndex = 12;
            this.maxText.TextChanged += new System.EventHandler(this.MaxText_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(211, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "最大库存";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "*所属类别";
            // 
            // typeText
            // 
            this.typeText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeText.Location = new System.Drawing.Point(118, 128);
            this.typeText.Name = "typeText";
            this.typeText.ReadOnly = true;
            this.typeText.Size = new System.Drawing.Size(60, 30);
            this.typeText.TabIndex = 14;
            this.typeText.TextChanged += new System.EventHandler(this.TypeText_TextChanged);
            // 
            // findTypeBtn
            // 
            this.findTypeBtn.Location = new System.Drawing.Point(335, 126);
            this.findTypeBtn.Name = "findTypeBtn";
            this.findTypeBtn.Size = new System.Drawing.Size(36, 32);
            this.findTypeBtn.TabIndex = 15;
            this.findTypeBtn.Text = "..";
            this.findTypeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.findTypeBtn.UseVisualStyleBackColor = true;
            this.findTypeBtn.Click += new System.EventHandler(this.FindTypeBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "备注(限100字)";
            // 
            // remarkText
            // 
            this.remarkText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.remarkText.Location = new System.Drawing.Point(16, 324);
            this.remarkText.Multiline = true;
            this.remarkText.Name = "remarkText";
            this.remarkText.Size = new System.Drawing.Size(378, 163);
            this.remarkText.TabIndex = 17;
            this.remarkText.TextChanged += new System.EventHandler(this.RemarkText_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(211, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "留空或为0即不限制";
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
            this.menuStrip1.Size = new System.Drawing.Size(420, 28);
            this.menuStrip1.TabIndex = 19;
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
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // typeNameText
            // 
            this.typeNameText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeNameText.Location = new System.Drawing.Point(184, 128);
            this.typeNameText.Name = "typeNameText";
            this.typeNameText.ReadOnly = true;
            this.typeNameText.Size = new System.Drawing.Size(145, 30);
            this.typeNameText.TabIndex = 20;
            // 
            // SingleGoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 505);
            this.Controls.Add(this.typeNameText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.remarkText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.findTypeBtn);
            this.Controls.Add(this.typeText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.unitCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.packageText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.noText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SingleGoodForm";
            this.Text = "单项商品管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleGoodForm_FormClosing);
            this.Load += new System.EventHandler(this.SingleGoodForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox packageText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox unitCombo;
        private System.Windows.Forms.TextBox minText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox maxText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button findTypeBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox remarkText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.TextBox typeText;
        private System.Windows.Forms.TextBox typeNameText;
    }
}