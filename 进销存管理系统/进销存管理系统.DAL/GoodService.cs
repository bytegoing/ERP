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
    public class GoodService
    {
        //由DataTable获取List<Model>
        public List<Good> ToModel(DataTable dt)
        {
            List<Good> list = new List<Good>();
            Good g;
            for(int i = 0;i < dt.Rows.Count;i++)
            {
                g = new Good();
                g.No = (int)dt.Rows[i]["G_No"];
                g.Name = dt.Rows[i]["G_Name"].ToString();
                g.Package = dt.Rows[i]["G_Package"].ToString();
                g.Unit = dt.Rows[i]["G_Unit"].ToString();
                g.Type = (int)dt.Rows[i]["G_Type"];
                g.TypeName = dt.Rows[i]["GT_Name"].ToString();
                g.MaxInventory = (int)dt.Rows[i]["G_MaxInventory"];
                g.MinInventory = (int)dt.Rows[i]["G_MinInventory"];
                g.Remark = dt.Rows[i]["G_Remark"].ToString();
                list.Add(g);
            }
            return list;
        }

        //获取商品Model
        public Good Get(int no)
        {
            string sqlStr = "SELECT tbl_Good.*, tbl_GoodType.GT_Name FROM tbl_Good, tbl_GoodType WHERE tbl_Good.G_type = tbl_GoodType.GT_No AND tbl_Good.G_No = " + no;
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("商品不存在");
            return ToModel(ds.Tables[0])[0];
        }

        //重载 获取商品列表Model
        public List<Good> Get(string condition, string find)
        {
            string sqlStr = "SELECT tbl_Good.*, tbl_GoodType.GT_Name FROM tbl_Good, tbl_GoodType WHERE tbl_Good.G_type = tbl_GoodType.GT_No ";
            if (condition != string.Empty)
            {
                sqlStr += String.Format(" AND {0} = '{1}' ", condition, find);
            }
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        //添加商品信息
        public void Add(Good g)
        {
            string sqlStr = String.Format("INSERT INTO tbl_Good VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                g.Name, g.Package, g.Unit, g.Type, g.MaxInventory, g.MinInventory, g.Remark);
            SqlHelper.Execute(sqlStr);
        }

        //删除商品信息
        public void Delete(int no)
        {
            string sqlStr = String.Format("DELETE FROM tbl_Good WHERE G_No = '{0}'", no);
            SqlHelper.Execute(sqlStr);
        }

        //修改信息
        public void ChangeInfo(Good g)
        {
            string sqlStr = String.Format("UPDATE tbl_Good SET G_Name = '{0}', G_Package = '{1}', G_Unit = '{2}', "
                + "G_Type = '{3}', G_MaxInventory = '{4}', G_MinInventory = '{5}', G_Remark = '{6}' WHERE G_No = '{7}' ",
                g.Name, g.Package, g.Unit, g.Type, g.MaxInventory, g.MinInventory, g.Remark, g.No);
            SqlHelper.Execute(sqlStr);
        }
    }
}
