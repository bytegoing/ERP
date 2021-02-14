using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.DAL;
using 进销存管理系统.Models;

namespace 进销存管理系统.BLL
{
    public class GoodManager
    {
        public Good Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("商品编号不正确!");
            }
            return new GoodService().Get(n);
        }

        public List<Good> GetList(string condition = "", string find = "")
        {
            switch (condition)
            {
                case "商品名称":
                    condition = " G_Name ";
                    break;
                case "商品类别":
                    condition = " GT_Name ";
                    break;
                case "不筛选":
                default:
                    condition = "";
                    break;
            }
            return new GoodService().Get(condition, find);
        }

        private void ValidateInfo(string name, string package, string unit, string remark)
        {
            if (name == string.Empty)
            {
                throw new Exception("请填写姓名!");
            }
            if(name.Length > 30)
            {
                throw new Exception("商品名称填写太长!");
            }
            if(package.Length > 10)
            {
                throw new Exception("规格填写太长");
            }
            if(unit.Length > 5)
            {
                throw new Exception("单位填写太长");
            }
            if(remark.Length > 100)
            {
                throw new Exception("备注填写太长!");
            }
        }

        //获取Model
        private Good GetModel(int no, string name, string package, string unit, int type, int max, int min, string remark)
        {
            Good g = new Good();
            g.No = no;
            g.Name = name;
            g.Package = package;
            g.Unit = unit;
            g.Type = type;
            g.MaxInventory = max;
            g.MinInventory = min;
            g.Remark = remark;
            return g;
        }

        public void ChangeInfo(string no, string name, string package, string unit, string type, string max, string min, string remark)
        {
            ValidateInfo(name, package, unit, remark);
            int noInt, typeInt, maxInt, minInt;
            if(!Int32.TryParse(no, out noInt))
            {
                throw new Exception("编号不正确!");
            }
            if(!Int32.TryParse(type, out typeInt))
            {
                throw new Exception("类别选择不正确!");
            }
            if (!Int32.TryParse(max, out maxInt))
            {
                maxInt = 0;
            }
            if (!Int32.TryParse(min, out minInt))
            {
                minInt = 0;
            }
            new GoodService().ChangeInfo(GetModel(noInt, name, package, unit, typeInt, maxInt, minInt, remark));
        }

        public void Add(string name, string package, string unit, string type, string max, string min, string remark)
        {
            ValidateInfo(name, package, unit, remark);
            int typeInt, maxInt, minInt;
            if (!Int32.TryParse(type, out typeInt))
            {
                throw new Exception("类别选择不正确!");
            }
            if (!Int32.TryParse(max, out maxInt))
            {
                maxInt = 0;
            }
            if (!Int32.TryParse(min, out minInt))
            {
                minInt = 0;
            }
            new GoodService().Add(GetModel(-1, name, package, unit, typeInt, maxInt, minInt, remark));
        }

        public void Delete(string no)
        {
            int n;
            if(!Int32.TryParse(no, out n))
            {
                throw new Exception("商品编号不正确!");
            }
            new GoodService().Delete(n);
        }
    }
}
