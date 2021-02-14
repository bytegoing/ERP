using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.DAL
{
    public class DataService
    {
        public void Backup(string fileName)
        {
            string databaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];
            string sqlStr = String.Format("USE master; " +
                "BACKUP DATABASE {0} TO disk = '{1}'; ", databaseName, fileName);
            SqlHelper.Execute(sqlStr);
        }

        public void Restore(string fileName)
        {
            string databaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];
            string sqlStr = String.Format("USE master; " +
                "ALTER DATABASE {0} SET OFFLINE WITH ROLLBACK IMMEDIATE; " +
                " RESTORE DATABASE {1} FROM disk='{2}' WITH REPLACE; " +
                " ALTER DATABASE {3} SET ONLINE WITH ROLLBACK IMMEDIATE; ", databaseName, databaseName, fileName, databaseName);
            SqlHelper.Execute(sqlStr);
        }
    }
}
