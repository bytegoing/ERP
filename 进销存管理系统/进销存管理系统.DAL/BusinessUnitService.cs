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
    public class BusinessUnitService
    {
        //由DataTable获取List
        public List<BusinessUnit> ToModel(DataTable dt)
        {
            List<BusinessUnit> list = new List<BusinessUnit>();
            BusinessUnit bu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bu = new BusinessUnit();
                bu.No = (int)dt.Rows[i]["BU_No"];
                bu.Name = dt.Rows[i]["BU_Name"].ToString();
                bu.Type = dt.Rows[i]["BU_Type"].ToString();
                bu.Address = dt.Rows[i]["BU_Address"].ToString();
                bu.ContactName = dt.Rows[i]["BU_ContactName"].ToString();
                bu.Phone = dt.Rows[i]["BU_Phone"].ToString();
                bu.Email = dt.Rows[i]["BU_Email"].ToString();
                list.Add(bu);
            }
            return list;
        }

        //获取单个
        public BusinessUnit Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_BusinessUnit WHERE BU_No = " + no;
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("往来单位不存在");
            return ToModel(ds.Tables[0])[0];
        }

        public List<BusinessUnit> Get(string type, string condition, string find)
        {
            string sqlStr = "SELECT * FROM tbl_BusinessUnit WHERE BU_Type = '" + type + "' ";
            if (condition != string.Empty)
            {
                sqlStr += String.Format(" AND {0} = '{1}' ", condition, find);
            }
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        public void Add(BusinessUnit bu)
        {
            string sqlStr = string.Format("INSERT INTO tbl_BusinessUnit VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ",
                bu.Name, bu.Type, bu.Address, bu.ContactName, bu.Phone, bu.Email);
            SqlHelper.Execute(sqlStr);
        }

        public void Delete(int no)
        {
            string sqlStr = String.Format("DELETE FROM tbl_BusinessUnit WHERE BU_No = {0}", no);
            SqlHelper.Execute(sqlStr);
        }

        public void ChangeInfo(BusinessUnit bu)
        {
            //无需类别信息
            string sqlStr = String.Format("UPDATE tbl_BusinessUnit SET BU_Name = '{0}', BU_Address = '{1}', BU_ContactName = '{2}', BU_Phone = '{3}', BU_Email = '{4}' WHERE BU_No = '{5}' ",
                bu.Name, bu.Address, bu.ContactName, bu.Phone, bu.Email, bu.No);
            SqlHelper.Execute(sqlStr);
        }
    }
}
