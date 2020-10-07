using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 数据访问类:TeacherAccount
    /// </summary>
    public partial class TeacherAccount
    {
        public TeacherAccount()
        { }
        #region  Method
        public bool Add(Model.TeacherAccount model)
        {
            string strSql = "insert into teacher_account values(@TeacherNo,@Password)";
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Password", SqlDbType.VarChar,50),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.Password;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Login(Model.TeacherAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [teacher_account]");
            strSql.Append(" where teacherno=@TeacherNo and password=@Password");
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Password", SqlDbType.VarChar,50),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.Password;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Update(Model.TeacherAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [teacher_account] set ");
            strSql.Append("password=@Password");
            strSql.Append(" where teacherno=@TeacherNo ");
            SqlParameter[] parameters = {
                new SqlParameter("@Password", SqlDbType.VarChar,50),
                new SqlParameter("@TeacherNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.TeacherNo;
            int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows == 1)
                return true;
            else
                return false;
        }
        public bool Login(string userNo, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from teacher_account");
            strSql.Append(" where Teacherno=@UserNo and Password=@UserPassword");
            SqlParameter[] parameters = {
					new SqlParameter("@UserNo", SqlDbType.VarChar,50),
                    new SqlParameter("@UserPassword", SqlDbType.VarChar,50),};
            parameters[0].Value = userNo;
            parameters[1].Value = userPassword;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool login(string userno, string password)
        {
            return true;
        }


        public bool Delete(string teacherNo)
        {
            string strSql = "delete from [teacher_account] where teacherno = @TeacherNo";
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        #endregion  Method
    }
}
