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
    public partial class ReturnForm : Form
    {
        bool ifChanged = false;
        string type = "";

        public ReturnForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            type = this.Tag.ToString();
            //Type文字错误在Shown事件中检测,因为Load事件中调用窗体关闭方法会抛出异常。
            this.Text = type;
            ifChanged = false;
        }

        private void ReturnForm_Shown(object sender, EventArgs e)
        {
            if (type != "进货退货" && type != "销售退货")
            {
                MsgBox.ShowError("类型错误!");
                this.Close();
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing监听
        }

        private void ReturnForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowAsk("确认退货吗?"))
            {
                //确认
                //先做记号
                //看看存不存在,是否已经退货了
                Stock oldS;
                try
                {
                    oldS = new StockManager().Get(stockNoText.Text);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("退货失败! " + exp.Message);
                    return;
                }
                if ((oldS.Type == "进货入库" || oldS.Type == "销售出库") && (oldS.Reason == null || oldS.Reason == ""))
                {
                    //OK
                    //做标记
                    new StockManager().ReturnChange(oldS.No + "");
                    //再写入退货信息
                    if(oldS.Type == "进货入库")
                    {
                        //退货就该出库了
                        try
                        {
                            new StockManager().Out(oldS.GoodNo + "", oldS.WarehouseNo + "", "进货退货", oldS.No + "", oldS.InCount + "", oldS.InSinglePriceYuan, "-1", CommonData.nowLoginUser.LoginName, date.Value); ;
                        }
                        catch(Exception exp)
                        {
                            MsgBox.ShowError("退货失败! " + exp.Message);
                            new StockManager().ReturnCancelChange(oldS.No + "");
                            return;
                        }
                    }
                    else
                    {
                        //退货该入库了
                        try
                        {
                            new StockManager().In(oldS.GoodNo + "", oldS.WarehouseNo + "", "销售退货", oldS.No + "", oldS.OutCount + "", oldS.OutSinglePriceYuan, "-1", CommonData.nowLoginUser.LoginName, date.Value);
                        }
                        catch (Exception exp)
                        {
                            MsgBox.ShowError("退货失败! " + exp.Message);
                            new StockManager().ReturnCancelChange(oldS.No + "");
                            return;
                        }
                    }
                    MsgBox.ShowInfo("退货成功!");
                    ifChanged = false;
                }
                else
                {
                    MsgBox.ShowError("退货失败! 输入的记录编码已经退货或非可退货类型!");
                    return;
                }
            }
        }

        private void FindGoodBtn_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm();
            f.Tag = type.Substring(0, 2);
            f.ShowDialog(this);
            stockNoText.Text = CommonData.buffer2str.Item1;
            stockInfoText.Text = CommonData.buffer2str.Item2;
            CommonData.buffer2str = new Tuple<string, string>("", "");
        }

        private void StockNoText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
