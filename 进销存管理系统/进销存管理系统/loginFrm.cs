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

namespace 进销存管理系统
{
    public partial class loginFrm : Form
    {
        public loginFrm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameText.Text.Trim() == string.Empty)
            {
                MsgBox.ShowError("用户名为空!");
                usernameText.Focus();
                return;
            }
            if (passwordText.Text == string.Empty)
            {
                MsgBox.ShowError("密码为空!");
                passwordText.Focus();
                return;
            }
            User thisUsr;
            try
            {
                thisUsr = new UserManager().Get(usernameText.Text.Trim());
            }
            catch(Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            if(thisUsr.Password == UserManager.GetMD5(passwordText.Text))
            {
                //校验成功
                //释放敏感资源：密码
                thisUsr.Password = null;
                string wenhou;
                DateTime dt = DateTime.Now; //获取当前时间
                if (dt.Hour >= 0 && dt.Hour < 8) wenhou = "早上好!";
                else if (dt.Hour >= 8 && dt.Hour < 12) wenhou = "上午好!";
                else if (dt.Hour >= 12 && dt.Hour < 14) wenhou = "中午好!";
                else if (dt.Hour >= 14 && dt.Hour < 18) wenhou = "下午好!";
                else wenhou = "晚上好!";
                MsgBox.ShowInfo(wenhou + " " + thisUsr.Name);
                mainFrm mainForm = new mainFrm();
                CommonData.nowLoginUser = thisUsr;
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MsgBox.ShowError("用户名或密码错误!");
                return;
            }
        }

        private void CacelBtn_Click(object sender, EventArgs e)
        {
            this.Close(); //formclosing事件会监听
        }

        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MsgBox.ShowAsk("确认要退出吗?"))
            {
                e.Cancel = false; //formclosed事件会监听,否则有概率会抛出异常
            }
            else
            {
                e.Cancel = true;
            }
        }

        //在密码框内按下Enter键时尝试登录系统
        private void PasswordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //按下Enter键
            {
                loginBtn.PerformClick(); //模拟按下loginBtn按钮
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            titleLabel.Tag = this.skinEngine1.DisableTag; //取消皮肤控件管束
            titleLabel.ForeColor = Color.White;
            titleLabel.BackColor = Color.Transparent;
        }
    }
}
