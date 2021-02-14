using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using 进销存管理系统.Common;
using 进销存管理系统.Models;
using 进销存管理系统.BLL;

namespace 进销存管理系统.基础信息维护
{
    public partial class SingleEmployeeForm : Form
    {
        bool ifChanged = false;
        public string OutterUsername = ""; //从外部调用
        public User Outter = null; //从外部调用
        public bool ifNew = false; //新建
        User nowUsr;

        public SingleEmployeeForm()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk"; //加载皮肤文件

        }

        //解禁控件
        private void Enable()
        {
            nameText.ReadOnly = false;
            sexCombo.Enabled = true;
            deptText.ReadOnly = false;
            phoneText.ReadOnly = false;
            birthdayDate.Enabled = true;
            entryDate.Enabled = true;
            permissionGroup.Enabled = true;
        }

        private string GeneratePermissionStr()
        {
            string Permission = "0";
            foreach (GroupBox gb in permissionGroup.Controls)
            {
                foreach (CheckBox cb in gb.Controls)
                {
                    if (cb.Tag == null || cb.Tag.ToString() == String.Empty)
                    {
                        cb.Checked = false;
                        continue;
                    }
                    if (cb.Checked) Permission += cb.Tag;
                }
            }
            return Permission;
        }

        //获得User Model
        private User GetUser()
        {
            User newUsr = new User();
            newUsr.LoginName = usernameText.Text.Trim();
            newUsr.Name = nameText.Text.Trim();
            newUsr.Sex = sexCombo.Text;
            newUsr.Department = deptText.Text.Trim();
            newUsr.Phone = phoneText.Text.Trim();
            newUsr.Birthday = birthdayDate.Value;
            newUsr.EntryDate = entryDate.Value;
            newUsr.Permission = "0";
            //开始生成权限串
            newUsr.Permission = this.GeneratePermissionStr();
            return newUsr;
        }

        private void Person_Load(object sender, EventArgs e)
        {
            if(OutterUsername != string.Empty)
            {
                try
                {
                    Outter = new UserManager().Get(OutterUsername);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close();
                }
            }
            nowUsr = (Outter == null) ? CommonData.nowLoginUser : Outter;
            if (!ifNew)
            {
                usernameText.Text = nowUsr.LoginName;
                nameText.Text = nowUsr.Name;
                sexCombo.Text = nowUsr.Sex;
                deptText.Text = nowUsr.Department;
                phoneText.Text = nowUsr.Phone;
                birthdayDate.Value = nowUsr.Birthday;
                entryDate.Value = nowUsr.EntryDate;
                //循环加载权限GroupBox
                foreach (GroupBox gb in permissionGroup.Controls)
                {
                    foreach (CheckBox cb in gb.Controls)
                    {
                        if (cb.Tag == null || cb.Tag.ToString() == String.Empty)
                        {
                            cb.Checked = false;
                            continue;
                        }
                        if (new UserManager().IfGranted(nowUsr, cb.Tag.ToString()[0])) cb.Checked = true;
                        else cb.Checked = false;
                    }
                }
                if (nowUsr.LoginName != "admin" && Outter != null) Enable();  //解禁控件
            }
            else
            {
                Enable(); //解禁控件
                usernameText.ReadOnly = false; //解禁用户名控件
                usernameText.Focus();
                passwordTipLabel.Visible = false; //修改密码提示不可见
            }
            ifChanged = false;
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ifChanged)
            {
                MsgBox.ShowInfo("无需保存!");
                return;
            }
            if(!ifNew)
            {
                if (passwordText.Text != string.Empty)
                {
                    //修改密码
                    try
                    {
                        new UserManager().ChangePassword(usernameText.Text, passwordText.Text);
                    }
                    catch(Exception exp)
                    {
                        MsgBox.ShowError("密码修改失败!原因: " + exp.Message);
                        return;
                    }
                    MsgBox.ShowInfo("密码修改成功!");
                    passwordText.Text = "";
                    ifChanged = false;
                    return;
                }
                if (Outter != null)
                {
                    //执行修改操作
                    try
                    {
                        new UserManager().ChangeInfo(usernameText.Text, GeneratePermissionStr(), nameText.Text, sexCombo.Text, deptText.Text, phoneText.Text, birthdayDate.Value, entryDate.Value);
                    }
                    catch(Exception exp)
                    {
                        MsgBox.ShowError("信息修改失败!原因: " + exp.Message);
                        return;
                    }
                    MsgBox.ShowInfo("信息修改成功!");
                    passwordText.Text = "";
                    ifChanged = false;
                    return;
                }
            }
            else
            {
                //新建
                try
                {
                    new UserManager().Add(usernameText.Text, passwordText.Text, GeneratePermissionStr(), nameText.Text, sexCombo.Text, deptText.Text, phoneText.Text, birthdayDate.Value, entryDate.Value);
                }
                catch(Exception exp)
                {
                    MsgBox.ShowError("用户添加失败!原因: " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("添加用户成功!");
                passwordText.Text = "";
                ifChanged = false;
                return;
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //FormClosing事件会监听
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void Person_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ifChanged)
            {
                if (MsgBox.ShowAsk("还未保存,确认不保存而退出吗?"))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void DeptText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void PhoneText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void BirthdayDate_ValueChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void EntryDate_ValueChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void SexCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void PersonForm_Shown(object sender, EventArgs e)
        {
            //部分情况下在Load事件中设置焦点会失效，故在Shown事件中再设置一次焦点。
            if(ifNew)
            {
                usernameText.ReadOnly = false;
                usernameText.Focus();
            }
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox19_CheckedChanged_1(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void CheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
