using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 数据访问类：学生
    /// </summary>
    [Serializable]
    public partial class Student
    {
        public Student()
        { }

        
        public  bool Add(Model.Student model)
        {
            string strSql = "insert into [student] values(@StuNo,@StuName,@Grade,@Subject,@College,@Phone,@Living)";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),
                new SqlParameter("@StuName", SqlDbType.VarChar,50),
                new SqlParameter("@Grade", SqlDbType.VarChar,50),
                new SqlParameter("@Subject", SqlDbType.VarChar,50),
                new SqlParameter("@College", SqlDbType.VarChar,50),
                new SqlParameter("@Phone", SqlDbType.VarChar,50),
                new SqlParameter("@Living", SqlDbType.VarChar,50),};
            parameters[0].Value = model.StuNo;
            parameters[1].Value = model.StuName;
            parameters[2].Value = model.Grade;
            parameters[3].Value = model.Subject;
            parameters[4].Value = model.College;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Living;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Delete(string stuNo)
        {
            string strSql = "delete from [student] where stuno = @StuNo";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),};
            parameters[0].Value = stuNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Update(Model.Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [student] set ");
            strSql.Append("stuname=@StuName,");
            strSql.Append("grade=@Grade,");
            strSql.Append("subject=@Subject,");
            strSql.Append("college=@College,");
            strSql.Append("phone=@Phone,");
            strSql.Append("living=@Living");
            strSql.Append(" where stuno=@StuNo ");
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),
                new SqlParameter("@StuName", SqlDbType.VarChar,50),
                new SqlParameter("@Grade", SqlDbType.VarChar,50),
                new SqlParameter("@Subject", SqlDbType.VarChar,50),
                new SqlParameter("@College", SqlDbType.VarChar,50),
                new SqlParameter("@Phone", SqlDbType.VarChar,50),
                new SqlParameter("@Living", SqlDbType.VarChar,50),};
            parameters[0].Value = model.StuNo;
            parameters[1].Value = model.StuName;
            parameters[2].Value = model.Grade;
            parameters[3].Value = model.Subject;
            parameters[4].Value = model.College;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Living;
            int n = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }

        public bool CheckExist(string stuNo)
        {
            string strSql = "select * from [student] where stuno=@StuNo";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),};
            parameters[0].Value = stuNo;
            if (SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters) != null)
                return true;
            else
                return false;
        }
        public  Model.Student Get(string stuNo)
        {
            string strSql = "select top 1 StuName,Grade,Subject,College,Phone,Living from [student] where stuno=@StuNo";
            SqlParameter[] parameters = {
				new SqlParameter("@StuNo", SqlDbType.VarChar,50),};
            parameters[0].Value = stuNo;
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                Model.Student model = new Model.Student();
                model.StuNo = stuNo;
                if (dt.Rows[0]["StuName"] != null && dt.Rows[0]["StuName"].ToString() != "")
                {
                    model.StuName = dt.Rows[0]["StuName"].ToString();
                }
                if (dt.Rows[0]["Grade"] != null && dt.Rows[0]["Grade"].ToString() != "")
                {
                    model.Grade = dt.Rows[0]["Grade"].ToString();
                }
                if (dt.Rows[0]["Subject"] != null && dt.Rows[0]["Subject"].ToString() != "")
                {
                    model.Subject = dt.Rows[0]["Subject"].ToString();
                }
                if (dt.Rows[0]["College"] != null && dt.Rows[0]["College"].ToString() != "")
                {
                    model.College = dt.Rows[0]["College"].ToString();
                }
                if (dt.Rows[0]["Phone"] != null && dt.Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = dt.Rows[0]["Phone"].ToString();
                }
                if (dt.Rows[0]["Living"] != null && dt.Rows[0]["Living"].ToString() != "")
                {
                    model.Living = dt.Rows[0]["Living"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
            
        }

        public DataTable GetAllStudents()
        {
            string strSql = "select stuno ,stuname ,grade ,subject ,college ,phone ,living from [student]";
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text);
            return dt;
        }

        public void UpdateStudent(DataTable dtsource)
        {
            SqlDbHelper.UpdateDataTable(dtsource, "student");
        }
    }
}
