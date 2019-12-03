using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace CVR100A_U_DSDK_Demo
{
    public unsafe  partial  class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

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
                                this.label10.Text = "���������ɹ���";
                                FillData();
                            }
                            else
                            {
                                this.label10.Text = "��������ʧ�ܣ�";
                            }
                        }
                        else
                        {
                            MessageBox.Show("δ�ſ���Ƭ���ò���ȷ");
                        }
                }
                else
                {
                    MessageBox.Show("��ʼ��ʧ�ܣ�");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public StringBuilder name;     //����
        public String sex;      //�Ա�
        public String people;    //���壬����ʶ��ʱ����Ϊ��
        public String birthday;   //��������
        public String address;  //��ַ����ʶ����ʱ�������ǹ�������
        public string number;  //��ַ����ʶ����ʱ�������ǹ�������
        public string signdate;   //ǩ�����ڣ���ʶ����ʱ����������Ч���� 
        public string validtermOfStart;  //��Ч��ʼ���ڣ���ʶ����ʱΪ��
        public string validtermOfEnd;  //��Ч��ֹ���ڣ���ʶ����ʱΪ��
        
       public void FillData()
        {
            try
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\zp.bmp";
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
                CVRSDK.GetPeopleSex(ref sex [0], ref length);

                byte[] samid = new byte[32];
                CVRSDK.CVR_GetSAMID(ref samid[0]);


                lblAddress.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0", "").Trim();
                lblSex.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
                lblBirthday.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0", "").Trim();
                lblDept.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(signdate).Replace("\0", "").Trim();
                lblIdCard.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
                lblName.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0", "").Trim();
                lblNation.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0", "").Trim();
                label11.Text = "��ȫģ��ţ�"+System.Text.Encoding.GetEncoding("GB2312").GetString(samid).Replace("\0","").Trim();
                lblValidDate.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfStart).Replace("\0", "").Trim() + "-" + System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfEnd).Replace("\0", "").Trim();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        int iRetUSB = 0, iRetCOM = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    this.label9.Text = "��ʼ���ɹ���";
                }
                else
                {
                    this.label9.Text = "��ʼ��ʧ�ܣ�";
                }
            }
            catch(Exception ex)
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

        //ɨ��ṹ��
        [StructLayout(LayoutKind.Sequential, Size = 16, CharSet = CharSet.Ansi)]
        public struct IDCARD_ALL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char name;     //����
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public char sex;      //�Ա�
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public char people;    //���壬����ʶ��ʱ����Ϊ��
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char birthday;   //��������
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 70)]
            public char address;  //��ַ����ʶ����ʱ�������ǹ�������
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public char number;  //��ַ����ʶ����ʱ�������ǹ�������
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char signdate;   //ǩ�����ڣ���ʶ����ʱ����������Ч���� 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfStart;  //��Ч��ʼ���ڣ���ʶ����ʱΪ��
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfEnd;  //��Ч��ֹ���ڣ���ʶ����ʱΪ��
        }

        
    }
}