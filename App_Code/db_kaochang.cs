using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_kaochang。
    /// </summary>
    [Serializable]
    public partial class db_kaochang
    {
        public db_kaochang()
        { }
        #region Model
        private int _id;
        private string _kcname;
        private string _examnameid;
        private bool _islock = false;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 考场名称
        /// </summary>
        public string kcName
        {
            set { _kcname = value; }
            get { return _kcname; }
        }
        /// <summary>
        /// 隶属考场名称ID
        /// </summary>
        public string examNameID
        {
            set { _examnameid = value; }
            get { return _examnameid; }
        }
        /// <summary>
        /// 是否禁用考场
        /// </summary>
        public bool isLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_kaochang(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,kcName,examNameID,isLock,remark ");
            strSql.Append(" FROM [db_kaochang] ");
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
                if (ds.Tables[0].Rows[0]["kcName"] != null)
                {
                    this.kcName = ds.Tables[0].Rows[0]["kcName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isLock"] != null && ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["isLock"].ToString().ToLower() == "true"))
                    {
                        this.isLock = true;
                    }
                    else
                    {
                        this.isLock = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_kaochang(string kcmc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,kcName,examNameID,isLock,remark ");
            strSql.Append(" FROM [db_kaochang] ");
            strSql.Append(" where kcName=@kcName ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@kcName", OleDbType.VarChar,255)};
            parameters[0].Value = kcmc;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kcName"] != null)
                {
                    this.kcName = ds.Tables[0].Rows[0]["kcName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isLock"] != null && ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["isLock"].ToString().ToLower() == "true"))
                    {
                        this.isLock = true;
                    }
                    else
                    {
                        this.isLock = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_kaochang]");
            strSql.Append(" where ID=@ID ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string kcmc,string examName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_kaochang]");
            strSql.Append(" where kcname=@kcname and examNameID=@examName");

            OleDbParameter[] parameters = {
					new OleDbParameter("@kcname", OleDbType.VarChar,255),new OleDbParameter("@examName", OleDbType.VarChar,255)};
            parameters[0].Value = kcmc;
            parameters[1].Value = examName;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [db_kaochang] (");
            strSql.Append("kcName,examNameID,isLock,remark)");
            strSql.Append(" values (");
            strSql.Append("@kcName,@examNameID,@isLock,@remark)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@kcName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255),
					new OleDbParameter("@isLock", OleDbType.Boolean,1),
					new OleDbParameter("@remark", OleDbType.VarChar,0)};
            parameters[0].Value = kcName;
            parameters[1].Value = examNameID;
            parameters[2].Value = isLock;
            parameters[3].Value = remark;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_kaochang] set ");
            strSql.Append("kcName=@kcName,");
            strSql.Append("examNameID=@examNameID,");
            strSql.Append("isLock=@isLock,");
            strSql.Append("remark=@remark");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@kcName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255),
					new OleDbParameter("@isLock", OleDbType.Boolean,1),
					new OleDbParameter("@remark", OleDbType.VarChar,0),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = kcName;
            parameters[1].Value = examNameID;
            parameters[2].Value = isLock;
            parameters[3].Value = remark;
            parameters[4].Value = ID;

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
            strSql.Append("delete from [db_kaochang] ");
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
            strSql.Append("delete from [db_kaochang] ");
            strSql.Append(" where ID in (" + idList + ")");

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
            strSql.Append("select ID,kcName,examNameID,isLock,remark ");
            strSql.Append(" FROM [db_kaochang] ");
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
                if (ds.Tables[0].Rows[0]["kcName"] != null)
                {
                    this.kcName = ds.Tables[0].Rows[0]["kcName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isLock"] != null && ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["isLock"].ToString().ToLower() == "true"))
                    {
                        this.isLock = true;
                    }
                    else
                    {
                        this.isLock = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
            strSql.Append(" FROM [db_kaochang] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
