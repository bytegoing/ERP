using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 进销存管理系统.DAL;

namespace 进销存管理系统.BLL
{
    public class DataManager
    {
        public void Backup(string fileName)
        {
            new DataService().Backup(fileName);
        }

        public void Restore(string fileName)
        {
            new DataService().Restore(fileName);
        }
    }
}
