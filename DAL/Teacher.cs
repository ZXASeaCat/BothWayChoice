using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public partial class Teacher
    {
        public Teacher()
        { }

        public bool Add(Model.Teacher model)
        {
            string strSql = "insert into [teacher] values(@teacherno,@teachername,@Subject,@College,@research,@brief)";
            SqlParameter[] parameters = {
				new SqlParameter("@teacherno", SqlDbType.VarChar,50),
                new SqlParameter("@teachername", SqlDbType.VarChar,50),
                new SqlParameter("@Subject", SqlDbType.VarChar,50),
                new SqlParameter("@College", SqlDbType.VarChar,50),
                new SqlParameter("@research", SqlDbType.VarChar,50),
                new SqlParameter("@brief", SqlDbType.VarChar,50),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.TeacherName;
            parameters[2].Value = model.Subject;
            parameters[3].Value = model.College;
            parameters[4].Value = model.Research;
            parameters[5].Value = model.Brief;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Delete(string teacherNo)
        {
            string strSql = "delete from [teacher] where teacherno = @teacherno";
            SqlParameter[] parameters = {
				new SqlParameter("@teacherno", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Update(Model.Teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [teacher] set ");
            strSql.Append("teachername=@teachername,");
            strSql.Append("subject=@Subject,");
            strSql.Append("college=@College,");
            strSql.Append("research=@research,");
            strSql.Append("brief=@brief");
            strSql.Append(" where teacherno=@teacherno ");
            SqlParameter[] parameters = {
				new SqlParameter("@teacherno", SqlDbType.VarChar,50),
                new SqlParameter("@teachername", SqlDbType.VarChar,50),
                new SqlParameter("@Subject", SqlDbType.VarChar,50),
                new SqlParameter("@College", SqlDbType.VarChar,50),
                new SqlParameter("@research", SqlDbType.VarChar,50),
                new SqlParameter("@brief", SqlDbType.VarChar,50),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.TeacherName;
            parameters[2].Value = model.Subject;
            parameters[3].Value = model.College;
            parameters[4].Value = model.Research;
            parameters[5].Value = model.Brief;
            int n = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查该教师信息是否已存在数据库
        /// </summary>
        /// <param name="teacherNo"></param>
        /// <returns></returns>
        public bool CheckExist(string teacherNo)
        {
            string strSql = "select * from [teacher] where teacherno=@teacherno";
            SqlParameter[] parameters = {
				new SqlParameter("@teacherno", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            if (SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取单个教师信息
        /// </summary>
        /// <param name="teacherNo">教师号</param>
        /// <returns></returns>
        public Model.Teacher Get(string teacherNo)
        {
            string strSql = "select top 1 teachername,Subject,College,research,brief from [teacher] where teacherno=@teacherno";
            SqlParameter[] parameters = {
				new SqlParameter("@teacherno", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                Model.Teacher model = new Model.Teacher();
                model.TeacherNo = teacherNo;
                if (dt.Rows[0]["teachername"] != null && dt.Rows[0]["teachername"].ToString() != "")
                {
                    model.TeacherName = dt.Rows[0]["teachername"].ToString();
                }
                if (dt.Rows[0]["Subject"] != null && dt.Rows[0]["Subject"].ToString() != "")
                {
                    model.Subject = dt.Rows[0]["Subject"].ToString();
                }
                if (dt.Rows[0]["College"] != null && dt.Rows[0]["College"].ToString() != "")
                {
                    model.College = dt.Rows[0]["College"].ToString();
                }
                if (dt.Rows[0]["research"] != null && dt.Rows[0]["research"].ToString() != "")
                {
                    model.Research = dt.Rows[0]["research"].ToString();
                }
                if (dt.Rows[0]["brief"] != null && dt.Rows[0]["brief"].ToString() != "")
                {
                    model.Brief = dt.Rows[0]["brief"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 获取所有教师信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTeachers()
        {
            string strSql = "select teacherno ,teachername ,college teachercollege,subject teachersubject,research ,brief  from [teacher] ";
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text);
            return dt;
        }

        public void UpdateTeacher(DataTable dtsource)
        {
            SqlDbHelper.UpdateDataTable(dtsource, "teacher");
        }


        public DataTable selectteacher(string userNo)
        {
            DataTable DB = new DataTable();
            string strSql = "select * from teacher where teacherno=@uid";               //搜索教师信息的sql语句
            SqlParameter p1 = new SqlParameter("uid", userNo);
            SqlParameter[] parameters = { p1 };
            DB = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            return (DB);
        }

        public void Updateteacher(DataTable dtsource, string tablename)
        {
            SqlDbHelper.UpdateDataTable(dtsource,tablename);
        }
    }
}
