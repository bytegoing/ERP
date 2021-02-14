using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using 进销存管理系统.BLL;
using 进销存管理系统.Models;
using 进销存管理系统.Common;
using 进销存管理系统.基础信息维护;
using 进销存管理系统.进销存;
using 进销存管理系统.统计与报表;
using System.IO;

namespace 进销存管理系统
{
    public partial class mainFrm : Form
    {
        public mainFrm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void Jump<T>(string type = "") where T : Form, new() //跳转函数，避免重复打开mdi窗口
        {
            bool find = false;
            foreach (Form f in this.MdiChildren)
            {
                //直接用类型来判断，不用text属性
                if (f is T)
                {
                    find = true;
                    f.Activate();
                }
            }
            if (find == false)
            {
                T t = new T();
                t.MdiParent = this;
                t.Tag = type;
                t.Show();
            }
        }

        //通过权限禁用控件
        private void DisableControlsByPermission()
        {
            //权限控制 遍历菜单查找Tag是否存在于用户的权限串中
            foreach (ToolStripMenuItem con in this.mainMenu.Items)
            {
                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    if (con2.Tag == null || con2.Tag.ToString() == String.Empty)
                    {
                        con2.Enabled = false;
                        continue;
                    }
                    if (!new UserManager().IfGranted(CommonData.nowLoginUser, con2.Tag.ToString()[0]))
                    {
                        con2.Enabled = false;
                    }
                }
            }
            //遍历查找快捷菜单
            foreach (ToolStripItem con in this.sideMenu.Items)
            {
                if (con is ToolStripButton)
                {
                    if (con.Tag == null || con.Tag.ToString() == String.Empty)
                    {
                        if (con.Text != "退出系统") con.Enabled = false;
                        continue;
                    }
                    if (!new UserManager().IfGranted(CommonData.nowLoginUser, con.Tag.ToString()[0]))
                    {
                        con.Enabled = false;
                    }
                }
            }
        }

        //开启全部控件,仅用于下方开启有权限的控件方法
        private void EnableControls()
        {
            //权限控制 遍历菜单查找Tag是否存在于用户的权限串中
            foreach (ToolStripMenuItem con in this.mainMenu.Items)
            {
                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    con2.Enabled = true;
                }
            }
            //遍历查找快捷菜单
            foreach (ToolStripItem con in this.sideMenu.Items)
            {
                if (con is ToolStripButton)
                {
                    con.Enabled = true;
                }
            }
        }

        //禁用全部控件,仅用于数据导入导出
        private void DisableControls()
        {
            //权限控制 遍历菜单查找Tag是否存在于用户的权限串中
            foreach (ToolStripMenuItem con in this.mainMenu.Items)
            {
                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    con2.Enabled = false;
                }
            }
            //遍历查找快捷菜单
            foreach (ToolStripItem con in this.sideMenu.Items)
            {
                if (con is ToolStripButton)
                {
                    con.Enabled = false;
                }
            }
        }

        //通过权限开启控件
        private void EnableControlsByPermission()
        {
            EnableControls();
            DisableControlsByPermission();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            userStat.Text = "当前登录用户: " + CommonData.nowLoginUser.LoginName + " - " + CommonData.nowLoginUser.Name;
            EnableControlsByPermission();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MsgBox.ShowAsk("确认要退出吗?"))
            {
                e.Cancel = false; //FormClosed事件会监听,否则会有概率抛出异常
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing会监听
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            timeStat.Text = dt.ToString("yyyy-MM-dd HH:mm:ss");
            weekDayStat.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek);
        }

        private void 个人信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<SingleEmployeeForm>();
        }

        private void 员工与用户信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<EmployeeForm>();
        }

        private void 商品类别维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<GoodTypeForm>();
        }

        private void 商品信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<GoodForm>();
        }

        private void 仓库信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<WarehouseForm>();
        }

        private void 供应商信息维护ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Jump<BusinessUnitForm>("供应商");
        }

        private void 客户信息维护ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Jump<BusinessUnitForm>("客户");
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            退出系统ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            员工与用户信息维护ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton19_Click(object sender, EventArgs e)
        {
            商品信息维护ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton17_Click(object sender, EventArgs e)
        {
            供应商信息维护ToolStripMenuItem1.PerformClick();
        }

        private void ToolStripButton16_Click(object sender, EventArgs e)
        {
            客户信息维护ToolStripMenuItem1.PerformClick();
        }

        private void 当前库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<StockQuery>();
        }

        private void 进货入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<InForm>("进货入库");
        }

        private void 进货退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<ReturnForm>("进货退货");
        }

        private void 销售出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<OutForm>("销售出库");
        }

        private void 销售退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<ReturnForm>("销售退货");
        }

        private void 其他入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<InForm>("其他入库");
        }

        private void 其他出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<OutForm>("其他出库");
        }

        private void 出入库记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<RecordQuery>();
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            当前库存查询ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton15_Click(object sender, EventArgs e)
        {
            进货入库ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton14_Click(object sender, EventArgs e)
        {
            进货退货ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton12_Click(object sender, EventArgs e)
        {
            销售出库ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton11_Click(object sender, EventArgs e)
        {
            销售退货ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            其他入库ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            其他出库ToolStripMenuItem.PerformClick();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            出入库记录ToolStripMenuItem.PerformClick();
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 进货统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<JinHuoTongJi>();
        }

        private void 销售统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<XiaoShouTongJi>();
        }

        private void 月销售状况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<YueXiaoShouZhuangKuang>();
        }

        private void 销售排行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump<XiaoShouPaiHang>();
        }

        private string backupFilePath = System.AppDomain.CurrentDomain.BaseDirectory + @"backup.bak";

        private void 数据备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MsgBox.ShowAsk("数据备份会自动覆盖上一次备份的数据。\r\n当数据较多时,备份功能可能会占用较长时间,甚至程序可能会无响应.是否继续?")) return;
            DisableControls();
            try
            {
                if (File.Exists(backupFilePath))
                {
                    File.Delete(backupFilePath);
                }
            }
            catch(Exception exp)
            {
                EnableControlsByPermission();
                MsgBox.ShowError("备份失败! 无法覆盖原备份文件: " + exp.Message);
                return;
            }
            try
            {
                new DataManager().Backup(backupFilePath);
            }
            catch(Exception exp)
            {
                EnableControlsByPermission();
                MsgBox.ShowError("备份失败! " + exp.Message);
                return;
            }
            EnableControlsByPermission();
            MsgBox.ShowInfo("备份成功!");
        }

        private void 数据恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MsgBox.ShowAsk("数据恢复会自动读取程序根目录下的备份文件。\r\n当数据较多时,恢复功能可能会占用较长时间,甚至程序可能会无响应.是否继续?")) return;
            DisableControls();
            if(!File.Exists(backupFilePath))
            {
                EnableControlsByPermission();
                MsgBox.ShowError("恢复失败! 无法读取原备份信息!请确认是否备份过或备份文件是否损坏。");
                return;
            }
            try
            {
                new DataManager().Restore(backupFilePath);
            }
            catch (Exception exp)
            {
                EnableControlsByPermission();
                MsgBox.ShowError("恢复失败! " + exp.Message);
                return;
            }
            EnableControlsByPermission();
            MsgBox.ShowInfo("恢复成功!");
        }
    }
}
