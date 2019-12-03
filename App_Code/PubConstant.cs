using System;
using System.Configuration;
using System.Windows.Forms;
namespace CVR100A_U_DSDK_Demo
{
    
    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public string ConnectionString
        {           
            get 
            {
                //string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();// +Application.StartupPath + "\\access.accdb";
                string _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + ConfigurationSettings.AppSettings["ConnString"];
                return _connectionString; 
            }
        }

      
    }
}
