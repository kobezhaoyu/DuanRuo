using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CVR100A_U_DSDK_Demo
{
    public partial class Form3 : Form
    {
        public Form3(string ipPrefix, int startIP, int endIP)
        {
            InitializeComponent();

            this.startIP = startIP;
            this.endIP = endIP;
            this.ipPrefix = ipPrefix;
            computerList = new ArrayList();
        } 

        private void Form3_Load(object sender, EventArgs e)
        {

        } 
  
        private int startIP = 0;  
        private int endIP = 0;  
        private string ipPrefix = "";  
        private ArrayList computerList = null;    
    
        public void ScanComputers()   
        {   
            for(int i=startIP;i<=endIP;i++)   
            {   
                string scanIP = ipPrefix +"."+i.ToString();   
  
                IPAddress myScanIP = IPAddress.Parse(scanIP);   
  
                IPHostEntry myScanHost = null;   
  
                string[] arr = new string[2];   
  
                try   
                {   
                    myScanHost = Dns.GetHostByAddress(myScanIP);   
                }   
  
                catch   
                {  
                    continue;  
                }  
  
                if (myScanHost != null)   
                {  
                    arr[0] = myScanHost.HostName;   
  
                    arr[1] = scanIP;   
  
                    computerList.Add(arr);  
        MessageBox.Show(myScanHost.HostName.ToString());  
                    MessageBox.Show(scanIP.ToString());  
                }  
            }  
        }  
  
        private void button1_Click(object sender, EventArgs e)  
        {  
            //Form3 cai = new Form3("192.168.1", 100, 135);  
  
            //Thread thScan = new Thread(new ThreadStart(cai.ScanComputers));  
  
            //thScan.Start();  

            
        } 
    }
}
