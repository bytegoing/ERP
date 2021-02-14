using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class GoodType
    {
        private int no;
        private string name;
        private int parentNo;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public int ParentNo { get => parentNo; set => parentNo = value; }
    }
}
