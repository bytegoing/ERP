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
    public class UserService
    {
        //由DataTable获取List<Model>
        private List<User> ToModel(DataTable dt, bool keepPassword = false, bool keepPermission = false)
        {
            List<User> usrList = new List<User>();
            User usr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                usr = new User();
                usr.LoginName = dt.Rows[i]["U_LoginName"].ToString();
                if (keepPassword) usr.Password = dt.Rows[i]["U_Password"].ToString();
                if (keepPermission) usr.Permission = dt.Rows[i]["U_Permission"].ToString();
                usr.Name = dt.Rows[i]["U_Name"].ToString();
                usr.Sex = dt.Rows[i]["U_Sex"].ToString();
                usr.Department = dt.Rows[i]["U_Department"].ToString();
                usr.Phone = dt.Rows[i]["U_Phone"].ToString();
                usr.Birthday = (dt.Rows[i]["U_Birthday"] == DBNull.Value) ? default(DateTime) : (DateTime)dt.Rows[i]["U_Birthday"];
                usr.EntryDate = (dt.Rows[i]["U_EntryDate"] == DBNull.Value) ? default(DateTime) : (DateTime)dt.Rows[i]["U_EntryDate"];
                usrList.Add(usr);
            }
            return usrList;
        }

        //获取单人Model
        public User Get(string username, bool keepPassword = true, bool keepPermission = true)
        {
            string sqlStr = string.Format("SELECT * FROM tbl_User WHERE U_LoginName = '{0}'", username);
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("用户不存在");
            return ToModel(ds.Tables[0], keepPassword, keepPermission)[0];
        }
        
        //重载 获取列表的List<Model>
        public List<User> Get(string condition, string find, bool keepPassword = false, bool keepPermission = false)
        {
            string sqlStr = String.Format("SELECT * FROM tbl_User ");
            if (condition != string.Empty)
            {
                sqlStr += String.Format(" WHERE {0} = '{1}' ", condition, find);
            }
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        //修改信息,注意:每一次只能修改密码或信息
        public void ChangeInfo(User usr)
        {
            //先区分类型
            string sqlStr = String.Format("UPDATE tbl_User SET ");
            if (usr.Password != string.Empty && usr.Password != null)
            {
                //修改密码
                sqlStr += String.Format(" U_Password = '{0}' ", usr.Password);
            }
            else
            {
                //修改信息
                sqlStr += String.Format(" U_Name = '{0}', U_Sex = '{1}', U_Department = '{2}', U_Phone = '{3}', U_Birthday = '{4}', U_EntryDate = '{5}', U_Permission = '{6}' ",
                    usr.Name, usr.Sex, usr.Department, usr.Phone, usr.Birthday, usr.EntryDate, usr.Permission);
            }
            sqlStr += String.Format(" WHERE U_LoginName = '{0}' ", usr.LoginName);
            SqlHelper.Execute(sqlStr);
        }

        //添加用户
        public void Add(User usr)
        {
            string sqlStr = String.Format("INSERT INTO tbl_User VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' )", 
                usr.LoginName, usr.Password, usr.Permission, usr.Name, usr.Sex, usr.Department, usr.Phone, usr.Birthday, usr.EntryDate);
            SqlHelper.Execute(sqlStr);
        }

        //删除用户
        public void Delete(string username)
        {
            string sqlStr = String.Format("DELETE FROM tbl_User WHERE U_LoginName = '{0}'", username);
            SqlHelper.Execute(sqlStr);
        }
    }
}
