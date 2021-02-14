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
    public partial class GoodTypeForm : Form
    {
        bool ifChange = false;
        bool ifAdd = false;
        public GoodTypeForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void ClearControls()
        {
            parentText.Text = "";
            parentNameText.Text = "";
            numberText.Text = "";
            nameText.Text = "";
        }

        private void Reload()
        {
            //重新加载
            treeView1.Nodes.Clear();
            try
            {
                treeView1.Nodes.Add(new GoodTypeManager().GetListTreeNode(new GoodTypeManager().Get()));
            }
            catch(Exception exp)
            {
                MsgBox.ShowError("错误: " + exp.Message);
                return;
            }
            treeView1.ExpandAll(); //展开全部
        }

        private void GoodType_Load(object sender, EventArgs e)
        {
            tipText.Text = "普通模式: 请在左侧点击想要查看的商品类型";
            Reload();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件会监听
        }

        private void GoodType_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ifChange || ifAdd)
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
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            string str = node.Tag.ToString();
            string id = str.Split()[0];
            string parentId = str.Split()[1];
            string parentName = str.Split()[2];
            if(ifAdd || ifChange)
            {
                //添加和修改模式中选择的本身就是父类
                parentText.Text = id;
                parentNameText.Text = node.Text;
            }
            else
            {
                parentText.Text = parentId;
                parentNameText.Text = parentName;
                numberText.Text = id;
                nameText.Text = node.Text;
            }
        }

        private void 增加AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ifAdd)
            {
                //该保存增加了
                if(parentText.Text == string.Empty)
                {
                    parentText.Text = "0";
                    parentNameText.Text = "商品分类";
                }
                if(nameText.Text.Trim() == string.Empty)
                {
                    MsgBox.ShowError("请输入分类名称!");
                    return;
                }
                //保存操作
                try
                {
                    new GoodTypeManager().Add(parentText.Text, nameText.Text.Trim());
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("增加失败: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("增加成功!");
                //保存完了该恢复正常了
                增加AToolStripMenuItem.Text = "增加";
                修改SToolStripMenuItem.Enabled = true;
                ifAdd = false;
                nameText.ReadOnly = true;
                ClearControls();
                Reload();
            }
            else
            {
                //看看是不是在修改
                if(ifChange)
                {
                    MsgBox.ShowError("请先保存修改后再增加!");
                    return;
                }
                //更改状态
                ifAdd = true;
                //禁止修改按钮
                修改SToolStripMenuItem.Enabled = false;
                //更换提示文字
                增加AToolStripMenuItem.Text = "保存";
                //进入新增模式
                tipText.Text = "新增中,若需添加父类可点击左侧树状图填写。";
                ClearControls();
                nameText.ReadOnly = false;
            }
        }

        private void 修改SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ifChange)
            {
                //该保存修改了
                if (nameText.Text.Trim() == string.Empty)
                {
                    MsgBox.ShowError("请输入分类名称!");
                    return;
                }
                //执行操作
                try
                {
                    new GoodTypeManager().Update(parentText.Text, numberText.Text, nameText.Text.Trim());
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("修改失败: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("修改成功!");
                //保存完了该恢复正常了
                修改SToolStripMenuItem.Text = "修改";
                增加AToolStripMenuItem.Enabled = true;
                ifChange = false;
                nameText.ReadOnly = true;
                ClearControls();
                Reload();
            }
            else
            {
                //看看是不是在修改
                if (ifAdd)
                {
                    MsgBox.ShowError("请先保存增加后再修改!");
                    return;
                }
                if (numberText.Text == "0" || numberText.Text == string.Empty)
                {
                    MsgBox.ShowError("禁止修改根节点或空节点!");
                    return;
                }
                //更改状态
                ifChange = true;
                //禁止增加按钮
                增加AToolStripMenuItem.Enabled = false;
                //更换提示文字
                修改SToolStripMenuItem.Text = "保存";
                //进入修改模式
                tipText.Text = "修改中,若需更改父类可点击左侧树状图填写。";
                nameText.ReadOnly = false;
            }
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MsgBox.ShowAsk("删除该类别将会导致下属类别和所属商品全部被删除!是否继续?"))
            {
                //继续
                try
                {
                    new GoodTypeManager().Delete(numberText.Text);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("删除失败! 原因: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("删除成功!");
            }
            Reload();
            ClearControls();
        }
    }
}
