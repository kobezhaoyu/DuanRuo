using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CVR100A_U_DSDK_Demo.App_Code;
using System.IO;
using System.Drawing.Printing;

namespace CVR100A_U_DSDK_Demo
{
    public partial class addExceptionStu : Form
    {
        public addExceptionStu()
        {
            InitializeComponent();
        }

        db_exam examModel = new db_exam();

        int id;  //产生的随机号标识
        public int idnum; //产生的随机号
        public string printStuNo; //打印准考证号

        /// <summary>
        /// 绑定DataGridView标题文本
        /// </summary>
        private void TitleDgvBillList()
        {
            dgvList.Columns["ID"].Visible = false;
            dgvList.Columns["ID"].HeaderText = "自增ID";
            dgvList.Columns["name"].HeaderText = "姓名";
            dgvList.Columns["idcard"].HeaderText = "身份证号";
            dgvList.Columns["kaochangName"].HeaderText = "考场名称";
            dgvList.Columns["examNameID"].HeaderText = "考试名称";

            dgvList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkTxt() && dgvList.Rows.Count > 1)
            {
                try
                {

                    db_students studentModel = new db_students();
                    DataTable dt = studentModel.GetList(" stuName='" + txtStuName.Text.Trim() + "' and idcard='" + txtIdCard.Text.Trim() + "' and examNameID='" + publicModel.examName + "'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("已存在相同的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        studentModel.stuName = txtStuName.Text.Trim();
                        studentModel.IdCard = txtIdCard.Text.Trim();
                        studentModel.examNameID = publicModel.examName;
                        db_exam modelexam = new db_exam( txtIdCard.Text.Trim(), publicModel.examName);
                        string kcName = modelexam == null ? "" : modelexam.kaochangName;
                        studentModel.kaochangName = kcName;
                        studentModel.status = "异常";

                        studentModel.prushTime = "";
                        studentModel.sex = "";
                        studentModel.nation = "";
                        studentModel.birthday = "";
                        studentModel.address = "";
                        studentModel.qianzhengjiguan = "";
                        studentModel.youxiaoqixian = "";
                        studentModel.applyNo = "";

                        if (getStuExamRandomNum(kcName))
                        {
                            studentModel.stuNo = printStuNo;
                            studentModel.Add();
                            MessageBox.Show("添加成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //更改导入学生签到状态
                            modelexam.status = "已签到";
                            modelexam.Update();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("添加失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入考生信息，再添加！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private bool checkTxt()
        {
            if (string.IsNullOrEmpty(txtStuName.Text.Trim()))
            {
                //MessageBox.Show("请输入考生姓名！");
                //txtStuName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtIdCard.Text.Trim()))
            {
                //MessageBox.Show("请输入身份证号！");
                //txtIdCard.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtStuName_TextChanged(object sender, EventArgs e)
        {
            if (checkTxt())
            {
                DataTable dt = new db_students().GetList(" stuName='" + txtStuName.Text.Trim() + "' and idcard='" + txtIdCard.Text.Trim() + "' and examNameID='" + publicModel.examName + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblExamNo.Text = dt.Rows[0]["stuno"].ToString();
                }
                else
                {
                    lblExamNo.Text = "--";
                }
                DataTable dtExam = examModel.GetList(" name like'" + txtStuName.Text.Trim() + "%' and idcard like'" + txtIdCard.Text.Trim() + "%' and examNameID='" + publicModel.examName + "'").Tables[0];
                dgvList.DataSource = dtExam;
                TitleDgvBillList();
            }
        }

        private void txtIdCard_TextChanged(object sender, EventArgs e)
        {
            if (checkTxt())
            {
                DataTable dt = new db_students().GetList(" stuName='" + txtStuName.Text.Trim() + "' and idcard='" + txtIdCard.Text.Trim() + "' and examNameID='" + publicModel.examName + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblExamNo.Text = dt.Rows[0]["stuno"].ToString();
                }
                else
                {
                    lblExamNo.Text = "--";
                }
                DataTable dtExam = examModel.GetList(" name like'" + txtStuName.Text.Trim() + "%' and idcard like'" + txtIdCard.Text.Trim() + "%' and examNameID='" + publicModel.examName + "'").Tables[0];
                dgvList.DataSource = dtExam;
                TitleDgvBillList();
            }
        }

        //物理路径
        string lujing = Application.StartupPath;

        /// <summary>
        /// 根据考生的身份证号所在考场，自动分配准考证号
        /// </summary>
        /// <param name="_type">第几考场</param>
        private bool getStuExamRandomNum(string _kaochangName)
        {
            bool result = false;
            if (File.Exists(lujing + "\\" + _kaochangName + "（" + publicModel.examName + "）" + ".txt"))
            {
                string[] txtline = File.ReadAllLines(lujing + "\\" + _kaochangName + "（" + publicModel.examName + "）" + ".txt");
                int txtlength = txtline.Length;
                if (txtlength > 0)
                {
                    Random rm = new Random();
                    id = rm.Next(1, txtlength);
                    //StreamReader reader = new StreamReader(_kaochangName + "（" + publicModel.examName + "）" + ".txt");
                    //string text = reader.ReadToEnd();
                    //reader.Close();
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < txtlength; i++)
                    {
                        if (txtlength == 1)
                        {
                            idnum = int.Parse(txtline[id - 1]);
                            str.Append("");
                        }
                        else
                        {
                            if (i == id - 1)
                                continue;
                            idnum = int.Parse(txtline[id - 1]);
                            str.AppendLine(txtline[i]);
                        }
                    }
                    StreamWriter writer = new StreamWriter(lujing + "\\" + _kaochangName + "（" + publicModel.examName + "）" + ".txt");
                    writer.Write(str.ToString());
                    writer.Close();
                    result = true;

                    if (idnum < 10 && idnum >= 0)
                    {
                        printStuNo = "00" + idnum.ToString();
                    }
                    else if (idnum > 99)
                    {
                        printStuNo = idnum.ToString();
                    }
                    else
                    {
                        printStuNo = "0" + idnum.ToString();
                    }
                    lblExamNo.Text = printStuNo;
                }
                else
                {
                    MessageBox.Show("考号已派发完！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    result = false;
                }
            }

            return result;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lblExamNo.Text != "--")
            {
                //打印预览              
                PrintDocument pd = new PrintDocument();
                //设置边距              
                Margins margin = new Margins(10, 10, 0, 0);
                pd.DefaultPageSettings.Margins = margin;
                ////纸张设置默认              
                //PaperSize pageSize = new PaperSize("First custom size", 800, 600);              
                //pd.DefaultPageSettings.PaperSize = pageSize;              
                //打印事件设置              
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage1);
                try
                {
                    pd.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
                }
            }
            else
            {
                MessageBox.Show("该考生不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void pd_PrintPage1(object sender, PrintPageEventArgs e)
        {
            string examno = lblExamNo.Text;

            Font f = new Font("黑体", 152);
            Brush b = new SolidBrush(Color.Black);
            float x = 15.0F;
            float y = 200.0F;
            e.Graphics.DrawString(examno, f, b, x, y);
            e.Graphics.Dispose();
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            string id = dgvList.Rows[dgvList.CurrentRow.Index].Cells[0].Value.ToString();
            string name = dgvList.Rows[dgvList.CurrentRow.Index].Cells[1].Value.ToString();
            string idcard = dgvList.Rows[dgvList.CurrentRow.Index].Cells[2].Value.ToString();

            txtStuName.Text = name;
            txtIdCard.Text = idcard;
        }
    }
}
