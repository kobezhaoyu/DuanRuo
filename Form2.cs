using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CVR100A_U_DSDK_Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _sql = "delete from tb_exam";

            int num = (int)DbHelperOleDb.ExecuteSql(_sql);
            if (num > 0)
            {
                MessageBox.Show("已成功清除！");
            }
            else
            {
                MessageBox.Show("清除失败了！");
            }
        }
    }
}
