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
using System.Windows.Forms.DataVisualization.Charting;

namespace 进销存管理系统.统计与报表
{
    public partial class JinHuoTongJi : Form
    {
        DateTime from, to;

        public JinHuoTongJi()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool GetDateTime()
        {
            string fromYear = fromYearText.Text;
            string fromMonth = fromMonthText.Text;
            string toYear = toYearText.Text;
            string toMonth = toMonthText.Text;
            try
            {
                from = DateTime.Parse(String.Format("{0:00}-{1:00}-01", fromYear, fromMonth));
                to = DateTime.Parse(string.Format("{0:00}-{1:00}-01", toYear, toMonth));
            }
            catch (Exception)
            {
                MsgBox.ShowError("日期填写错误!");
                return false;
            }
            if (from == to)
            {
                MsgBox.ShowError("如想查询同一年度的n月份数据,请在右侧输入当年度n+1月");
                return false;
            }
            if(from.AddMonths(6) < to)
            {
                MsgBox.ShowError("时间跨度最长六个月!");
                return false;
            }
            return true;
        }

        private void 查询SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Stock> list;
            Dictionary<string, int> count = new Dictionary<string, int>();
            if (GetDateTime())
            {
                try
                {
                    list = new StockManager().GetTotalList();
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                    return;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Date >= from && list[i].Date <= to)
                    {
                        //日期符合
                        if (list[i].Type == "进货入库" && (list[i].Reason == null || list[i].Reason == ""))
                        {
                            //出库条件符合:即不计入退货
                            if (count.ContainsKey(string.Format("{0}年{1}月", list[i].Date.Year, list[i].Date.Month)))
                            {
                                //有的话就再加上吧
                                count[string.Format("{0}年{1}月", list[i].Date.Year, list[i].Date.Month)] += list[i].InCount;
                            }
                            else
                            {
                                //没有就新建
                                count.Add(string.Format("{0}年{1}月", list[i].Date.Year, list[i].Date.Month), list[i].InCount);
                            }
                        }
                    }
                }
                //排个序.从小到大
                var saleSorted = from objDic in count orderby objDic.Key ascending select objDic;
                chart1.Series[0].Points.Clear();
                foreach (KeyValuePair<string, int> kv in saleSorted)
                {
                    chart1.Series[0].Points.AddXY(kv.Key, kv.Value); //逐个加入
                }
            }
        }

        private void 商品类别进货饼图SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Stock> list = null;
            Dictionary<string, List<Series>> dict = new Dictionary<string, List<Series>>();
            if (GetDateTime())
            {
                try
                {
                    list = new StockManager().GetList("进货入库",
                        " S_Date BETWEEN '" + from.ToString("yyyy/MM/dd") + "' AND '" + to.ToString("yyyy/MM/dd") + "'");
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                    return;
                }
                DateTime newTo = DateTime.Parse(string.Format("{0}/{1}/01", from.Year, from.Month));
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("count");
                while (newTo.Month <= to.Month + 1)
                {
                    Dictionary<string, int> count = new Dictionary<string, int>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Date.Year == newTo.Year && list[i].Date.Month == newTo.Month)
                        {
                            //符合条件
                            if (count.ContainsKey(list[i].GoodTypeName))
                            {
                                //,加入
                                count[list[i].GoodTypeName] += list[i].InCount;
                            }
                            else
                            {
                                //新建
                                count.Add(list[i].GoodTypeName, list[i].InCount);
                            }
                        }
                    }
                    //排个序.从大到小
                    var saleSorted = from objDic in count orderby objDic.Key descending select objDic;
                    if (saleSorted.Count() > 0)
                    {
                        //继续
                        int c = 0; //计数器
                        foreach (KeyValuePair<string, int> kv in saleSorted)
                        {
                            if (c == 3) break;
                            dt.Rows.Add(string.Format("{0}年{1}月,{2}", newTo.Year, newTo.Month, kv.Key), kv.Value);
                            c++;
                        }
                    }
                    newTo = DateTime.Parse(string.Format("{0}/{1}/01", newTo.Year, newTo.Month + 1));
                }
                chart1.Series[0].Points.Clear();
                chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
                chart1.DataSource = dt;
                chart1.Series[0].XValueMember = dt.Columns[0].ColumnName;
                chart1.Series[0].YValueMembers = dt.Columns[1].ColumnName;
                chart1.Series[0].Label = "#VAL";
            }
        }

        private void 导出目前图片YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTool.ExportChart(chart1);
        }

        private void 供应商进货统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Stock> list = null;
            Dictionary<string, List<Series>> dict = new Dictionary<string, List<Series>>();
            if (GetDateTime())
            {
                try
                {
                    list = new StockManager().GetList("进货入库",
                        " S_Date BETWEEN '" + from.ToString("yyyy/MM/dd") + "' AND '" + to.ToString("yyyy/MM/dd") + "'");
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("获取数据时发生错误: " + exp.Message);
                    return;
                }
                DateTime newTo = DateTime.Parse(string.Format("{0}/{1}/01", from.Year, from.Month));
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("count");
                while (newTo.Month <= to.Month + 1)
                {
                    Dictionary<string, int> count = new Dictionary<string, int>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Date.Year == newTo.Year && list[i].Date.Month == newTo.Month)
                        {
                            //符合条件
                            if (count.ContainsKey(list[i].BusinessUnitName))
                            {
                                //有该经销商,加入
                                count[list[i].BusinessUnitName] += list[i].InCount;
                            }
                            else
                            {
                                //新建
                                count.Add(list[i].BusinessUnitName, list[i].InCount);
                            }
                        }
                    }
                    //排个序.从大到小
                    var saleSorted = from objDic in count orderby objDic.Key descending select objDic;
                    if (saleSorted.Count() > 0)
                    {
                        //继续
                        int c = 0; //计数器
                        foreach (KeyValuePair<string, int> kv in saleSorted)
                        {
                            if (c == 3) break;
                            dt.Rows.Add(string.Format("{0}年{1}月,{2}", newTo.Year, newTo.Month, kv.Key), kv.Value);
                            c++;
                        }
                    }
                    newTo = DateTime.Parse(string.Format("{0}/{1}/01", newTo.Year, newTo.Month + 1));
                }
                chart1.Series[0].Points.Clear();
                chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
                chart1.DataSource = dt;
                chart1.Series[0].XValueMember = dt.Columns[0].ColumnName;
                chart1.Series[0].YValueMembers = dt.Columns[1].ColumnName;
                chart1.Series[0].Label = "#VAL";
            }
        }
    }
}
