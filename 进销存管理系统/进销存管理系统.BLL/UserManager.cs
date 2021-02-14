using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using 进销存管理系统.DAL;
using 进销存管理系统.Models;

namespace 进销存管理系统.BLL
{
    public class UserManager
    {
        //根据给定字符串生成MD5.由于仅仅在用户相关用到，故没有封装到Common中
        public static string GetMD5(string originStr)
        {
            MD5 md5 = MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(originStr);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        //获取信息
        public User Get(string username, bool keepPassword = true, bool keepPermission = true)
        {
            return new UserService().Get(username, keepPassword, keepPermission);
        }

        //返回List<Model>
        public List<User> GetList(string condition = "", string find = "", bool keepPassword = false, bool keepPermission = false)
        {
            switch (condition)
            {
                case "员工用户名":
                    condition = " U_LoginName ";
                    break;
                case "员工姓名":
                    condition = " U_Name ";
                    break;
                case "员工部门":
                    condition = " U_Department ";
                    break;
                case "不筛选":
                default:
                    condition = "";
                    break;
            }
            return new UserService().Get(condition, find, keepPassword, keepPermission);
        }

        //检查某人是否有某权限
        public bool IfGranted(User usr, char permission)
        {
            if (usr.Permission.IndexOf(permission) > -1) return true;
            else return false;
        }

        //更改密码
        public void ChangePassword(string username, string newPassword)
        {
            if(newPassword == string.Empty)
            {
                throw new Exception("请输入新密码!");
            }
            newPassword = GetMD5(newPassword);
            User usr = new User();
            usr.LoginName = username;
            usr.Password = newPassword;
            new UserService().ChangeInfo(usr);
        }

        //校验必要的参数
        private void ValidateInfo(string username, string name, string department, string phone)
        {
            if (username == string.Empty)
            {
                throw new Exception("用户名为空!");
            }
            if(username.Length > 20)
            {
                throw new Exception("用户名长度过长!");
            }
            if (name == string.Empty)
            {
                throw new Exception("姓名不能为空!");
            }
            if (name.Length > 10)
            {
                throw new Exception("姓名过长!");
            }
            if (department.Length > 20)
            {
                throw new Exception("部门的字数过长!请限制在20字以内!");
            }
            if (phone.Length > 11)
            {
                throw new Exception("联系电话字数过长!请限制在11字以内!");
            }
        }

        //生成UserModel
        private User GetModel(string username, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate, string password = null)
        {
            User newUsr = new User();
            newUsr.LoginName = username;
            newUsr.Name = name;
            newUsr.Password = password;
            newUsr.Sex = sex;
            newUsr.Department = department;
            newUsr.Phone = phone;
            newUsr.Birthday = birthday;
            newUsr.EntryDate = entryDate;
            newUsr.Permission = permission;
            return newUsr;
        }

        //更改信息
        public void ChangeInfo(string username, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate)
        {
            ValidateInfo(username, name, department, phone);
            if (username.ToLower() == "admin") throw new Exception("不允许修改管理员的信息!");
            new UserService().ChangeInfo(GetModel(username, permission, name, sex, department, phone, birthday, entryDate));
            
        }

        //新增用户
        public void Add(string username, string password, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate)
        {
            ValidateInfo(username, name, department, phone);
            if (username.ToLower() == "admin") throw new Exception("管理员已存在!");
            if (password == string.Empty) throw new Exception("请填写密码!");
            //查找是否有同用户名账户
            try
            {
                new UserService().Get(username);
            }
            catch (Exception exp)
            {
                if (exp.Message != "用户不存在")
                {
                    throw exp;
                }
            }
            new UserService().Add(GetModel(username, permission, name, sex, department, phone, birthday, entryDate, GetMD5(password)));
        }

        //删除用户
        public void Delete(string username)
        {
            new UserService().Delete(username);
        }

    }
}
