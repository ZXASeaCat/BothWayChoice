using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 数据访问类：学生账号
    /// </summary>
    [Serializable]
    public partial class StudentAccount
    {
        public StudentAccount()
        { 
        }
        public  bool Add(Model.StudentAccount model)
        {
            string strSql = "insert into [student_account] values(@StuNo,@Password)";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),
                new SqlParameter("@Password", SqlDbType.VarChar,50),};
            parameters[0].Value = model.StuNo;
            parameters[1].Value = model.Password;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Login(Model.StudentAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [student_account]");
            strSql.Append(" where stuno=@StuNo and password=@Password");
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),
                new SqlParameter("@Password", SqlDbType.VarChar,50),};
            parameters[0].Value = model.StuNo;
            parameters[1].Value = model.Password;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Login(string userNo, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [student_account]");
            strSql.Append(" where stuno=@StuNo and password=@Password");
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),
                new SqlParameter("@Password", SqlDbType.VarChar,50),};
            parameters[0].Value = userNo;
            parameters[1].Value = userPassword;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Update(Model.StudentAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [student_account] set ");
            strSql.Append("password=@Password");
            strSql.Append(" where stuno=@StuNo ");
            SqlParameter[] parameters = {
                new SqlParameter("@Password", SqlDbType.VarChar,50),
                new SqlParameter("@StuNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.StuNo;
            int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows == 1)
                return true;
            else
                return false;
        }

        public bool Delete(string stuNo)
        {
            string strSql = "delete from [student_account] where stuno = @StuNo";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),};
            parameters[0].Value = stuNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
    }
}
