using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CVR100A_U_DSDK_Demo.App_Code;
using System.Data.OleDb;
using System.IO;

namespace CVR100A_U_DSDK_Demo
{
    public partial class importInfo : Form
    {
        public importInfo()
        {
            InitializeComponent();
        }

        private void importInfo_Load(object sender, EventArgs e)
        {
            BindCmbKCMC();
        }
        /// <summary>
        /// 绑定考场
        /// </summary>
        private void BindCmbKCMC()
        {
            DataTable dtDicCydw = new db_kaochang().GetList(" examnameid='" + publicModel.examName + "'").Tables[0];
            DataRow dr = dtDicCydw.NewRow();
            dr["ID"] = "0";
            dr["kcName"] = "--请选择--";
            dtDicCydw.Rows.InsertAt(dr, 0);
            cmbKaochang.DisplayMember = "kcName";
            cmbKaochang.ValueMember = "ID";
            cmbKaochang.DataSource = dtDicCydw.DefaultView;

        }


        private void btn_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string IsXls = System.IO.Path.GetExtension(ofd.FileName).ToString().ToLower();
            if (IsXls != ".xls")
            {
                MessageBox.Show("请您选择Excel文件");
                return;
            }
            txtFileName.Text = ofd.FileName;
        }
        public bool check()
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("先导入文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbKaochang.Text == "--请选择--")
            {
                MessageBox.Show("请选择分配的考场！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKaochang.Focus();
                return false;
            }
            else
                return true;
        }
        public DataSet ExecleDs(string filenameurl, string table)
        {
            string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);

            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            DataSet ds = new DataSet();
            odda.Fill(ds, table);

            return ds;

        }
        private void save_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string kaochang = cmbKaochang.Text;
                string strpath = txtFileName.Text;   //获取Execle文件路径
                string filename = txtFileName.Text;                       //获取Execle文件名
                DataSet ds = ExecleDs(strpath, filename);
                DataRow[] dr = ds.Tables[0].Select();                        //定义一个DataRow数组
                int rowsnum = ds.Tables[0].Rows.Count;
                int successNum = 0;   //导入成功的数量
                if (rowsnum == 0)
                {
                    MessageBox.Show("Excel表为空表,无数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  //当Excel表为空时,对用户进行提示
                }
                else
                {
                    for (int i = 0; i < dr.Length; i++)
                    {

                        string 姓名 = dr[i][0].ToString().Trim();
                        string 身份证号 = dr[i][1].ToString().Trim();
                        string _sql = "insert into db_exam(name,idcard,kaochangName,examNameID,status) values('" + 姓名 + "','" + 身份证号 + "','" + kaochang + "','" + publicModel.examName + "','未签到')";
                        DbHelperOleDb.ExecuteSql(_sql);
                        successNum++;
                    }
                    MessageBox.Show("Excle表共导入" + dr.Length + "条，成功" + successNum + "条！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string _sql = "delete from db_exam where examNameID='"+publicModel.examName+"'";

            int num = (int)DbHelperOleDb.ExecuteSql(_sql);
            if (num > 0)
            {
                MessageBox.Show("已成功清除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("清除失败了！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            setRandomNum();
            MessageBox.Show("各考场考号已初始化成功！请给学生派发准考证。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        } 
        string lujing = Application.StartupPath;  //F:\\MyProjects\\CVR100A_U_DSDK_Demo\\bin\\Debug
        //string lujing = "http://192.168.1.118\\d:";

        /// <summary>
        /// 配置各考场随机数
        /// </summary>
        private void setRandomNum()
        {
            DataTable dtDicCydw = new db_kaochang().GetList(" examnameid='" + publicModel.examName + "'").Tables[0];

            for (int i = 0; i < dtDicCydw.Rows.Count; i++)
            {
                StreamWriter swno = new StreamWriter(@lujing + "\\" + dtDicCydw.Rows[i]["kcname"].ToString() + "（" + publicModel.examName + "）" + ".txt");
                DataTable dtTheExam = new db_theExamNo().GetList("kaochangname='" + dtDicCydw.Rows[i]["kcname"].ToString() + "'").Tables[0];
                //循环每个考场有几组
                for (int j = 0; j < dtTheExam.Rows.Count; j++)
                {
                    for (int n = Convert.ToInt32(dtTheExam.Rows[j]["startnum"]); n <= Convert.ToInt32(dtTheExam.Rows[j]["endnum"]); n++)
                    {
                        swno.Write(n.ToString() + "\r\n");
                    }
                }
                swno.Close();
               
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearRandom();
        }
        /// <summary>
        /// 重置各考场随机数
        /// </summary>
        private void clearRandom()
        {
            try
            {
                DataTable dtDicCydw = new db_kaochang().GetList(" examnameid='" + publicModel.examName + "'").Tables[0];

                for (int i = 0; i < dtDicCydw.Rows.Count; i++)
                {
                    //StreamWriter swno = new StreamWriter(lujing + "\\" + dtDicCydw.Rows[i]["kcname"].ToString() + "（" + publicModel.examName + "）" + ".txt");
                    //swno.Write("");
                    //swno.Close();
                    string delFile = lujing + "\\" + dtDicCydw.Rows[i]["kcname"].ToString() + "（" + publicModel.examName + "）" + ".txt"; 
                    File.Delete(delFile);
                }
                StreamWriter swno1 = new StreamWriter(lujing + "\\idcard.txt");
                swno1.Write("");
                swno1.Close();
                MessageBox.Show("已成功清空各考场准考证号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("抛锚了！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
