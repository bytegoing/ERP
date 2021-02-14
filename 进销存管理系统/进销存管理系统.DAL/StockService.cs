using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using 进销存管理系统.Models;

namespace 进销存管理系统.DAL
{
    public class StockService
    {
        //由DataTable获取List<Model>
        public List<Stock> ToModel(DataTable dt, bool typeConverted = true)
        {
            List<Stock> list = new List<Stock>();
            Stock s;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s = new Stock();
                s.No = typeConverted ? (int)dt.Rows[i]["S_No"] : Convert.ToInt32(dt.Rows[i]["S_No"]);
                s.GoodNo = typeConverted ? (int)dt.Rows[i]["S_GoodNo"] : Convert.ToInt32(dt.Rows[i]["S_GoodNo"]);
                s.GoodName = dt.Rows[i]["G_Name"].ToString();
                s.GoodTypeName = dt.Rows[i]["GT_Name"].ToString();
                s.WarehouseNo = typeConverted ? (int)dt.Rows[i]["S_WarehouseNo"] : Convert.ToInt32(dt.Rows[i]["S_WarehouseNo"]);
                s.WarehouseName = dt.Rows[i]["W_Name"].ToString();
                s.Type = dt.Rows[i]["S_Type"].ToString();
                s.Reason = dt.Rows[i]["S_Reason"].ToString();
                s.InCount = typeConverted ? (int)dt.Rows[i]["S_In_Count"] : Convert.ToInt32(dt.Rows[i]["S_In_Count"]);
                s.InSinglePrice = typeConverted ? (int)dt.Rows[i]["S_In_SinglePrice"] : Convert.ToInt32(dt.Rows[i]["S_In_SinglePrice"]);
                s.InSinglePriceYuan = (s.InSinglePrice / 100.0).ToString("f2");
                s.OutCount = typeConverted ? (int)dt.Rows[i]["S_Out_Count"] : Convert.ToInt32(dt.Rows[i]["S_Out_Count"]);
                s.OutSinglePrice = typeConverted ? (int)dt.Rows[i]["S_Out_SinglePrice"] : Convert.ToInt32(dt.Rows[i]["S_Out_SinglePrice"]);
                s.OutSinglePriceYuan = (s.OutSinglePrice / 100.0).ToString("f2");
                s.RemainingCount = typeConverted ? (int)dt.Rows[i]["S_Remaining_Count"] : Convert.ToInt32(dt.Rows[i]["S_Remaining_Count"]);
                s.RemainingPrice = typeConverted ? (int)dt.Rows[i]["S_Remaining_Price"] : Convert.ToInt32(dt.Rows[i]["S_Remaining_Price"]);
                s.RemainingPriceYuan = (s.RemainingPrice / 100.0).ToString("f2");
                if(dt.Rows[i]["S_BusinessUnitNo"] == DBNull.Value)
                {
                    s.BusinessUnitNo = -1;
                    s.BusinessUnitName = "";
                    s.BusinessUnitType = "";
                }
                else
                {
                    s.BusinessUnitNo = typeConverted ? (int)dt.Rows[i]["S_BusinessUnitNo"] : Convert.ToInt32(dt.Rows[i]["S_BusinessUnitNo"]);
                    s.BusinessUnitType = dt.Rows[i]["BU_Type"].ToString();
                    s.BusinessUnitName = dt.Rows[i]["BU_Name"].ToString();
                }
                s.OperatorNo = dt.Rows[i]["S_OperatorLoginName"].ToString();
                s.OperatorName = dt.Rows[i]["U_Name"].ToString();
                s.Date = Convert.ToDateTime(dt.Rows[i]["S_Date"]);
                list.Add(s);
            }
            return list;
        }

        public Stock Get(int no)
        {
            string sqlStr = "SELECT tbl_Stock.*, tbl_Good.G_Name, tbl_Warehouse.W_Name, tbl_BusinessUnit.BU_Type, tbl_BusinessUnit.BU_Name, tbl_User.U_Name, tbl_GoodType.GT_Name " +
                "FROM tbl_Stock, tbl_Good, tbl_Warehouse, tbl_BusinessUnit, tbl_User, tbl_GoodType " +
                "WHERE tbl_Good.G_No = tbl_Stock.S_GoodNo AND tbl_Stock.S_WarehouseNo = tbl_Warehouse.W_No AND tbl_BusinessUnit.BU_No = tbl_Stock.S_BusinessUnitNo AND tbl_User.U_LoginName = tbl_Stock.S_OperatorLoginName AND tbl_Good.G_Type = tbl_GoodType.GT_No " +
                "AND tbl_Stock.S_No = " + no + " ORDER BY tbl_Stock.S_No DESC ";
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("记录不存在");
            return ToModel(ds.Tables[0])[0];
        }

