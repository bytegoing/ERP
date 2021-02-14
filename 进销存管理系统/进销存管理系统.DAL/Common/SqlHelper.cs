using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace 进销存管理系统.DAL
{
    class SqlHelper
    {
        private static string connStr = String.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3}",
            System.Configuration.ConfigurationManager.AppSettings["DatabaseDatasource"],
            System.Configuration.ConfigurationManager.AppSettings["DatabaseUsername"],
            System.Configuration.ConfigurationManager.AppSettings["DatabasePassword"],
            System.Configuration.ConfigurationManager.AppSettings["DatabaseName"]);
        static SqlConnection conn;

        #region 公共查询代码，返回DataSet，表为0.需要捕获异常,无需关闭连接
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlStr">要执行的SQL查询语句</param>
        /// <returns>返回DataSet</returns>
        public static DataSet Query(string sqlStr)
        {
            DataSet dataSet = new DataSet(); //在try块外提前声明，避免成为try块的局部变量
            try
            {
                conn = new SqlConnection(connStr); //连接数据库
                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, conn);
                dataAdapter.Fill(dataSet); //将数据绑定到dataSet
                conn.Close();
            }
            catch (Exception exp)
            {
                conn.Close();
                throw new Exception("数据库错误: " + exp.Message);
            }
            return dataSet;
        }
        #endregion

        #region 公共执行非查询代码，需捕获异常，返回值为受影响行数，无需关闭连接
        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="sqlStr">要执行的非查询SQL语句</param>
        /// <returns>int返回受影响行数</returns>
        public static int Execute(string sqlStr)
        {
            int effectedRowCount = 0;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr);
                conn.Open();

                SqlCommand command = new SqlCommand(sqlStr, conn); //实例化对象
                effectedRowCount = command.ExecuteNonQuery(); //执行
                conn.Close(); //关闭连接
            }
            catch (Exception exp)
            {
                conn.Close(); //关闭连接
                throw new Exception("数据库错误: " + exp.Message);
            }
            return effectedRowCount;
        }
        #endregion
    }
}
