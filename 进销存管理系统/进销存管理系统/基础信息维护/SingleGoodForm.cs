using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using 进销存管理系统.Common;
using 进销存管理系统.Models;
using 进销存管理系统.BLL;

namespace 进销存管理系统.基础信息维护
{
    public partial class SingleGoodForm : Form
    {
        bool ifChanged = false;
        public string OutterNo = ""; //从外部调用
        public Good Outter = null; //从外部调用

        public SingleGoodForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void SingleGoodForm_Load(object sender, EventArgs e)
        {
            if(OutterNo != string.Empty)
            {
                //将Good读入
                try
                {
                    Outter = new GoodManager().Get(OutterNo);
                }
                catch(Exception exp) {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close(); //[T]
                }
                noText.Text = Outter.No + "";
                nameText.Text = Outter.Name;
                packageText.Text = Outter.Package;
                unitCombo.Text = Outter.Unit;
                typeText.Text = Outter.Type + "";
                typeNameText.Text = Outter.TypeName;
                maxText.Text = Outter.MaxInventory + "";
                minText.Text = Outter.MinInventory + "";
                remarkText.Text = Outter.Remark;
            }
            ifChanged = false;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件
        }

        private void SingleGoodForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ifChanged)
            {
                if (MsgBox.ShowAsk("还未保存,确认不保存而退出吗?"))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void FindTypeBtn_Click(object sender, EventArgs e)
        {
            FindGoodTypeForm f = new FindGoodTypeForm();
            f.ShowDialog(this);
            typeText.Text = CommonData.buffer2str.Item1;
            typeNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ifChanged)
            {
                MsgBox.ShowInfo("无需保存!");
                return;
            }
            if(Outter != null)
            {
                //修改
                try
                {
                    new GoodManager().ChangeInfo(noText.Text, nameText.Text.Trim(), packageText.Text.Trim(), unitCombo.Text.Trim(), typeText.Text, maxText.Text, minText.Text, remarkText.Text);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("修改失败!错误: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("修改成功!");
                ifChanged = false;
            }
            else
            {
                //新建
                try
                {
                    new GoodManager().Add(nameText.Text.Trim(), packageText.Text.Trim(), unitCombo.Text.Trim(), typeText.Text, maxText.Text, minText.Text, remarkText.Text);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("新建失败!错误: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("新建成功!");
                ifChanged = false;
            }
        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void TypeText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void PackageText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void UnitCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void MinText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void MaxText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void RemarkText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
