using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_exam。
    /// </summary>
    [Serializable]
    public partial class db_exam
    {
        public db_exam()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _idcard;
        private string _kaochangname;
        private string _examnameid;
        private string _status;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string idcard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kaochangName
        {
            set { _kaochangname = value; }
            get { return _kaochangname; }
        }
        /// <summary>
        /// 隶属考试名称
        /// </summary>
        public string examNameID
        {
            set { _examnameid = value; }
            get { return _examnameid; }
        }
        /// <summary>
        /// 未签到、已签到
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_exam(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,name,idcard,kaochangName,examNameID,status ");
            strSql.Append(" FROM [db_exam] ");
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
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["idcard"] != null)
                {
                    this.idcard = ds.Tables[0].Rows[0]["idcard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null)
                {
                    this.status = ds.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_exam]");
            strSql.Append(" where ID=@ID ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [db_exam] (");
            strSql.Append("name,idcard,kaochangName,examNameID,status)");
            strSql.Append(" values (");
            strSql.Append("@name,@idcard,@kaochangName,@examNameID,@status)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@name", OleDbType.VarChar,255),
					new OleDbParameter("@idcard", OleDbType.VarChar,255),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255),
					new OleDbParameter("@status", OleDbType.VarChar,255)};
            parameters[0].Value = name;
            parameters[1].Value = idcard;
            parameters[2].Value = kaochangName;
            parameters[3].Value = examNameID;
            parameters[4].Value = status;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_exam] set ");
            strSql.Append("name=@name,");
            strSql.Append("idcard=@idcard,");
            strSql.Append("kaochangName=@kaochangName,");
            strSql.Append("examNameID=@examNameID,");
            strSql.Append("status=@status");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@name", OleDbType.VarChar,255),
					new OleDbParameter("@idcard", OleDbType.VarChar,255),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255),
					new OleDbParameter("@status", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = name;
            parameters[1].Value = idcard;
            parameters[2].Value = kaochangName;
            parameters[3].Value = examNameID;
            parameters[4].Value = status;
            parameters[5].Value = ID;

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
            strSql.Append("delete from [db_exam] ");
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
            strSql.Append("select ID,name,idcard,kaochangName,examNameID,status ");
            strSql.Append(" FROM [db_exam] ");
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
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["idcard"] != null)
                {
                    this.idcard = ds.Tables[0].Rows[0]["idcard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null)
                {
                    this.status = ds.Tables[0].Rows[0]["status"].ToString();
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
            strSql.Append(" FROM [db_exam] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method


        #region 新增
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_exam( string idcard, string examnameid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,name,idcard,kaochangName,examNameID,status ");
            strSql.Append(" FROM [db_exam] ");
            strSql.Append(" where idcard=@idcard and examNameID=@examNameID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@idcard", OleDbType.VarChar,100),
                    new OleDbParameter("@examNameID", OleDbType.VarChar,100)};
            parameters[0].Value = idcard;
            parameters[1].Value = examnameid;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["idcard"] != null)
                {
                    this.idcard = ds.Tables[0].Rows[0]["idcard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null)
                {
                    this.status = ds.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }

        #endregion
    }
}
