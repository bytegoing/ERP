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

namespace 进销存管理系统.统计与报表
{
    public partial class XiaoShouPaiHang : Form
    {
        public XiaoShouPaiHang()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void 查询SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fromYear = fromYearText.Text;
            string fromMonth = fromMonthText.Text;
            string toYear = toYearText.Text;
            string toMonth = toMonthText.Text;
            DateTime from, to;
            try
            {
                from = DateTime.Parse(String.Format("{0:00}-{1:00}-01", fromYear, fromMonth));
                to = DateTime.Parse(string.Format("{0:00}-{1:00}-01", toYear, toMonth));
            }
            catch(Exception)
            {
                MsgBox.ShowError("日期填写错误!");
                return;
            }
            if(from == to)
            {
                MsgBox.ShowError("如想查询同一年度的n月份数据,请在右侧输入当年度n+1月");
                return;
            }
            List<Stock> list;
            try
            {
                list = new StockManager().GetTotalList();
            }
            catch(Exception exp)
            {
                MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                return;
            }
            Dictionary<string, int> saleCount = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Date >= from && list[i].Date <= to)
                {
                    //日期符合
                    if(list[i].Type == "销售出库" && (list[i].Reason == null || list[i].Reason == ""))
                    {
                        //出库条件符合:即不计入退货
                        if(saleCount.ContainsKey(list[i].GoodName))
                        {
                            //有的话就再加上吧
                            saleCount[list[i].GoodName] += list[i].OutCount;
                        }
                        else
                        {
                            //没有就新建
                            saleCount.Add(list[i].GoodName, list[i].OutCount);
                        }
                    }
                }
            }
            chart1.Series[0].Points.Clear();
            //排个序.从大到小
            var saleSorted = from objDic in saleCount orderby objDic.Value descending select objDic;
            chart1.Series[0]["PieLabelStyle"] = "Outside"; //将文字移到外侧 
            chart1.Series[0]["PieLineColor"] = "Black"; //绘制黑色的连线
            foreach (KeyValuePair<string, int> kv in saleSorted)
            {
                chart1.Series[0].Points.AddXY(kv.Key, kv.Value); //逐个加入
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 导出目前图片YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTool.ExportChart(chart1);
        }
    }
}
