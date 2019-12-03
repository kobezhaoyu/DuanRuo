using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_theExamNo。
    /// </summary>
    [Serializable]
    public partial class db_theExamNo
    {
        public db_theExamNo()
        { }
        #region Model
        private int _id;
        private int? _startnum;
        private int? _endnum;
        private string _kaochangname;
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
        /// 开始考号
        /// </summary>
        public int? startNum
        {
            set { _startnum = value; }
            get { return _startnum; }
        }
        /// <summary>
        /// 结束考号
        /// </summary>
        public int? endNum
        {
            set { _endnum = value; }
            get { return _endnum; }
        }
        /// <summary>
        /// 所属考场
        /// </summary>
        public string kaochangName
        {
            set { _kaochangname = value; }
            get { return _kaochangname; }
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
        public db_theExamNo(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,startNum,endNum,kaochangName,remark ");
            strSql.Append(" FROM [db_theExamNo] ");
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
                if (ds.Tables[0].Rows[0]["startNum"] != null && ds.Tables[0].Rows[0]["startNum"].ToString() != "")
                {
                    this.startNum = int.Parse(ds.Tables[0].Rows[0]["startNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["endNum"] != null && ds.Tables[0].Rows[0]["endNum"].ToString() != "")
                {
                    this.endNum = int.Parse(ds.Tables[0].Rows[0]["endNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
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
            strSql.Append("select count(1) from [db_theExamNo]");
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
            strSql.Append("insert into [db_theExamNo] (");
            strSql.Append("startNum,endNum,kaochangName,remark)");
            strSql.Append(" values (");
            strSql.Append("@startNum,@endNum,@kaochangName,@remark)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@startNum", OleDbType.Integer,4),
					new OleDbParameter("@endNum", OleDbType.Integer,4),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@remark", OleDbType.VarChar,255)};
            parameters[0].Value = startNum;
            parameters[1].Value = endNum;
            parameters[2].Value = kaochangName;
            parameters[3].Value = remark;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_theExamNo] set ");
            strSql.Append("startNum=@startNum,");
            strSql.Append("endNum=@endNum,");
            strSql.Append("kaochangName=@kaochangName,");
            strSql.Append("remark=@remark");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@startNum", OleDbType.Integer,4),
					new OleDbParameter("@endNum", OleDbType.Integer,4),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@remark", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = startNum;
            parameters[1].Value = endNum;
            parameters[2].Value = kaochangName;
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
            strSql.Append("delete from [db_theExamNo] ");
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
            strSql.Append("select ID,startNum,endNum,kaochangName,remark ");
            strSql.Append(" FROM [db_theExamNo] ");
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
                if (ds.Tables[0].Rows[0]["startNum"] != null && ds.Tables[0].Rows[0]["startNum"].ToString() != "")
                {
                    this.startNum = int.Parse(ds.Tables[0].Rows[0]["startNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["endNum"] != null && ds.Tables[0].Rows[0]["endNum"].ToString() != "")
                {
                    this.endNum = int.Parse(ds.Tables[0].Rows[0]["endNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
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
            strSql.Append(" FROM [db_theExamNo] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
