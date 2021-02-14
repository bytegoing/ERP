using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.DAL;
using 进销存管理系统.Models;

namespace 进销存管理系统.BLL
{
    public class WarehouseManager
    {
        public Warehouse Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("仓库编号不正确!");
            }
            return new WarehouseService().Get(n);
        }

        public List<Warehouse> GetList(string condition = "", string find = "")
        {
            switch (condition)
            {
                case "仓库名称":
                    condition = " W_Name ";
                    break;
                case "不筛选":
                default:
                    condition = "";
                    break;
            }
            return new WarehouseService().Get(condition, find);
        }

        private void ValidateInfo(string name, string address)
        {
            if (name == string.Empty)
            {
                throw new Exception("请填写名称!");
            }
            if (name.Length > 10)
            {
                throw new Exception("名称填写太长!");
            }
            if (address.Length > 100)
            {
                throw new Exception("地址填写太长!");
            }
        }

        private Warehouse GetModel(int no, string name, string address)
        {
            Warehouse w = new Warehouse();
            w.No = no;
            w.Name = name;
            w.Address = address;
            return w;
        }

        public void ChangeInfo(string no, string name, string address)
        {
            int noInt;
            ValidateInfo(name, address);
            if(!Int32.TryParse(no, out noInt))
            {
                throw new Exception("编号不正确!");
            }
            new WarehouseService().ChangeInfo(GetModel(noInt, name, address));
        }

        public void Add(string name, string address)
        {
            ValidateInfo(name, address);
            new WarehouseService().Add(GetModel(-1, name, address));
        }

        public void Delete(string no)
        {
            int noInt;
            if (!Int32.TryParse(no, out noInt))
            {
                throw new Exception("编号不正确!");
            }
            new WarehouseService().Delete(noInt);
        }
    }
}
