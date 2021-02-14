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
    public partial class InForm : Form
    {
        bool ifChanged = false;
        public string OutterNo = ""; //从外部调用
        public Stock Outter = null; //从外部调用
        string type = "";

        public InForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void InForm_Load(object sender, EventArgs e)
        {
            type = this.Tag.ToString();
            //Type文字错误在Shown事件中检测,因为Load事件中调用窗体关闭方法会抛出异常。
            this.Text = type;
            typeText.Text = type;
            if(type == "其他入库")
            {
                reasonLabel.Visible = true;
                reasonText.Visible = true;
                businessUnitNameText.Visible = false;
                businessUnitNoText.Visible = false;
                businessUnitLabel.Visible = false;
                findBusinessUnitBtn.Visible = false;
            }
            if (OutterNo != string.Empty)
            {
                //外部调用了
                try
                {
                    Outter = new StockManager().Get(OutterNo);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close(); //[T]
                }
                goodNoText.Text = Outter.GoodNo+"";
                goodNameText.Text = Outter.GoodName;
                warehouseNoText.Text = Outter.WarehouseNo + "";
                warehouseNameText.Text = Outter.WarehouseName;
                typeText.Text = Outter.Type;
                reasonText.Text = Outter.Reason;
                inCountText.Text = Outter.InCount + "";
                inSinglePriceText.Text = Outter.InSinglePrice + "";
                inTotalPriceText.Text = Outter.InCount * Outter.InSinglePrice + "";
                businessUnitNoText.Text = Outter.BusinessUnitNo + "";
                businessUnitNameText.Text = Outter.BusinessUnitName;
                date.Value = Outter.Date;
            }
            else
            {
                //全新
            }
            ifChanged = false;
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件
        }

        private void InForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void InForm_Shown(object sender, EventArgs e)
        {
            if (type != "进货入库" && type != "其他入库")
            {
                MsgBox.ShowError("类型错误!");
                this.Close();
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new StockManager().In(goodNoText.Text, warehouseNoText.Text, typeText.Text, reasonText.Text, inCountText.Text, inSinglePriceText.Text, businessUnitNoText.Text, CommonData.nowLoginUser.LoginName, date.Value);
            }
            catch(Exception exp)
            {
                MsgBox.ShowError("入库失败! "+exp.Message);
                return;
            }
            MsgBox.ShowInfo("入库成功!");
            ifChanged = false;
        }

        private void GoodNoText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void WarehouseNoText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void TypeText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void ReasonText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void TryCalc()
        {
            string singlePrice = inSinglePriceText.Text;
            int singlePriceNum = 0;
            int countNum = 0;
            try
            {
                singlePriceNum = StockManager.GetValue(singlePrice);
                countNum = Convert.ToInt32(inCountText.Text);
            }
            catch (Exception)
            {
                inTotalPriceText.Text = "";
                return;
            }
            inTotalPriceText.Text = ((countNum * singlePriceNum) / 100.0).ToString();
        }

        private void InCountText_TextChanged(object sender, EventArgs e)
        {
            inCountText.Text = inCountText.Text.Replace(".", string.Empty);
            ifChanged = true;
            TryCalc();
        }

        private void InSinglePriceText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
            TryCalc();
        }

        private void BusinessUnitNoText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void FindGoodBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = "商品";
            f.ShowDialog(this);
            goodNoText.Text = CommonData.buffer2str.Item1;
            goodNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void FindWarehouseBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = "仓库";
            f.ShowDialog(this);
            warehouseNoText.Text = CommonData.buffer2str.Item1;
            warehouseNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void FindBusinessUnitBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = "供应商";
            f.ShowDialog(this);
            businessUnitNoText.Text = CommonData.buffer2str.Item1;
            businessUnitNameText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }
    }
}
