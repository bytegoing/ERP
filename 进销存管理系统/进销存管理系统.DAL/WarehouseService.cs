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
    public class WarehouseService
    {
        //由DataTable获取List<Warehouse>
        public List<Warehouse> ToModel(DataTable dt)
        {
            List<Warehouse> list = new List<Warehouse>();
            Warehouse w;
            for(int i = 0;i < dt.Rows.Count;i++)
            {
                w = new Warehouse();
                w.No = (int)dt.Rows[i]["W_No"];
                w.Name = dt.Rows[i]["W_Name"].ToString();
                w.Address = dt.Rows[i]["W_Address"].ToString();
                list.Add(w);
            }
            return list;
        }

        //获取单个仓库Model
        public Warehouse Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_Warehouse WHERE W_No = " + no;
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("仓库不存在");
            return ToModel(ds.Tables[0])[0];
        }

        //重载 获取列表Model
        public List<Warehouse> Get(string condition, string find)
        {
            string sqlStr = "SELECT * FROM tbl_Warehouse ";
            if (condition != string.Empty)
            {
                sqlStr += String.Format(" WHERE {0} = '{1}' ", condition, find);
            }
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        public void Add(Warehouse w)
        {
            string sqlStr = String.Format("INSERT INTO tbl_Warehouse VALUES ('{0}', '{1}')",
                w.Name, w.Address);
            SqlHelper.Execute(sqlStr);
        }

        public void Delete(int no)
        {
            string sqlStr = String.Format("DELETE FROM tbl_Warehouse WHERE W_No = {0}", no);
            SqlHelper.Execute(sqlStr);
        }

        public void ChangeInfo(Warehouse w)
        {
            string sqlStr = String.Format("UPDATE tbl_Warehouse SET W_Name = '{0}', W_Address = '{1}' WHERE W_No = '{2}' ",
                w.Name, w.Address, w.No);
            SqlHelper.Execute(sqlStr);
        }
    }
}
