using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_examName。
    /// </summary>
    [Serializable]
    public partial class db_examName
    {
        public db_examName()
        { }
        #region Model
        private int _id;
        private string _examname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string examName
        {
            set { _examname = value; }
            get { return _examname; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_examName(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,examName ");
            strSql.Append(" FROM [db_examName] ");
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
                if (ds.Tables[0].Rows[0]["examName"] != null)
                {
                    this.examName = ds.Tables[0].Rows[0]["examName"].ToString();
                }
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_examName(string examName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,examName ");
            strSql.Append(" FROM [db_examName] ");
            strSql.Append(" where examName=@examName ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@examName", OleDbType.VarChar,255)};
            parameters[0].Value = examName;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["examName"] != null)
                {
                    this.examName = ds.Tables[0].Rows[0]["examName"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_examName]");
            strSql.Append(" where ID=@ID ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string examName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_examName]");
            strSql.Append(" where examName=@examName ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@examName", OleDbType.VarChar,255)};
            parameters[0].Value = examName;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [db_examName] (");
            strSql.Append("examName)");
            strSql.Append(" values (");
            strSql.Append("@examName)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@examName", OleDbType.VarChar,255)};
            parameters[0].Value = examName;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_examName] set ");
            strSql.Append("examName=@examName");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@examName", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = examName;
            parameters[1].Value = ID;

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
            strSql.Append("delete from [db_examName] ");
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [db_examName] ");
            strSql.Append(" where ID in ("+idList+")");

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
            strSql.Append("select ID,examName ");
            strSql.Append(" FROM [db_examName] ");
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
                if (ds.Tables[0].Rows[0]["examName"] != null)
                {
                    this.examName = ds.Tables[0].Rows[0]["examName"].ToString();
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
            strSql.Append(" FROM [db_examName] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
