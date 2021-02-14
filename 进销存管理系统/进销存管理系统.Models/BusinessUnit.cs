using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class BusinessUnit
    {
        private int no;
        private string name;
        private string type;
        private string address;
        private string contactName;
        private string phone;
        private string email;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Address { get => address; set => address = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
