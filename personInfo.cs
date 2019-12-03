using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using CVR100A_U_DSDK_Demo.App_Code;
using System.Drawing.Printing;

namespace CVR100A_U_DSDK_Demo
{
    public partial class personInfo : Form
    {
        public personInfo()
        {
            InitializeComponent();
        }

        #region 初始化

        public StringBuilder name;     //姓名
        public String sex;      //性别
        public String people;    //民族，护照识别时此项为空
        public String birthday;   //出生日期
        public String address;  //地址，在识别护照时导出的是国籍简码
        public string number;  //地址，在识别护照时导出的是国籍简码
        public string signdate;   //签发日期，在识别护照时导出的是有效期至 
        public string validtermOfStart;  //有效起始日期，在识别护照时为空
        public string validtermOfEnd;  //有效截止日期，在识别护照时为空

        public string idcardnum; //每次刷卡时存放临时身份证号
        bool newflag = true; //同一身份证号是否重复使用

        int id;  //产生的随机号标识
        public int idnum; //产生的随机号
        public string printStuNo; //打印准考证号

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((iRetCOM == 1) || (iRetUSB == 1))
                {
                    int authenticate = CVRSDK.CVR_Authenticate();
                    if (authenticate == 1)
                    {
                        int readContent = CVRSDK.CVR_Read_Content(4);
                        if (readContent == 1)
                        {
                            getFillIdCardData(false);

                            this.label10.Text = "读卡操作成功！";
                            //判断刷卡人是否已录入考试名单
                            string _sql = "select kaochangName from db_exam where idcard='" + GetCVR_Idcard() + "' and examNameID='" + publicModel.examName + "'";
                            string kaochangName = Convert.ToString(DbHelperOleDb.GetSingle(_sql));
                            if (!string.IsNullOrEmpty(kaochangName))
                            {
                                DataTable dt = DbHelperOleDb.Query("select * from db_students where IdCard='" + GetCVR_Idcard() + "' and examNameID='" + publicModel.examName + "'").Tables[0];
                                int selCount = dt.Rows.Count;
                                if (selCount > 0)
                                {
                                    lblExamNo.Visible = true;
                                    lblExamNo.Text = dt.Rows[0]["stuNo"].ToString();
                                    MessageBox.Show("此身份证已签到！");
                                    newflag = true;
                                }
                                else
                                {
                                    if (getStuExamRandomNum(kaochangName))
                                    {
                                        newflag = false;
                                        FillData(kaochangName);

                                        db_exam modelexam = new db_exam(GetCVR_Idcard(), publicModel.examName);
                                        //更改签到学生的签到状态
                                        modelexam.status = "已签到";
                                        modelexam.Update();

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("“" + publicModel.examName + "” 考试名单中无此人信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {
                            this.label10.Text = "读卡操作失败！";
                        }
                    }
                    else
                    {
                        MessageBox.Show("未放卡或卡片放置不正确", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("初始化失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 获取身份证卡的信息 - 身份证号码
        /// </summary>
        /// <returns></returns>
        public string GetCVR_Idcard()
        {
            try
            {
                int length = 30;
                byte[] number = new byte[30];
                length = 36;
                CVRSDK.GetPeopleIDCode(ref number[0], ref length);
                return System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath()
        {
            string path = "c:\\duanruo\\"; //站点目录+上传目录
            //按年月/日存入不同的文件夹
            path += DateTime.Now.ToString("yyyyMM") + "\\" + DateTime.Now.ToString("dd");
            return path + "\\";
        }

        /// <summary>
        /// 得到身份证上的信息
        /// </summary>
        public void getFillIdCardData(bool isFirst)
        {
            pictureBox1.ImageLocation = Application.StartupPath + "\\zp.bmp";
            //if (isFirst)//如果是第一次刷卡，则把照片保存到本地磁盘
            //{
            //    pictureBox1.Image.Save(GetUpLoadPath() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //}

            byte[] name = new byte[30];
            int length = 30;
            CVRSDK.GetPeopleName(ref name[0], ref length);
            //MessageBox.Show();
            byte[] number = new byte[30];
            length = 36;
            CVRSDK.GetPeopleIDCode(ref number[0], ref length);
            byte[] people = new byte[30];
            length = 3;
            CVRSDK.GetPeopleNation(ref people[0], ref length);
            byte[] validtermOfStart = new byte[30];
            length = 16;
            CVRSDK.GetStartDate(ref validtermOfStart[0], ref length);
            byte[] birthday = new byte[30];
            length = 16;
            CVRSDK.GetPeopleBirthday(ref birthday[0], ref length);
            byte[] address = new byte[30];
            length = 70;
            CVRSDK.GetPeopleAddress(ref address[0], ref length);
            byte[] validtermOfEnd = new byte[30];
            length = 16;
            CVRSDK.GetEndDate(ref validtermOfEnd[0], ref length);
            byte[] signdate = new byte[30];
            length = 30;
            CVRSDK.GetDepartment(ref signdate[0], ref length);
            byte[] sex = new byte[30];
            length = 3;
            CVRSDK.GetPeopleSex(ref sex[0], ref length);

            byte[] samid = new byte[32];
            CVRSDK.CVR_GetSAMID(ref samid[0]);


            lblAddress.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0", "").Trim();
            lblSex.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
            lblBirthday.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0", "").Trim();
            lblDept.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(signdate).Replace("\0", "").Trim();
            lblIdCard.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
            lblName.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0", "").Trim();
            lblNation.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0", "").Trim();
            label11.Text = "安全模块号：" + System.Text.Encoding.GetEncoding("GB2312").GetString(samid).Replace("\0", "").Trim();
            lblValidDate.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfStart).Replace("\0", "").Trim() + "-" + System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfEnd).Replace("\0", "").Trim();

            idcardnum = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
        }

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <param name="_kaochangName">考场名称</param>
        public void FillData(string _kaochangName)
        {
            try
            {
                getFillIdCardData(true);

                //string[] idline = File.ReadAllLines("idcard.txt");
                //int idlength = idline.Length;
                //for (int idindex = 0; idindex < idlength; idindex++)
                //{
                //    if (idline[idindex] == idcardnum)
                //    {
                //        newflag = false;
                //        break;
                //    }
                //}

                if (!newflag)
                {
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
                    lblExamNo.Visible = true;
                    lblExamNo.Text = printStuNo;

                    //记录刷卡用户
                    db_students studentsModel = new db_students();
                    studentsModel.stuName = lblName.Text.ToString();
                    studentsModel.stuNo = lblExamNo.Text.ToString();
                    studentsModel.IdCard = lblIdCard.Text.ToString();
                    studentsModel.prushTime = DateTime.Now.ToLongDateString();
                    studentsModel.sex = lblSex.Text.ToString();
                    studentsModel.nation = lblNation.Text.ToString();
                    studentsModel.birthday = lblBirthday.Text.ToString();
                    studentsModel.address = lblAddress.Text.ToString();
                    studentsModel.qianzhengjiguan = lblDept.Text.ToString();
                    studentsModel.youxiaoqixian = lblValidDate.Text.ToString();
                    studentsModel.applyNo = "";
                    studentsModel.status = "正常";
                    studentsModel.kaochangName = _kaochangName;
                    studentsModel.examNameID = publicModel.examName;

                    try
                    {
                        studentsModel.Add();
                    }
                    catch
                    {
                        MessageBox.Show("录入失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    ////创建当前DOM对象的代码片段
                    //XmlDocumentFragment MyResultFra = AddId.CreateDocumentFragment();
                    ////获得具有[考生编号流水号]属性的[考生员工]节点
                    //XmlNode Mynode = AddId.SelectSingleNode("//添加考生[@考生编号流水号]");
                    ////获取当前[考生编号流水号]的值
                    //ResultId = int.Parse(Mynode.Attributes["考生编号流水号"].Value);
                    ////修改[考生编号流水号]            
                    //ResultId++;
                    //Mynode.Attributes["考生编号流水号"].Value = ResultId.ToString();
                    ////创建一个<新考生>节点
                    //XmlElement ResultElementRoot = AddId.CreateElement("新考生");
                    ////创建一个<考生编号>属性，并把他绑定到<新考生>节点
                    //XmlAttribute Myatt = AddId.CreateAttribute("考生编号");
                    //Myatt.Value = ResultId.ToString();
                    //ResultElementRoot.SetAttributeNode(Myatt);
                    ////1创建一个<考生号>节点
                    //XmlElement MyEmpNum = AddId.CreateElement("考生号");
                    //MyEmpNum.InnerText = id.ToString();
                    ////2创建一个<姓名>节点
                    //XmlElement MyEmpName = AddId.CreateElement("姓名");
                    //MyEmpName.InnerText = lblName.Text;
                    ////3创建一个<身份证号>节点
                    //XmlElement MyEmpBirthday = AddId.CreateElement("身份证号");
                    //MyEmpBirthday.InnerText = lblIdCard.Text;
                    ////把以上的节点添加到<新员工>的子节点中
                    //ResultElementRoot.AppendChild(MyEmpNum);
                    //ResultElementRoot.AppendChild(MyEmpName);
                    //ResultElementRoot.AppendChild(MyEmpBirthday);
                    ////添加<新考生>节点到 MyDocFrag 对象中
                    //MyResultFra.AppendChild(ResultElementRoot);
                    ////获得具有[考生编号流水号]属性的[添加考生]节点
                    //XmlNode TempNode = AddId.SelectSingleNode("//添加考生[@考生编号流水号]");
                    ////把代码片段添加到DOM对象中
                    //TempNode.AppendChild(MyResultFra);
                    //AddId.Save("xmlAddId.xml");

                    //StreamWriter swr = new StreamWriter("idcard.txt");
                    //向创建的文件中写入内容
                    StreamWriter swr = File.AppendText("idcard.txt");
                    swr.Write(idcardnum);
                    swr.Write("\r\n");
                    //关闭当前文件写入流
                    swr.Close();
                }
                else
                {
                    MessageBox.Show("此身份证已签到！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    newflag = true;
                    lblExamNo.Visible = false;
                    //DialogResult result = MessageBox.Show("此身份证已签到，是否替换?", "询问",
                    //                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (result == DialogResult.OK)
                    //{
                    //    newflag = false;
                    //    string[] txtline = File.ReadAllLines("randno.txt");
                    //    int txtlength = txtline.Length;
                    //    Random rm = new Random();
                    //    id = rm.Next(1, txtlength);
                    //    StreamReader reader = new StreamReader("randno.txt");
                    //    string text = reader.ReadToEnd();
                    //    reader.Close();
                    //    //string[] textlines = Regex.Split(text, Environment.NewLine);
                    //    StringBuilder str = new StringBuilder();
                    //    for (int i = 0; i < txtlength; i++)
                    //    {
                    //        if (i == id)
                    //            continue;
                    //        idnum = int.Parse(txtline[id]);
                    //        str.AppendLine(txtline[i]);
                    //    }
                    //    StreamWriter writer = new StreamWriter("randno.txt");
                    //    writer.Write(str.ToString());
                    //    writer.Close();
                    //    lblExamNo.Visible = true;
                    //    lblExamNo.Text = idnum.ToString();

                    //}
                    //else
                    //{

                    //    //this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        int iRetUSB = 0, iRetCOM = 0;

        private void personInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Application.StartupPath + "\\zp.bmp";

            try
            {

                int iPort;
                for (iPort = 1001; iPort <= 1016; iPort++)
                {
                    iRetUSB = CVRSDK.CVR_InitComm(iPort);
                    if (iRetUSB == 1)
                    {
                        break;
                    }
                }
                if (iRetUSB != 1)
                {
                    for (iPort = 1; iPort <= 4; iPort++)
                    {
                        iRetCOM = CVRSDK.CVR_InitComm(iPort);
                        if (iRetCOM == 1)
                        {
                            break;
                        }
                    }
                }

                if ((iRetCOM == 1) || (iRetUSB == 1))
                {
                    this.label9.Text = "初始化成功！";
                }
                else
                {
                    this.label9.Text = "初始化失败！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        bool isClose = false;
        private void button2_Click(object sender, EventArgs e)
        {
            isClose = true;
            try
            {
                int isSuccess = CVRSDK.CVR_CloseComm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClose)
            {
                try
                {
                    CVRSDK.CVR_CloseComm();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //扫描结构：
        [StructLayout(LayoutKind.Sequential, Size = 16, CharSet = CharSet.Ansi)]
        public struct IDCARD_ALL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char name;     //姓名
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public char sex;      //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public char people;    //民族，护照识别时此项为空
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char birthday;   //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 70)]
            public char address;  //地址，在识别护照时导出的是国籍简码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public char number;  //地址，在识别护照时导出的是国籍简码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char signdate;   //签发日期，在识别护照时导出的是有效期至 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfStart;  //有效起始日期，在识别护照时为空
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfEnd;  //有效截止日期，在识别护照时为空
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
                //label13.Text = txtlength.ToString();
                lblSykh.Text = "剩余考号：" + txtlength.ToString();
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
                }
                else
                {
                    MessageBox.Show("考号已派发完。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    result = false;
                }
            }
            else
            {
                MessageBox.Show("该考试没有给考场分配考号，请先配置准考证号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        private void btn_ExamNo_Click(object sender, EventArgs e)
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
        private void pd_PrintPage1(object sender, PrintPageEventArgs e)
        {
            Brush b = new SolidBrush(Color.Black);

            //打印考号
            string examno = lblExamNo.Text;
            Font f = new Font("黑体", 142);
            float x = 25.0F;
            float y = 200.0F;
            e.Graphics.DrawString(examno, f, b, x, y);

            string am_pm = "";
            //打印logo     方正小篆体     
            //Font f1 = new Font("方正小篆体", 40);
            //am_pm = "行";

            //打印上下午
            Font f1 = new Font("隶书", 16);
            am_pm = publicModel.am_pm;
            PointF drawPoint1 = new PointF(3.0F, -10.0F);
            float x1 = 10.0F;
            float y1 = 220.0F;
            e.Graphics.DrawString(am_pm, f1, b, x1, y1);

            e.Graphics.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getStuExamRandomNum("六考场1");
        }

    }
}
