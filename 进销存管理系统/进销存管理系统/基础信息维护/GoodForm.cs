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
    public partial class GoodForm : Form
    {
        public GoodForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void GoodForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
            conditionCombo.SelectedIndex = 0;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing监听
        }

        private void GoodForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; //无需确认
        }

        private void SetHeaderText()
        {
            dataGridView1.Columns[0].HeaderText = "商品编号";
            dataGridView1.Columns[1].HeaderText = "商品名称";
            dataGridView1.Columns[2].HeaderText = "规格";
            dataGridView1.Columns[3].HeaderText = "单位";
            //隐藏
            dataGridView1.Columns[5].HeaderText = "所属类别";
            dataGridView1.Columns[6].HeaderText = "最大库存";
            dataGridView1.Columns[7].HeaderText = "最小库存";
        }

        private void 新建AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleGoodForm f = new SingleGoodForm();
            f.OutterNo = "";
            f.ShowDialog();
            ReloadByCondition();
        }

        private void ReloadByCondition(string condition = "", string find = "")
        {
            List<Good> list;
            try
            {
                list = new GoodManager().GetList(condition, find);
            }
            catch(Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            dataGridView1.DataSource = list;
            //由于Model内成员不可更改，只好隐藏掉
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
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

        private void 修改SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string no = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (no == string.Empty || no == null)
            {
                MsgBox.ShowError("请选择商品信息!");
                return;
            }
            SingleGoodForm f = new SingleGoodForm();
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
                MsgBox.ShowError("请选择商品信息!");
                return;
            }
            if (MsgBox.ShowAsk("真的确认要删除选中的商品信息吗?"))
            {
                //删除
                try
                {
                    new GoodManager().Delete(no);
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

        private void 导出当前表格数据YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.ExportTool.dataGridViewToExcel(dataGridView1);
        }
    }
}
