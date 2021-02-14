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
    public partial class SingleBusinessUnit : Form
    {
        public string OutterNo = "";
        public BusinessUnit Outter;
        bool ifChanged = false;

        public SingleBusinessUnit()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void SingleBusinessUnit_Load(object sender, EventArgs e)
        {
            if(OutterNo != string.Empty)
            {
                //读入
                try
                {
                    Outter = new BusinessUnitManager().Get(OutterNo);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close();
                }
                noText.Text = Outter.No + "";
                typeCombo.Text = Outter.Type;
                nameText.Text = Outter.Name;
                contactNameText.Text = Outter.ContactName;
                phoneText.Text = Outter.Phone;
                emailText.Text = Outter.Email;
                addressText.Text = Outter.Address;
            }
            else
            {
                typeCombo.Enabled = true;
            }
            ifChanged = false;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing会监听
        }

        private void SingleBusinessUnit_FormClosing(object sender, FormClosingEventArgs e)
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

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ifChanged)
            {
                MsgBox.ShowInfo("无需保存!");
                return;
            }
            if (Outter != null)
            {
                //修改
                try
                {
                    new BusinessUnitManager().ChangeInfo(noText.Text, nameText.Text, addressText.Text, contactNameText.Text, phoneText.Text, emailText.Text);
                }
                catch (Exception exp)
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
                    new BusinessUnitManager().Add(nameText.Text, typeCombo.Text, addressText.Text, contactNameText.Text, phoneText.Text, emailText.Text);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("新建失败!错误: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("新建成功!");
                ifChanged = false;
            }
        }

        private void NoText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void ContactNameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void PhoneText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void EmailText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void AddressText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
