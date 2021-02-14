using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class Good
    {
        private int no;
        private string name;
        private string package;
        private string unit;
        private int type;
        private string typeName;
        private int maxInventory;
        private int minInventory;
        private string remark;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Package { get => package; set => package = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Type { get => type; set => type = value; }
        public string TypeName { get => typeName; set => typeName = value; }
        public int MaxInventory { get => maxInventory; set => maxInventory = value; }
        public int MinInventory { get => minInventory; set => minInventory = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
