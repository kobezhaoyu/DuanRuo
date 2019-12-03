using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CVR100A_U_DSDK_Demo.App_Code;

namespace CVR100A_U_DSDK_Demo
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string userpwd = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("请输入用户名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(userpwd))
            {
                MessageBox.Show("请输入密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPwd.Focus();
            }
            else
            {
                db_users userModel = new db_users();
                string pwd  = DESEncrypt.Encrypt(userpwd);
                //上下午设置
                string am = "";
                string pm = "";
                if (rbtn_am.Checked)
                    am = rbtn_am.Text;
                if (rbtn_pm.Checked)
                    pm = rbtn_pm.Text; 
                    
                if (userModel.Exists(username,pwd))
                //if (true)
                {
                    publicModel.am_pm = am + pm;
                    publicModel.username = txtUserName.Text.Trim();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("用户名密码错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserName.Focus();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtUserName.Focus();
            rbtn_am.Checked = false;
            rbtn_pm.Checked = false;
        }
    }
}
