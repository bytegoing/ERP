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
    public class GoodTypeService
    {
        //由DataTable获取Model
        public List<GoodType> ToModel(DataTable dt)
        {
            var list = new List<GoodType>();
            GoodType gt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gt = new GoodType();
                gt.No = (int)dt.Rows[i]["GT_No"];
                gt.Name = dt.Rows[i]["GT_Name"].ToString();
                gt.ParentNo = Convert.ToInt32(dt.Rows[i]["GT_ParentNo"].ToString());
                list.Add(gt);
            }
            return list;
        }

        public List<GoodType> Get()
        {
            string sqlStr = String.Format("SELECT * FROM tbl_GoodType");
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        public void Add(int parentId, string name)
        {
            string sqlStr = String.Format("INSERT INTO tbl_GoodType VALUES ('{0}', '{1}')", name, parentId);
            SqlHelper.Execute(sqlStr);
        }

        public void Delete(int id)
        {
            string sqlStr = String.Format("DELETE FROM tbl_GoodType WHERE GT_No = '{0}' OR GT_ParentNo = '{1}'", id, id);
            SqlHelper.Execute(sqlStr);
        }

        public void Update(GoodType gt)
        {
            string sqlStr = String.Format("UPDATE tbl_GoodType SET GT_Name = '{0}', GT_ParentNo = '{1}' WHERE GT_No = '{2}'",
                gt.Name, gt.ParentNo, gt.No);
            SqlHelper.Execute(sqlStr);
        }
    }
}
