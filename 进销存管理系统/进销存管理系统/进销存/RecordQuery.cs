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

namespace 进销存管理系统.进销存
{
    public partial class RecordQuery : Form
    {
        public RecordQuery()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void RecordQuery_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            List<Stock> list = new StockManager().GetTotalList();
            dataGridView1.DataSource = list;
            //由于Model内成员不可更改，只好隐藏掉
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            SetHeaderText();
        }

        private void SetHeaderText()
        {
            dataGridView1.Columns[0].HeaderText = "记录编号";
            dataGridView1.Columns[2].HeaderText = "商品名称";
            dataGridView1.Columns[3].HeaderText = "商品类型";
            dataGridView1.Columns[5].HeaderText = "仓库名称";
            dataGridView1.Columns[6].HeaderText = "操作类型";
            dataGridView1.Columns[7].HeaderText = "备注/原因";
            dataGridView1.Columns[8].HeaderText = "入库数量";
            dataGridView1.Columns[10].HeaderText = "入库单价";
            dataGridView1.Columns[11].HeaderText = "出库数量";
            dataGridView1.Columns[13].HeaderText = "出库单价";
            dataGridView1.Columns[14].HeaderText = "剩余数量";
            dataGridView1.Columns[16].HeaderText = "剩余总价";
            dataGridView1.Columns[18].HeaderText = "单位类别";
            dataGridView1.Columns[19].HeaderText = "单位名称";
            dataGridView1.Columns[20].HeaderText = "操作账号";
            dataGridView1.Columns[21].HeaderText = "操作人";
            dataGridView1.Columns[22].HeaderText = "业务日期";
        }

        private void 导出SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.ExportTool.dataGridViewToExcel(dataGridView1);
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