        public Stock GetByGoodNo(int goodNo, int warehouseNo)
        {
            List<Stock> list = GetLatestStockList(string.Format(" tbl_Stock.S_GoodNo = '{0}' AND tbl_Stock.S_WarehouseNo = '{1}' ", goodNo, warehouseNo));
            if (list.Count == 0) throw new Exception("记录不存在");
            int maxPos = 0;
            for(int i = 1;i < list.Count;i++)
            {
                if (list[maxPos].No < list[i].No) maxPos = i;
            }
            return list[maxPos];
        }
        
        //获取最新库存列表
        public List<Stock> GetLatestStockList(string sqlConditions)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>(); //存放 商品id=>最新的stockNo
            string sqlStr = "SELECT tbl_Stock.*, tbl_Good.G_Name, tbl_Warehouse.W_Name, tbl_User.U_Name, tbl_GoodType.GT_Name " +
                "FROM tbl_Stock, tbl_Good, tbl_Warehouse, tbl_User, tbl_GoodType " +
                "WHERE tbl_Good.G_No = tbl_Stock.S_GoodNo AND tbl_Stock.S_WarehouseNo = tbl_Warehouse.W_No AND tbl_User.U_LoginName = tbl_Stock.S_OperatorLoginName AND tbl_Good.G_Type = tbl_GoodType.GT_No ";
            if (sqlConditions != string.Empty)
            {
                sqlStr += " AND " + sqlConditions + " ";
            }
            sqlStr += " ORDER BY S_No DESC ";
            DataSet ds = SqlHelper.Query(sqlStr);
            DataTable dt = ds.Tables[0];
            int nowStockNo;
            for(int i = 0;i < dt.Rows.Count;i++)
            {
                try
                {
                    dict.TryGetValue((int)dt.Rows[i]["S_GoodNo"], out nowStockNo);
                    if(nowStockNo < (int)dt.Rows[i]["S_No"])
                    {
                        //更新为最新的StockNo
                        dict[(int)dt.Rows[i]["S_GoodNo"]] = (int)dt.Rows[i]["S_No"];
                    }
                }
                catch(Exception)
                {
                    //还没有加入过
                    dict.Add((int)dt.Rows[i]["S_GoodNo"], (int)dt.Rows[i]["S_No"]);
                }
            }
            sqlStr = "SELECT tbl_Stock.*, tbl_Good.G_Name, tbl_Warehouse.W_Name, tbl_BusinessUnit.BU_Type, tbl_BusinessUnit.BU_Name, tbl_User.U_Name, tbl_GoodType.GT_Name "+
                     "FROM tbl_Stock, tbl_Good, tbl_Warehouse, tbl_BusinessUnit, tbl_User, tbl_GoodType " +
                     "WHERE tbl_Good.G_No = tbl_Stock.S_GoodNo AND tbl_Stock.S_WarehouseNo = tbl_Warehouse.W_No AND (tbl_BusinessUnit.BU_No = tbl_Stock.S_BusinessUnitNo OR S_BusinessUnitNo IS NULL) AND tbl_User.U_LoginName = tbl_Stock.S_OperatorLoginName AND tbl_Good.G_Type = tbl_GoodType.GT_No " + 
                     "AND tbl_Stock.S_No = ";
            DataTable resultDt = new DataTable();
            bool ifAddedStructure = false;
            Dictionary<int, int>.ValueCollection dictValues = dict.Values;
            foreach (int i in dictValues)
            {
                dt = SqlHelper.Query(sqlStr + i).Tables[0];
                if(!ifAddedStructure)
                {
                    //加入structure
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        resultDt.Columns.Add(dt.Columns[j].ColumnName);//有重载的方法，可以加入列数据的类型
                    }
                    ifAddedStructure = true;
                }
                resultDt.ImportRow(dt.Rows[0]);
            }
            return ToModel(resultDt, false);
        }

        public List<Stock> GetTotalList()
        {
            List<Stock> list1 = GetList("");
            string sqlStr = "SELECT tbl_Stock.*, tbl_Good.G_Name, tbl_Warehouse.W_Name, tbl_User.U_Name, tbl_GoodType.GT_Name "+
                            "FROM tbl_Stock, tbl_Good, tbl_Warehouse, tbl_User, tbl_GoodType "+
                            "WHERE tbl_Good.G_No = tbl_Stock.S_GoodNo AND tbl_Stock.S_WarehouseNo = tbl_Warehouse.W_No AND tbl_Stock.S_BusinessUnitNo IS NULL "+
                            "AND tbl_User.U_LoginName = tbl_Stock.S_OperatorLoginName AND tbl_Good.G_Type = tbl_GoodType.GT_No  AND(1 = 1) ORDER BY tbl_Stock.S_No DESC ";
            List<Stock> list2 = ToModel(SqlHelper.Query(sqlStr).Tables[0]);
            List<Stock> result = list1.Union(list2).ToList<Stock>();
            return result;
        }

        public List<Stock> GetList(string sqlConditions)
        {
            string sqlStr = "SELECT tbl_Stock.*, tbl_Good.G_Name, tbl_Warehouse.W_Name, tbl_BusinessUnit.BU_Type, tbl_BusinessUnit.BU_Name, tbl_User.U_Name, tbl_GoodType.GT_Name " +
                "FROM tbl_Stock, tbl_Good, tbl_Warehouse, tbl_BusinessUnit, tbl_User, tbl_GoodType " +
                "WHERE tbl_Good.G_No = tbl_Stock.S_GoodNo AND tbl_Stock.S_WarehouseNo = tbl_Warehouse.W_No AND tbl_BusinessUnit.BU_No = tbl_Stock.S_BusinessUnitNo AND tbl_User.U_LoginName = tbl_Stock.S_OperatorLoginName AND tbl_Good.G_Type = tbl_GoodType.GT_No " +
                " AND ( ";
            if (sqlConditions != string.Empty)
            {
                sqlStr += " " + sqlConditions + " ";
            }
            else
            {
                sqlStr += " 1=1 ";
            }
            sqlStr += " )";
            sqlStr += " ORDER BY tbl_Stock.S_No DESC ";
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        public void Add(Stock s)
        {
            string businessUnitStr = (s.BusinessUnitNo == -1) ? "null" : s.BusinessUnitNo+"";
            string sqlStr = string.Format("INSERT INTO tbl_Stock VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}', '{12}')",
                s.GoodNo, s.WarehouseNo, s.Type, s.Reason, s.InCount, s.InSinglePrice, s.OutCount, s.OutSinglePrice, s.RemainingCount, s.RemainingPrice, businessUnitStr, s.OperatorNo, s.Date);
            SqlHelper.Execute(sqlStr);
        }

        public void Delete(int no)
        {
            string sqlStr = String.Format("DELETE FROM tbl_Stock WHERE S_No = {0}", no);
            SqlHelper.Execute(sqlStr);
        }

        public void ChangeInfo(Stock s)
        {
            string sqlStr = String.Format("UPDATE tbl_Stock SET S_GoodNo = '{0}', S_WarehouseNo = '{1}', S_Type = '{2}', S_Reason = '{3}', S_In_Count = '{4}', S_In_SinglePrice = '{5}', S_Out_Count = '{6}', S_Out_SinglePrice = '{7}', S_Remaining_Count = '{8}', S_Remaining_Price = '{9}', S_BusinessUnitNo = '{10}', S_OperatorLoginName = '{11}', S_Date = '{12}' WHERE S_No = '{13}' ",
                s.GoodNo, s.WarehouseNo, s.Type, s.Reason, s.InCount, s.InSinglePrice, s.OutCount, s.OutSinglePrice, s.RemainingCount, s.RemainingPrice, s.BusinessUnitNo, s.OperatorNo, s.Date, s.No);
            SqlHelper.Execute(sqlStr);
        }

        public void Return(int no)
        {
            string sqlStr = String.Format("UPDATE tbl_Stock SET S_Reason = '退货' WHERE S_No = " + no);
            SqlHelper.Execute(sqlStr);
        }

        public void CancelReturn(int no)
        {
            string sqlStr = String.Format("UPDATE tbl_Stock SET S_Reason = '' WHERE S_No = " + no);
            SqlHelper.Execute(sqlStr);
        }
    }
}
