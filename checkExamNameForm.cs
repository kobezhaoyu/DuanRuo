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
    public partial class checkExamNameForm : Form
    {
        public checkExamNameForm()
        {
            InitializeComponent();
        }

        private void checkExamNameForm_Load(object sender, EventArgs e)
        {
            get_kcList();

        }

        private void get_kcList()
        {
            db_examName examNameModel = new db_examName();
            DataTable dtExamName = examNameModel.GetList("").Tables[0];
            int allCount = dtExamName.Rows.Count;//一共有多少条数据
            int rowsCount = 0;//循环行数
            int colsCount = 5;//循环列数
            if (allCount % colsCount > 0)  //余数＞0
            {
                rowsCount = (allCount / colsCount) + 1;
            }
            else
            {
                rowsCount = allCount / colsCount;
            }

            int count = -1;//记数用  
            Button[,] btnSlot = new Button[rowsCount, colsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    if (j + i * 5 < allCount)
                    {
                        btnSlot[i, j] = new Button();
                        //按钮大小初始化
                        btnSlot[i, j].Size = new Size(185, 35);
                        //位置初始化
                        btnSlot[i, j].Location = new Point(j * 205 + 43, i * 41 + 41); //一行一行显示出来
                        btnSlot[i, j].FlatStyle = FlatStyle.Flat;
                        count++;
                        btnSlot[i, j].Name = "btn" + count; //为btn设置name属性
                        btnSlot[i, j].Text = dtExamName.Rows[j+i*5]["examName"].ToString(); //"btn" + count;  //BTN显示的内容
                        btnSlot[i, j].Click += new EventHandler(button1_Click);
                        this.Controls.Add(btnSlot[i, j]);  //在哪里创建,btnContainer为一个大的button,所有的<strong>button都嵌套在里面</strong>
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = ((System.Windows.Forms.ButtonBase)(sender)).Text;
            publicModel.examName = str;
            DialogResult = DialogResult.OK;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //examNameForm info = new examNameForm();
            //info.ShowDialog();
        }

        private void tsb_add_Click(object sender, EventArgs e)
        {
            examNameForm info = new examNameForm();
            info.ShowDialog();
        }

        private void tsb_refresh_Click(object sender, EventArgs e)
        {
            get_kcList();
        }
    }
}
