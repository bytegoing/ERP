using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.DAL;
using 进销存管理系统.Models;
using 进销存管理系统.Common;

namespace 进销存管理系统.BLL
{
    public class StockManager
    {
        //用id获取单个次数信息
        public Stock Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("编号不正确!");
            }
            return new StockService().Get(n);
        }

        //获取某商品最新库存
        public Stock GetLatest(string goodNo, string warehouseNo)
        {
            int n;
            if (!Int32.TryParse(goodNo, out n))
            {
                throw new Exception("商品编号不正确!");
            }
            int w;
            if(!Int32.TryParse(warehouseNo, out w))
            {
                throw new Exception("仓库编号不正确!");
            }
            return new StockService().GetByGoodNo(n, w);
        }

        //获取Record页面筛选条件
        public static string GetRecordSqlCondition(string goodName, string goodType, string warehouseName)
        {
            string sqlCondition = "";
            bool ifHave = false;
            if(goodName != string.Empty)
            {
                if (ifHave) sqlCondition += " AND ";
                sqlCondition += " tbl_Good.G_Name = '"+goodName+"' ";
                ifHave = true;
            }
            if(goodType != string.Empty)
            {
                if (ifHave) sqlCondition += " AND ";
                sqlCondition += " tbl_GoodType.GT_Name = '"+goodType+"' ";
                ifHave = true;
            }
            if(warehouseName != string.Empty)
            {
                if (ifHave) sqlCondition += " AND ";
                sqlCondition += " tbl_Warehouse.W_Name = '"+warehouseName+"' ";
                ifHave = true;
            }
            return sqlCondition;
        }

        public static string GetFindSqlCondition(string condition, string find)
        {
            string sqlCondition = "";
            DateTime dt;
            switch (condition)
            {
                case "日期":
                    if(find != string.Empty)
                    {
                        try
                        {
                            dt = DateTime.ParseExact(find, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                        }
                        catch (Exception) { throw new Exception("日期应为20200701类似的格式!"); }
                        sqlCondition += " tbl_Stock.S_Date = '" + dt.ToString("yyyy-MM-dd") + "' ";
                    }
                    else
                    {
                        throw new Exception("请输入查找值!");
                    }
                    break;
                case "仓库名称":
                    if(find != string.Empty)
                    {
                        sqlCondition += " tbl_Warehouse.W_Name = '" + find + "' ";
                    }
                    else
                    {
                        throw new Exception("请输入查找值!");
                    }
                    break;
            }
            return sqlCondition;
        }

        //获取列表
        public List<Stock> GetLatestStockList(string sqlCondition)
        {
            return new StockService().GetLatestStockList(sqlCondition);
        }

        public List<Stock> GetList(string type, string sqlCondition)
        {
            string finalSql = "";
            if (type != string.Empty)
            {
                finalSql += " S_Type = '" + type + "' ";
            }
            if (sqlCondition != string.Empty)
            {
                if(type != string.Empty)
                {
                    finalSql += " AND " + sqlCondition;
                }
                else
                {
                    finalSql += " "+ sqlCondition+" ";
                }
            }
            if (finalSql != string.Empty) finalSql += " AND ";
            finalSql += " (S_Reason IS NULL OR S_Reason = '')  ";
            return new StockService().GetList(finalSql);
        }

        public List<Stock> GetTotalList()
        {
            return new StockService().GetTotalList();
        }

        //获得Model
        private Stock GetModel(int no, int goodNo, int warehouseNo, string type, string reason, int inCount, int inSinglePrice, int outCount, int outSinglePrice, int remainingCount, int remainingPrice, int businessUnitNo, string operatorLoginName, DateTime date)
        {
            Stock s = new Stock();
            s.No = no;
            s.GoodNo = goodNo;
            s.WarehouseNo = warehouseNo;
            s.Type = type;
            s.Reason = reason;
            s.InCount = inCount;
            s.InSinglePrice = inSinglePrice;
            s.OutCount = outCount;
            s.OutSinglePrice = outSinglePrice;
            s.RemainingCount = remainingCount;
            s.RemainingPrice = remainingPrice;
            s.BusinessUnitNo = businessUnitNo;
            s.OperatorNo = operatorLoginName;
            s.Date = date;
            return s;
        }

        //入库操作
        public void In(string goodNo, string warehouseNo, string type, string reason, string inCount, string inSinglePrice, string businessUnitNo, string operatorLoginName, DateTime date)
        {
            int goodNoNum, warehouseNoNum, inCountNum, inSinglePriceNum, businessUnitNoNum;
            if (!Int32.TryParse(goodNo, out goodNoNum)) throw new Exception("商品编号错误");
            if (!Int32.TryParse(warehouseNo, out warehouseNoNum)) throw new Exception("仓库编号错误");
            if (!Int32.TryParse(inCount, out inCountNum) || inCountNum < 0) throw new Exception("入库数量错误");
            inSinglePriceNum = GetValue(inSinglePrice);
            if (!Int32.TryParse(businessUnitNo, out businessUnitNoNum) && type != "其他入库") throw new Exception("往来单位编号填写错误");
            if (businessUnitNoNum < 0 && type != "销售退货" && type != "其他入库") throw new Exception("往来单位编号错误");
            if (operatorLoginName == string.Empty) throw new Exception("操作人用户名错误!");
            if (date == null) throw new Exception("日期有误!");
            //要校验: type和reason
            if (type == string.Empty) throw new Exception("入库类型错误!");
            if (type == "其他入库" && reason == string.Empty) throw new Exception("请填写其他入库原因!");
            //取原先数据
            bool ifNew = false;
            Stock oldS = null;
            Stock newS = new Stock();
            try
            {
                oldS = new StockService().GetByGoodNo(goodNoNum, warehouseNoNum);
            }
            catch(Exception exp)
            {
                if(exp.Message == "记录不存在")
                {
                    ifNew = true;
                }
                else
                {
                    throw exp;
                }
            }
            if(ifNew)
            {
                //新建
                int newPrice = inCountNum * inSinglePriceNum;
                newS = GetModel(-1, goodNoNum, warehouseNoNum, type, reason, inCountNum, inSinglePriceNum, 0, 0, inCountNum, newPrice, businessUnitNoNum, operatorLoginName, date);
                new StockService().Add(newS);
            }
            else
            {
                int oldCount;
                int oldPrice;
                int newCount;
                int newPrice;
                //修改
                oldCount = oldS.RemainingCount;
                oldPrice = oldS.RemainingPrice;
                newCount = oldCount + inCountNum;
                newPrice = oldPrice + (inCountNum * inSinglePriceNum);
                newS = GetModel(-1, goodNoNum, warehouseNoNum, type, reason, inCountNum, inSinglePriceNum, 0, 0, newCount, newPrice, businessUnitNoNum, operatorLoginName, date);
                new StockService().Add(newS);
            }
        }

        //出库操作
        public void Out(string goodNo, string warehouseNo, string type, string reason, string outCount, string outSinglePrice, string businessUnitNo, string operatorLoginName, DateTime date)
        {
            int goodNoNum, warehouseNoNum, outCountNum, outSinglePriceNum, businessUnitNoNum;
            if (!Int32.TryParse(goodNo, out goodNoNum)) throw new Exception("商品编号错误");
            if (!Int32.TryParse(warehouseNo, out warehouseNoNum)) throw new Exception("仓库编号错误");
            if (!Int32.TryParse(outCount, out outCountNum) || outCountNum < 0) throw new Exception("出库数量错误");
            outSinglePriceNum = GetValue(outSinglePrice);
            if (!Int32.TryParse(businessUnitNo, out businessUnitNoNum) && type != "其他出库") throw new Exception("往来单位编号填写错误");
            if (businessUnitNoNum < 0 && type != "进货退货" && type != "其他出库") throw new Exception("往来单位编号错误");
            if (operatorLoginName == string.Empty) throw new Exception("操作人用户名错误!");
            if (date == null) throw new Exception("日期有误!");
            //要校验: type和reason
            if (type == string.Empty) throw new Exception("出库类型错误!");
            if (type == "其他出库" && reason == string.Empty) throw new Exception("请填写其他出库原因!");
            //取原先数据
            bool ifNew = false;
            Stock oldS = null;
            Stock newS = new Stock();
            try
            {
                oldS = new StockService().GetByGoodNo(goodNoNum, warehouseNoNum);
            }
            catch (Exception exp)
            {
                if (exp.Message == "记录不存在")
                {
                    ifNew = true;
                }
                else
                {
                    Console.WriteLine("StockManager-Out-exp1"); //DEBUG
                    throw exp;
                }
            }
            if(ifNew)
            {
                //新建
                int newPrice = -1 * outCountNum * outSinglePriceNum;
                int newOutCountNum = -1 * outCountNum;
                newS = GetModel(-1, goodNoNum, warehouseNoNum, type, reason, 0, 0, outCountNum,outSinglePriceNum, newOutCountNum, newPrice, businessUnitNoNum, operatorLoginName, date);
                new StockService().Add(newS);
            }
            else
            {
                //修改
                int oldCount;
                int oldPrice;
                int newCount;
                int newPrice;
                //修改
                oldCount = oldS.RemainingCount;
                oldPrice = oldS.RemainingPrice;
                newCount = oldCount - outCountNum;
                newPrice = oldPrice - (outCountNum * outSinglePriceNum);
                newS = GetModel(-1, goodNoNum, warehouseNoNum, type, reason, 0, 0, outCountNum, outSinglePriceNum, newCount, newPrice, businessUnitNoNum, operatorLoginName, date);
                new StockService().Add(newS);
            }
        }

        public void ReturnChange(string stockNo)
        {
            int stockNoNum;
            if(!Int32.TryParse(stockNo, out stockNoNum))
            {
                throw new Exception("记录编号错误!");
            }
            new StockService().Return(stockNoNum);
        }
        public void ReturnCancelChange(string stockNo)
        {
            int stockNoNum;
            if (!Int32.TryParse(stockNo, out stockNoNum))
            {
                throw new Exception("记录编号错误!");
            }
            new StockService().CancelReturn(stockNoNum);
        }

        //仅允许两位小数存在(否则抛出异常)，返回金额为分
        public static int GetValue(string singlePrice)
        {
            double singlePriceNumDouble = 0;
            int singlePriceNum = 0;
            int dotPos = -1;
            for (int i = 0; i < singlePrice.Length; i++)
            {
                if (singlePrice[i] == '.')
                {
                    dotPos = i;
                    break;
                }
            }
            if (dotPos != -1)
            {
                try { singlePrice = singlePrice.Remove(dotPos + 3); }
                catch (Exception exp) { }
            }

            //清洗输入的金额数据
            if (!Double.TryParse(singlePrice, out singlePriceNumDouble) || singlePriceNumDouble < 0) throw new Exception("入库单价错误");
            try
            {
                singlePrice = string.Format("{0:N}", singlePriceNumDouble);
                singlePrice = singlePrice.Replace(".", string.Empty);
                singlePrice = singlePrice.Replace(",", string.Empty);
            }
            catch (Exception exp)
            {
                throw new Exception("入库单价输入错误");
            }
            if (!Int32.TryParse(singlePrice, out singlePriceNum) || singlePriceNum < 0) throw new Exception("入库单价转换错误");
            return singlePriceNum;
        }
    }
}
