using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_users。
    /// </summary>
    [Serializable]
    public partial class db_users
    {
        public db_users()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _userpwd;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string userPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_users(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,userName,userPwd ");
            strSql.Append(" FROM [db_users] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userName"] != null)
                {
                    this.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userPwd"] != null)
                {
                    this.userPwd = ds.Tables[0].Rows[0]["userPwd"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_users]");
            strSql.Append(" where ID=@ID ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username,string userpwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_users]");
            strSql.Append(" where userName=@userName and userPwd=@userPwd ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255),
					new OleDbParameter("@userPwd", OleDbType.VarChar,255)};
            parameters[0].Value = username;
            parameters[1].Value = userpwd;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [db_users] (");
            strSql.Append("userName,userPwd)");
            strSql.Append(" values (");
            strSql.Append("@userName,@userPwd)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255),
					new OleDbParameter("@userPwd", OleDbType.VarChar,255)};
            parameters[0].Value = userName;
            parameters[1].Value = userPwd;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 修改表一列数据
        /// </summary>
        public void UpdateNewsField(string userName, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_users] set " + strValue);
            strSql.Append(" where userName='" + userName + "'");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_users] set ");
            strSql.Append("userName=@userName,");
            strSql.Append("userPwd=@userPwd");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@userName", OleDbType.VarChar,255),
					new OleDbParameter("@userPwd", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = userName;
            parameters[1].Value = userPwd;
            parameters[2].Value = ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [db_users] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,userName,userPwd ");
            strSql.Append(" FROM [db_users] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userName"] != null)
                {
                    this.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["userPwd"] != null)
                {
                    this.userPwd = ds.Tables[0].Rows[0]["userPwd"].ToString();
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [db_users] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
