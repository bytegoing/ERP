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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
            conditionCombo.SelectedIndex = 0;
        }

        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; //无需确认
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件会监听
        }

        private void 新建AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleEmployeeForm p = new SingleEmployeeForm();
            p.ifNew = true;
            p.ShowDialog();
            ReloadByCondition();
        }

        private void SetHeaderText()
        {
            dataGridView1.Columns[0].HeaderText = "用户名";
            //Model内成员不可更改，故只好隐藏
            dataGridView1.Columns[3].HeaderText = "姓名";
            dataGridView1.Columns[4].HeaderText = "性别";
            dataGridView1.Columns[5].HeaderText = "部门";
            dataGridView1.Columns[6].HeaderText = "联系方式";
            dataGridView1.Columns[7].HeaderText = "生日";
            dataGridView1.Columns[8].HeaderText = "入职日期";
        }

        private void ReloadByCondition(string condition = "", string find = "")
        {
            List<User> list;
            try
            {
                list = new UserManager().GetList(condition, find);
            }
            catch(Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            dataGridView1.DataSource = list;
            //由于Model内成员不可更改，只好隐藏掉
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            SetHeaderText();
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            if(conditionCombo.Text.Trim() != "不筛选" && findText.Text == string.Empty)
            {
                MsgBox.ShowError("请填入要查找的值");
                return;
            }
            ReloadByCondition(conditionCombo.Text.Trim(), findText.Text);
        }

        private void 修改SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string username = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (username == string.Empty || username == null)
            {
                MsgBox.ShowError("请选择员工!");
                return;
            }
            SingleEmployeeForm p = new SingleEmployeeForm();
            p.OutterUsername = dataGridView1.Rows[i].Cells[0].Value.ToString();
            p.ShowDialog();
            ReloadByCondition();
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string username = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (username == string.Empty || username == null)
            {
                MsgBox.ShowError("请选择员工!");
                return;
            }
            if(MsgBox.ShowAsk("真的确认要删除选中的员工吗?"))
            {
                //删除
                try
                {
                    new UserManager().Delete(username);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("删除失败! 原因: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("删除成功!");
            }
            ReloadByCondition();
        }

        private void 导出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.ExportTool.dataGridViewToExcel(dataGridView1);
        }
    }
}
