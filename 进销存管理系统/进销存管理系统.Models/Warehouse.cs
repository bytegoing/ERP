using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class Warehouse
    {
        private int no;
        private string name;
        private string address;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
    }
}
