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
    public partial class BusinessUnitForm : Form
    {
        public string type = "";
        public BusinessUnitForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void BusinessUnitForm_Load(object sender, EventArgs e)
        {
            type = this.Tag.ToString();
            //Type文字错误在Shown事件中检测,因为Load事件中调用窗体关闭方法会抛出异常。
            if (type == "供应商" || type == "客户")
            {
                this.Text = type + "信息维护";
                ReloadByCondition();
                conditionCombo.SelectedIndex = 0;
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 新建AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleBusinessUnit f = new SingleBusinessUnit();
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
                MsgBox.ShowError("请选择信息!");
                return;
            }
            SingleBusinessUnit f = new SingleBusinessUnit();
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
                MsgBox.ShowError("请选择信息!");
                return;
            }
            if (MsgBox.ShowAsk("真的确认要删除选中的往来单位信息吗?"))
            {
                //删除
                try
                {
                    new BusinessUnitManager().Delete(no);
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
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "单位名称";
            //dataGridView1.Columns[3].HeaderText = "单位地址";
            dataGridView1.Columns[4].HeaderText = "联系人";
            dataGridView1.Columns[5].HeaderText = "联系电话";
            dataGridView1.Columns[6].HeaderText = "Email";
        }

        private void ReloadByCondition(string condition = "", string find = "")
        {
            List<BusinessUnit> list;
            try
            {
                list = new BusinessUnitManager().GetList(type, condition, find);
            }
            catch(Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            dataGridView1.DataSource = list;
            //由于Model内成员不可更改，只好隐藏掉
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
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

        private void BusinessUnitForm_Shown(object sender, EventArgs e)
        {
            if (type != "供应商" && type != "客户")
            {
                MsgBox.ShowError("类型错误!");
                this.Close();
            }
        }

        private void 导出YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.ExportTool.dataGridViewToExcel(dataGridView1);
        }
    }
}
