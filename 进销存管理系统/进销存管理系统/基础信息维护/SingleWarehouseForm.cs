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
    public partial class SingleWarehouseForm : Form
    {
        bool ifChanged = false;
        public string OutterNo = ""; //从外部调用
        public Warehouse Outter = null; //从外部调用

        public SingleWarehouseForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void SingleWarehouseForm_Load(object sender, EventArgs e)
        {
            if (OutterNo != string.Empty)
            {
                //读入
                try
                {
                    Outter = new WarehouseManager().Get(OutterNo);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close();
                }
                noText.Text = Outter.No + "";
                nameText.Text = Outter.Name;
                addressText.Text = Outter.Address;
            }
            ifChanged = false;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件
        }

        private void SingleWarehouseForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    new WarehouseManager().ChangeInfo(noText.Text, nameText.Text.Trim(), addressText.Text);
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
                    new WarehouseManager().Add(nameText.Text.Trim(), addressText.Text);
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

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void AddressText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
