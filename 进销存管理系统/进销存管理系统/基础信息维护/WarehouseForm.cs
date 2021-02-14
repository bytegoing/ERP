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
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
            conditionCombo.SelectedIndex = 0;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件会监听
        }

        private void WarehouseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; //无需确认
        }

        private void 新建AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleWarehouseForm f = new SingleWarehouseForm();
            f.OutterNo = "";
            f.ShowDialog();
            ReloadByCondition();
        }

        private void 修改SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string no = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (no == string.Empty || no == null)
            {
                MsgBox.ShowError("请选择仓库!");
                return;
            }
            SingleWarehouseForm f = new SingleWarehouseForm();
            f.OutterNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
            f.ShowDialog();
            ReloadByCondition();
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string no = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (no == string.Empty || no == null)
            {
                MsgBox.ShowError("请选择仓库!");
                return;
            }
            if (MsgBox.ShowAsk("真的确认要删除选中的仓库吗?相关库存记录将会被清除!"))
            {
                //删除
                try
                {
                    new WarehouseManager().Delete(no);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("删除失败! 原因: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("删除成功!");
            }
            ReloadByCondition();
        }

        private void SetHeaderText()
        {
            dataGridView1.Columns[0].HeaderText = "仓库编号";
            dataGridView1.Columns[1].HeaderText = "仓库名称";
            dataGridView1.Columns[2].HeaderText = "仓库地址";
        }

        private void ReloadByCondition(string condition = "", string find = "")
        {
            List<Warehouse> list;
            try
            {
                list = new WarehouseManager().GetList(condition, find);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            dataGridView1.DataSource = list;
            SetHeaderText();
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            if (conditionCombo.Text.Trim() != "不筛选" && findText.Text == string.Empty)
            {
                MsgBox.ShowError("请填入要查找的值");
                return;
            }
            ReloadByCondition(conditionCombo.Text.Trim(), findText.Text);
        }
    }
}
