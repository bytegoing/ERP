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
    public partial class YueXiaoShouZhuangKuang : Form
    {
        DateTime from;
        DateTime to;

        public YueXiaoShouZhuangKuang()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void YueXiaoShouZhuangKuang_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            yearLabel.Text = dt.Year + "";
            monthLabel.Text = dt.Month + "";
            from = DateTime.Parse(String.Format("{0}/{1}/{2}", dt.Year, dt.Month, "01"));
            to = DateTime.Parse(String.Format("{0}/{1}/{2}", dt.Year, dt.Month + 1, "01"));
        }

        private void 查询SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Stock> list;
            try
            {
                list = new StockManager().GetTotalList();
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                return;
            }
            Dictionary<string, int> count = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
                //日期符合
                if (list[i].Type == "销售出库" && (list[i].Reason == null || list[i].Reason == ""))
                {
                    //出库条件符合:即不计入退货
                    if (count.ContainsKey(list[i].GoodTypeName))
                    {
                        //有的话就再加上吧
                        count[list[i].GoodTypeName] += list[i].OutCount;
                    }
                    else
                    {
                        //没有就新建
                        count.Add(list[i].GoodTypeName, list[i].OutCount);
                    }
                }
            }
            chart1.Series[0].Points.Clear();
            //排个序.从大到小
            var saleSorted = from objDic in count orderby objDic.Value descending select objDic;
            chart1.Series[0]["PieLabelStyle"] = "Outside"; //将文字移到外侧 
            chart1.Series[0]["PieLineColor"] = "Black"; //绘制黑色的连线
            int countTime = 0;
            foreach (KeyValuePair<string, int> kv in saleSorted)
            {
                if (countTime == 6) break;
                chart1.Series[0].Points.AddXY(kv.Key, kv.Value); //逐个加入
                countTime++;
            }
        }

        private void 供应商进货统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Stock> list;
            try
            {
                list = new StockManager().GetTotalList();
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                return;
            }
            Dictionary<string, int> count = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
                //日期符合
                if (list[i].Type == "销售出库" && (list[i].Reason == null || list[i].Reason == ""))
                {
                    //出库条件符合:即不计入退货
                    if (count.ContainsKey(list[i].BusinessUnitName))
                    {
                        //有的话就再加上吧
                        count[list[i].BusinessUnitName] += list[i].OutCount;
                    }
                    else
                    {
                        //没有就新建
                        count.Add(list[i].BusinessUnitName, list[i].OutCount);
                    }
                }
            }
            chart1.Series[0].Points.Clear();
            //排个序.从大到小
            var saleSorted = from objDic in count orderby objDic.Value descending select objDic;
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
