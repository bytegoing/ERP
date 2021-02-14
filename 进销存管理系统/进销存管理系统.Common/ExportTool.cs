using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel; //导出Excel
using System.Windows.Forms.DataVisualization.Charting;

namespace 进销存管理系统.Common
{
    public class ExportTool
    {
        //从dataGridView导出到Excel文件,自动弹出选择窗口,无异常
        public static void dataGridViewToExcel(DataGridView dgv)
        {
            if (!MsgBox.ShowAsk("数据量较多时可能耗时较长甚至停止响应,若发生此现象请耐心等待!请问是否继续导出?")) return;
            //申明保存对话框 
            SaveFileDialog dlg = new SaveFileDialog();
            //默认文件后缀 
            dlg.DefaultExt = "xls ";
            //文件后缀列表 
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默认路径是系统当前路径 
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框 
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径 
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效 
            if (fileNameString.Trim() == "") return;
            //定义表格内数据的行数和列数 
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0 
            if (rowscount <= 0)
            {
                MsgBox.ShowError("没有信息可供保存");
                return;
            }
            //列数必须大于0 
            if (colscount <= 0)
            {
                MsgBox.ShowError("没有信息可供保存");
                return;
            }
            //行数不可以大于65536 
            if (rowscount > 65536)
            {
                MsgBox.ShowError("数据记录数太多(最多不能超过65536条)，不能保存");
                return;
            }
            //列数不可以大于255 
            if (colscount > 255)
            {
                MsgBox.ShowError("数据记录列数太多，不能保存");
                return;
            }
            //验证以fileNameString命名的文件是否存在，如果存在则报错
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                MsgBox.ShowError("文件已存在!不能保存");
                return;
            }
            Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;
            try
            {
                //声明对象 
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                objExcel.Visible = false; //设置参数
                //向Excel中写入表格的表头
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible) //如果被隐藏则不写入Excel
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //向Excel中逐行逐列写入表格中的数据 
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible) //如果被隐藏则不写入Excel
                        {
                            try
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception) { }
                        }
                    }
                }
                //保存文件 
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MsgBox.ShowError("错误:" + error.Message);
                return;
            }
            finally
            {
                //关闭Excel应用 
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();
                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MsgBox.ShowInfo("成功保存到: \r\n"+fileNameString);
        }

        //导出图表
        public static void ExportChart(Chart chart1)
        {
            if (!MsgBox.ShowAsk("数据量较多时可能耗时较长甚至停止响应,若发生此现象请耐心等待!请问是否继续导出?")) return;
            SaveFileDialog savefile = new SaveFileDialog();
            try
            {
                savefile.Filter = "JPEG文件|*.jpg";
                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    chart1.SaveImage(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch(Exception exp)
            {
                MsgBox.ShowError("错误: " + exp.Message);
                return;
            }
            MsgBox.ShowInfo("成功保存到: \r\n" + savefile.FileName);
        }
    }
}
