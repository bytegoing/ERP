using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using 进销存管理系统.BLL;
using 进销存管理系统.Common;
using 进销存管理系统.Models;

namespace 进销存管理系统.进销存
{
    public partial class StockQuery : Form
    {
        public StockQuery()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void Record_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void SetHeaderText()
        {
            //dataGridView1.Columns[0].HeaderText = "记录编号";
            dataGridView1.Columns[2].HeaderText = "商品名称";
            dataGridView1.Columns[3].HeaderText = "商品类型";
            dataGridView1.Columns[5].HeaderText = "仓库名称";
            dataGridView1.Columns[14].HeaderText = "剩余数量";
            dataGridView1.Columns[16].HeaderText = "剩余总价";
        }

        private void Reload(bool filter = false)
        {
            string sqlCondition = "";
            if(filter)
            {
                sqlCondition = StockManager.GetRecordSqlCondition(goodNameText.Text, goodTypeText.Text, warehouseNameText.Text);
            }
            List<Stock> list = new List<Stock>();
            try
            {
                list = new StockManager().GetLatestStockList(sqlCondition);
            }
            catch(Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            dataGridView1.DataSource = list;
            //由于Model内成员不可更改，只好隐藏掉
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            SetHeaderText();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            Reload(true);
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            Common.ExportTool.dataGridViewToExcel(dataGridView1);
        }

        private void FindGoodBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = "商品";
            f.ShowDialog(this);
            goodNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void FindGoodTypeBtn_Click(object sender, EventArgs e)
        {
            基础信息维护.FindGoodTypeForm f = new 基础信息维护.FindGoodTypeForm();
            f.ShowDialog(this);
            goodTypeText.Text = CommonData.buffer2str.Item2;
            if (goodTypeText.Text == "商品类型") goodTypeText.Text = "";
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void FindWarehouseNameBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = "仓库";
            f.ShowDialog(this);
            warehouseNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }
    }
}
