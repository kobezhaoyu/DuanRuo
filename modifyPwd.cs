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
    public partial class modifyPwd : Form
    {
        public modifyPwd()
        {
            InitializeComponent();
        }

        private void modifyPwd_Load(object sender, EventArgs e)
        {
            lblUsername.Text = publicModel.username;
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPwd.Text = string.Empty;
            txtNewPwd.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            db_users modeluser = new db_users();
            if (new db_users().Exists(publicModel.username, "duanruo") || new db_users().Exists(publicModel.username, DESEncrypt.Encrypt(txtOldPwd.Text.Trim())))
            {
                new db_users().UpdateNewsField(publicModel.username, " userPwd='" + DESEncrypt.Encrypt(txtNewPwd.Text.Trim()) + "'");
                MessageBox.Show("密码修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
            else
            {
                MessageBox.Show("旧密码不正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
