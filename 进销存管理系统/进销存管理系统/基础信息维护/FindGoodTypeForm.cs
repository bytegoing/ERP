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
    public partial class FindGoodTypeForm : Form
    {
        public FindGoodTypeForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void FindGoodTypeForm_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            try
            {
                treeView1.Nodes.Add(new GoodTypeManager().GetListTreeNode(new GoodTypeManager().Get()));
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("错误: " + exp.Message);
                return;
            }
            treeView1.ExpandAll(); //展开全部
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            string str = node.Tag.ToString();
            string id = str.Split()[0];
            string parentId = str.Split()[1];
            string parentName = str.Split()[2];
            numberText.Text = id;
            nameText.Text = node.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(numberText.Text == string.Empty || nameText.Text == string.Empty)
            {
                MsgBox.ShowError("请在左侧选择商品类别!");
                return;
            }
            CommonData.buffer2str = new Tuple<string, string>(numberText.Text, nameText.Text);
            this.Close();
        }
    }
}
