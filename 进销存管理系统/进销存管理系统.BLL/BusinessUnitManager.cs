using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.DAL;
using 进销存管理系统.Models;

namespace 进销存管理系统.BLL
{
    public class BusinessUnitManager
    {
        public BusinessUnit Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("编号不正确!");
            }
            return new BusinessUnitService().Get(n);
        }

        public List<BusinessUnit> GetList(string type, string condition = "", string find = "")
        {
            if (type == string.Empty || type == null)
            {
                throw new Exception("类型不正确!");
            }
            switch (condition)
            {
                case "名称":
                    condition = " BU_Name ";
                    break;
                case "联系人姓名":
                    condition = " BU_ContactName ";
                    break;
                case "不筛选":
                default:
                    condition = "";
                    break;
            }
            return new BusinessUnitService().Get(type, condition, find);
        }

        private void ValidateInfo(string name, string type, string address, string contactName, string phone, string email)
        {
            if (name == string.Empty)
            {
                throw new Exception("请填写名称!");
            }
            if (name.Length > 20)
            {
                throw new Exception("名称填写太长!");
            }
            if (type == string.Empty)
            {
                throw new Exception("类别为空!");
            }
            if (type.Length > 10)
            {
                throw new Exception("类别太长!");
            }
            if (address.Length > 100)
            {
                throw new Exception("地址太长!");
            }
            if (contactName.Length > 10)
            {
                throw new Exception("联系人姓名太长!");
            }
            if (phone.Length > 11)
            {
                throw new Exception("联系电话太长");
            }
            if (email.Length > 50)
            {
                throw new Exception("Email太长");
            }
        }

        private BusinessUnit GetModel(int no, string name, string type, string address, string contactName, string phone, string email)
        {
            BusinessUnit bu = new BusinessUnit();
            bu.No = no;
            bu.Name = name;
            bu.Type = type;
            bu.Address = address;
            bu.ContactName = contactName;
            bu.Phone = phone;
            bu.Email = email;
            return bu;
        }

        public void ChangeInfo(string no, string name, string address, string contactName, string phone, string email)
        {
            //更改时无需类别信息
            ValidateInfo(name, "类别占位", address, contactName, phone, email);
            int noInt;
            if (!Int32.TryParse(no, out noInt))
            {
                throw new Exception("编号不正确!");
            }
            new BusinessUnitService().ChangeInfo(GetModel(noInt, name, "类别占位", address, contactName, phone, email));
        }

        public void Add(string name, string type, string address, string contactName, string phone, string email)
        {
            ValidateInfo(name, type, address, contactName, phone, email);
            new BusinessUnitService().Add(GetModel(-1, name, type, address, contactName, phone, email));
        }

        public void Delete(string no)
        {
            int noInt;
            if (!Int32.TryParse(no, out noInt))
            {
                throw new Exception("编号不正确!");
            }
            new BusinessUnitService().Delete(noInt);
        }
    }
}
