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
    public partial class FindForm : Form
    {
        string type = "";

        public FindForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            type = this.Tag.ToString();
            //Type文字错误在Shown事件中检测,因为Load事件中调用窗体关闭方法会抛出异常。
            this.Text = "查找"+type;
            conditionCombo.Items.Clear();
            conditionCombo.Items.Add("不筛选");
            switch (type)
            {
                case "商品":
                    conditionCombo.Items.Add("商品名称");
                    conditionCombo.Items.Add("商品类别");
                    break;
                case "仓库":
                    conditionCombo.Items.Add("仓库名称");
                    break;
                case "销售":
                    conditionCombo.Items.Add("日期");
                    conditionCombo.Items.Add("仓库名称");
                    break;
                case "进货":
                    conditionCombo.Items.Add("日期");
                    conditionCombo.Items.Add("仓库名称");
                    break;
                case "供应商":
                    conditionCombo.Items.Add("名称");
                    conditionCombo.Items.Add("联系人姓名");
                    break;
                case "客户":
                    conditionCombo.Items.Add("名称");
                    conditionCombo.Items.Add("联系人姓名");
                    break;
            }
            conditionCombo.SelectedIndex = 0;
            Reload();
        }

        private void SetHeaderText()
        {
            switch (type)
            {
                case "商品":
                    dataGridView1.Columns[0].HeaderText = "商品编号";
                    dataGridView1.Columns[1].HeaderText = "商品名称";
                    dataGridView1.Columns[2].HeaderText = "规格";
                    dataGridView1.Columns[3].HeaderText = "单位";
                    //隐藏
                    dataGridView1.Columns[5].HeaderText = "所属类别";
                    dataGridView1.Columns[6].HeaderText = "最大库存";
                    dataGridView1.Columns[7].HeaderText = "最小库存";
                    dataGridView1.Columns[8].HeaderText = "备注";
                    break;
                case "仓库":
                    dataGridView1.Columns[0].HeaderText = "仓库编号";
                    dataGridView1.Columns[1].HeaderText = "仓库名称";
                    dataGridView1.Columns[2].HeaderText = "仓库地址";
                    break;
                case "销售":
                    dataGridView1.Columns[0].HeaderText = "记录编号";
                    dataGridView1.Columns[2].HeaderText = "商品名称";
                    dataGridView1.Columns[3].HeaderText = "商品类别";
                    dataGridView1.Columns[5].HeaderText = "仓库名称";
                    dataGridView1.Columns[11].HeaderText = "出库数量";
                    dataGridView1.Columns[13].HeaderText = "出库单价";
                    dataGridView1.Columns[14].HeaderText = "剩余数量";
                    dataGridView1.Columns[16].HeaderText = "剩余总价";
                    dataGridView1.Columns[19].HeaderText = "单位名称";
                    dataGridView1.Columns[21].HeaderText = "操作人";
                    dataGridView1.Columns[22].HeaderText = "业务日期";
                    break;
                case "进货":
                    dataGridView1.Columns[0].HeaderText = "记录编号";
                    dataGridView1.Columns[2].HeaderText = "商品名称";
                    dataGridView1.Columns[3].HeaderText = "商品类别";
                    dataGridView1.Columns[5].HeaderText = "仓库名称";
                    dataGridView1.Columns[8].HeaderText = "入库数量";
                    dataGridView1.Columns[10].HeaderText = "入库单价";
                    dataGridView1.Columns[14].HeaderText = "剩余数量";
                    dataGridView1.Columns[16].HeaderText = "剩余总价";
                    dataGridView1.Columns[19].HeaderText = "单位名称";
                    dataGridView1.Columns[21].HeaderText = "操作人";
                    dataGridView1.Columns[22].HeaderText = "业务日期";
                    break;
                case "供应商":
                case "客户":
                    dataGridView1.Columns[0].HeaderText = "编号";
                    dataGridView1.Columns[1].HeaderText = "单位名称";
                    //dataGridView1.Columns[3].HeaderText = "单位地址";
                    dataGridView1.Columns[4].HeaderText = "联系人";
                    dataGridView1.Columns[5].HeaderText = "联系电话";
                    dataGridView1.Columns[6].HeaderText = "Email";
                    break;
            }
        }

        private void Reload()
        {
            switch (type)
            {
                case "商品":
                    List<Good> goodList;
                    try
                    {
                        goodList = new GoodManager().GetList(conditionCombo.Text, findText.Text);
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = goodList;
                    dataGridView1.Columns[4].Visible = false; //由于Model内成员不可更改，只好隐藏掉
                    SetHeaderText();
                    break;
                case "仓库":
                    List<Warehouse> warehouseList;
                    try
                    {
                        warehouseList = new WarehouseManager().GetList(conditionCombo.Text, findText.Text);
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = warehouseList;
                    SetHeaderText();
                    break;
                case "销售":
                    List<Stock> sellList;
                    try
                    {
                        sellList = new StockManager().GetList("销售出库", StockManager.GetFindSqlCondition(conditionCombo.Text, findText.Text));
                    }
                    catch(Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = sellList;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false; //入库
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[12].Visible = false; //出库
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[18].Visible = false;
                    dataGridView1.Columns[20].Visible = false;
                    SetHeaderText();
                    break;
                case "进货":
                    List<Stock> buyList;
                    try
                    {
                        buyList = new StockManager().GetList("进货入库", StockManager.GetFindSqlCondition(conditionCombo.Text, findText.Text));
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = buyList;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[9].Visible = false; //入库
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false; //出库
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[18].Visible = false;
                    dataGridView1.Columns[20].Visible = false;
                    SetHeaderText();
                    break;
                case "供应商":
                    List<BusinessUnit> sellerList;
                    try
                    {
                        sellerList = new BusinessUnitManager().GetList("供应商", conditionCombo.Text, findText.Text);
                    }
                    catch(Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = sellerList;
                    //由于Model内成员不可更改，只好隐藏掉
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    SetHeaderText();
                    break;
                case "客户":
                    List<BusinessUnit> buyerList;
                    try
                    {
                        buyerList = new BusinessUnitManager().GetList("客户", conditionCombo.Text, findText.Text);
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError(exp.Message);
                        return;
                    }
                    dataGridView1.DataSource = buyerList;
                    //由于Model内成员不可更改，只好隐藏掉
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    SetHeaderText();
                    break;
            }
        }

        private void FindForm_Shown(object sender, EventArgs e)
        {
            if (type != "商品" && type != "仓库" && type != "销售" && type != "进货" && type != "供应商" && type != "客户")
            {
                MsgBox.ShowError("类型错误!");
                this.Close();
            }
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string no = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (no == string.Empty || no == null)
            {
                MsgBox.ShowError("请选择信息!");
                return;
            }
            switch (type)
            {
                case "商品":
                case "仓库":
                case "供应商":
                case "客户":
                    CommonData.buffer2str = new Tuple<string, string>(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                    break;
                case "销售":
                    string detail = "";
                    detail += string.Format("商品名称: {0}\r\n商品类别: {1}", dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                    detail += "\r\n";
                    detail += string.Format("仓库名称: {0}\r\n出入库数量: {1}\r\n出入库单价: {2}", dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString(), dataGridView1.Rows[i].Cells[13].Value.ToString());
                    detail += "\r\n";
                    detail += string.Format("单位名称: {0}", dataGridView1.Rows[i].Cells[19].Value.ToString());
                    detail += "\r\n";
                    detail += string.Format("业务日期: {0}", dataGridView1.Rows[i].Cells[22].Value.ToString().Split(' ')[0]);
                    CommonData.buffer2str = new Tuple<string, string>(dataGridView1.Rows[i].Cells[0].Value.ToString(), detail);
                    break;
                case "进货":
                    string detailx = "";
                    detailx += string.Format("商品名称: {0}\r\n商品类别: {1}", dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                    detailx += "\r\n";
                    detailx += string.Format("仓库名称: {0}\r\n入库数量: {1}\r\n入库单价: {2}", dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString());
                    detailx += "\r\n";
                    detailx += string.Format("单位名称: {0}", dataGridView1.Rows[i].Cells[19].Value.ToString());
                    detailx += "\r\n";
                    detailx += string.Format("业务日期: {0}", dataGridView1.Rows[i].Cells[22].Value.ToString().Split(' ')[0]);
                    CommonData.buffer2str = new Tuple<string, string>(dataGridView1.Rows[i].Cells[0].Value.ToString(), detailx);
                    break;
            }
            this.Close();
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
