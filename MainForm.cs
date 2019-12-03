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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("personInfo"))
            {
                personInfo info = new personInfo();
                info.MdiParent = this;
                info.Show();
            }
        }


        private void 查询考生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("personList"))
            {
                personList perlist = new personList();
                //info.MdiParent = this;
                perlist.ShowDialog();
            }
        }

        private void 添加异常考生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("addExceptionStu"))
            {
                addExceptionStu info = new addExceptionStu();
                //info.MdiParent = this;
                info.ShowDialog();
            }
        }

        private void 查询未签到考生信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("wqd_stuList"))
            {
                wqd_stuList perlist = new wqd_stuList();
                //info.MdiParent = this;
                perlist.ShowDialog();
            }
        }

        private void 设置考场ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("kaochangForm"))
            {
                kaochangForm info = new kaochangForm();
                //info.MdiParent = this;
                info.ShowDialog();
            }
        }

        private void 设置考号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("setTheExamNoForm"))
            {
                setTheExamNoForm info = new setTheExamNoForm();
                //info.MdiParent = this;
                info.ShowDialog();
            }
        }

        private void 设置考试名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("examNameForm"))
            {
                examNameForm info = new examNameForm();
                info.ShowDialog();
            }
        }
       

        private void 导入考生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("importInfo"))
            {
                importInfo impInfo = new importInfo();
                
                impInfo.ShowDialog();
            }
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsChildFormExist("modifyPwd"))
            {
                modifyPwd info = new modifyPwd();
                info.ShowDialog();
            }
        }










        ///<summary>
        ///检查MDI子窗体是否存在
        ///</summary>
        ///<param name="childFrmName"></param>
        ///<returns></returns>
        private bool IsChildFormExist(string childFrmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == childFrmName)//用子窗体的Name进行判断，如果存在则将他激活
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Normal;
                    }
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();

            this.Hide();
            loginForm frmlogin = new loginForm();
            DialogResult dg = frmlogin.ShowDialog();
            if (dg == DialogResult.OK)
            {
               DialogResult dg2= new checkExamNameForm().ShowDialog();
               if (dg2 == DialogResult.OK)
               {
                   this.Show();
                   toolStripStatusLabel3.Text = "当前考试名称： "+publicModel.examName;
                   personInfo info = new personInfo();
                   info.MdiParent = this;
                   info.Show();
               }
               else
                   this.Close();
            }
            else
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");  
        }
    }
}
