using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CVR100A_U_DSDK_Demo.App_Code
{
    /// <summary>
    /// 类db_students。
    /// </summary>
    [Serializable]
    public partial class db_students
    {
        public db_students()
        { }
        #region Model
        private int _id;
        private string _stuname;
        private string _stuno;
        private string _idcard;
        private string _prushtime;
        private string _sex;
        private string _nation;
        private string _birthday;
        private string _address;
        private string _qianzhengjiguan;
        private string _youxiaoqixian;
        private string _applyno;
        private string _status;
        private string _remark;
        private string _kaochangname;
        private string _examnameid;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 考生姓名
        /// </summary>
        public string stuName
        {
            set { _stuname = value; }
            get { return _stuname; }
        }
        /// <summary>
        /// 考号
        /// </summary>
        public string stuNo
        {
            set { _stuno = value; }
            get { return _stuno; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 刷卡时间
        /// </summary>
        public string prushTime
        {
            set { _prushtime = value; }
            get { return _prushtime; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 签证机关
        /// </summary>
        public string qianzhengjiguan
        {
            set { _qianzhengjiguan = value; }
            get { return _qianzhengjiguan; }
        }
        /// <summary>
        /// 有效期限
        /// </summary>
        public string youxiaoqixian
        {
            set { _youxiaoqixian = value; }
            get { return _youxiaoqixian; }
        }
        /// <summary>
        /// 报名序号
        /// </summary>
        public string applyNo
        {
            set { _applyno = value; }
            get { return _applyno; }
        }
        /// <summary>
        /// 身份证录入状况（正常、异常）
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 考场名称
        /// </summary>
        public string kaochangName
        {
            set { _kaochangname = value; }
            get { return _kaochangname; }
        }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string examNameID
        {
            set { _examnameid = value; }
            get { return _examnameid; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public db_students(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,stuName,stuNo,IdCard,prushTime,sex,nation,birthday,address,qianzhengjiguan,youxiaoqixian,applyNo,status,kaochangName,examNameID ");
            strSql.Append(" FROM [db_students] ");
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
                if (ds.Tables[0].Rows[0]["stuName"] != null)
                {
                    this.stuName = ds.Tables[0].Rows[0]["stuName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["stuNo"] != null)
                {
                    this.stuNo = ds.Tables[0].Rows[0]["stuNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IdCard"] != null)
                {
                    this.IdCard = ds.Tables[0].Rows[0]["IdCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["prushTime"] != null)
                {
                    this.prushTime = ds.Tables[0].Rows[0]["prushTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null)
                {
                    this.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["nation"] != null)
                {
                    this.nation = ds.Tables[0].Rows[0]["nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["birthday"] != null)
                {
                    this.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["qianzhengjiguan"] != null)
                {
                    this.qianzhengjiguan = ds.Tables[0].Rows[0]["qianzhengjiguan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["youxiaoqixian"] != null)
                {
                    this.youxiaoqixian = ds.Tables[0].Rows[0]["youxiaoqixian"].ToString();
                }
                if (ds.Tables[0].Rows[0]["applyNo"] != null)
                {
                    this.applyNo = ds.Tables[0].Rows[0]["applyNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null)
                {
                    this.status = ds.Tables[0].Rows[0]["status"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [db_students]");
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
            strSql.Append("insert into [db_students] (");
            strSql.Append("stuName,stuNo,IdCard,prushTime,sex,nation,birthday,address,qianzhengjiguan,youxiaoqixian,applyNo,status,kaochangName,examNameID)");
            strSql.Append(" values (");
            strSql.Append("@stuName,@stuNo,@IdCard,@prushTime,@sex,@nation,@birthday,@address,@qianzhengjiguan,@youxiaoqixian,@applyNo,@status,@kaochangName,@examNameID)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@stuName", OleDbType.VarChar,255),
					new OleDbParameter("@stuNo", OleDbType.VarChar,255),
					new OleDbParameter("@IdCard", OleDbType.VarChar,255),
					new OleDbParameter("@prushTime", OleDbType.VarChar,255),
					new OleDbParameter("@sex", OleDbType.VarChar,255),
					new OleDbParameter("@nation", OleDbType.VarChar,255),
					new OleDbParameter("@birthday", OleDbType.VarChar,255),
					new OleDbParameter("@address", OleDbType.VarChar,255),
					new OleDbParameter("@qianzhengjiguan", OleDbType.VarChar,255),
					new OleDbParameter("@youxiaoqixian", OleDbType.VarChar,255),
					new OleDbParameter("@applyNo", OleDbType.VarChar,255),
					new OleDbParameter("@status", OleDbType.VarChar,255),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255)};
            parameters[0].Value = stuName;
            parameters[1].Value = stuNo;
            parameters[2].Value = IdCard;
            parameters[3].Value = prushTime;
            parameters[4].Value = sex;
            parameters[5].Value = nation;
            parameters[6].Value = birthday;
            parameters[7].Value = address;
            parameters[8].Value = qianzhengjiguan;
            parameters[9].Value = youxiaoqixian;
            parameters[10].Value = applyNo;
            parameters[11].Value = status;
            parameters[12].Value = kaochangName;
            parameters[13].Value = examNameID;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [db_students] set ");
            strSql.Append("stuName=@stuName,");
            strSql.Append("stuNo=@stuNo,");
            strSql.Append("IdCard=@IdCard,");
            strSql.Append("prushTime=@prushTime,");
            strSql.Append("sex=@sex,");
            strSql.Append("nation=@nation,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("address=@address,");
            strSql.Append("qianzhengjiguan=@qianzhengjiguan,");
            strSql.Append("youxiaoqixian=@youxiaoqixian,");
            strSql.Append("applyNo=@applyNo,");
            strSql.Append("status=@status,");
            strSql.Append("kaochangName=@kaochangName,");
            strSql.Append("examNameID=@examNameID");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@stuName", OleDbType.VarChar,255),
					new OleDbParameter("@stuNo", OleDbType.VarChar,255),
					new OleDbParameter("@IdCard", OleDbType.VarChar,255),
					new OleDbParameter("@prushTime", OleDbType.VarChar,255),
					new OleDbParameter("@sex", OleDbType.VarChar,255),
					new OleDbParameter("@nation", OleDbType.VarChar,255),
					new OleDbParameter("@birthday", OleDbType.VarChar,255),
					new OleDbParameter("@address", OleDbType.VarChar,255),
					new OleDbParameter("@qianzhengjiguan", OleDbType.VarChar,255),
					new OleDbParameter("@youxiaoqixian", OleDbType.VarChar,255),
					new OleDbParameter("@applyNo", OleDbType.VarChar,255),
					new OleDbParameter("@status", OleDbType.VarChar,255),
					new OleDbParameter("@kaochangName", OleDbType.VarChar,255),
					new OleDbParameter("@examNameID", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = stuName;
            parameters[1].Value = stuNo;
            parameters[2].Value = IdCard;
            parameters[3].Value = prushTime;
            parameters[4].Value = sex;
            parameters[5].Value = nation;
            parameters[6].Value = birthday;
            parameters[7].Value = address;
            parameters[8].Value = qianzhengjiguan;
            parameters[9].Value = youxiaoqixian;
            parameters[10].Value = applyNo;
            parameters[11].Value = status;
            parameters[12].Value = kaochangName;
            parameters[13].Value = examNameID;
            parameters[14].Value = ID;

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
            strSql.Append("delete from [db_students] ");
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
            strSql.Append("select ID,stuName,stuNo,IdCard,prushTime,sex,nation,birthday,address,qianzhengjiguan,youxiaoqixian,applyNo,status,kaochangName,examNameID ");
            strSql.Append(" FROM [db_students] ");
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
                if (ds.Tables[0].Rows[0]["stuName"] != null)
                {
                    this.stuName = ds.Tables[0].Rows[0]["stuName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["stuNo"] != null)
                {
                    this.stuNo = ds.Tables[0].Rows[0]["stuNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IdCard"] != null)
                {
                    this.IdCard = ds.Tables[0].Rows[0]["IdCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["prushTime"] != null)
                {
                    this.prushTime = ds.Tables[0].Rows[0]["prushTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null)
                {
                    this.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["nation"] != null)
                {
                    this.nation = ds.Tables[0].Rows[0]["nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["birthday"] != null)
                {
                    this.birthday = ds.Tables[0].Rows[0]["birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null)
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["qianzhengjiguan"] != null)
                {
                    this.qianzhengjiguan = ds.Tables[0].Rows[0]["qianzhengjiguan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["youxiaoqixian"] != null)
                {
                    this.youxiaoqixian = ds.Tables[0].Rows[0]["youxiaoqixian"].ToString();
                }
                if (ds.Tables[0].Rows[0]["applyNo"] != null)
                {
                    this.applyNo = ds.Tables[0].Rows[0]["applyNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null)
                {
                    this.status = ds.Tables[0].Rows[0]["status"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kaochangName"] != null)
                {
                    this.kaochangName = ds.Tables[0].Rows[0]["kaochangName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["examNameID"] != null)
                {
                    this.examNameID = ds.Tables[0].Rows[0]["examNameID"].ToString();
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
            strSql.Append(" FROM [db_students] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
