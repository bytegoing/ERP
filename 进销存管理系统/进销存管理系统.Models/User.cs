using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class User
    {
        private string loginName;
        private string password;
        private string permission;
        private string name;
        private string sex;
        private string department;
        private string phone;
        private DateTime birthday;
        private DateTime entryDate;

        public string LoginName { get => loginName; set => loginName = value; }
        public string Password { get => password; set => password = value; }
        public string Permission { get => permission; set => permission = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Department { get => department; set => department = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
    }
}
