using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 队伍志愿
    /// </summary>
    [Serializable]
    public partial class Teamhope
    {
        public Teamhope()
        {  }

        public  bool Add(Model.Teamhope model)
        {
            string strSql = "insert into [teamhope] values(@TeamNo,@First,@Second,@Third,@TeacherNo,@Time)";     
            SqlParameter[] parameters = {
				new SqlParameter("@TeamNo", SqlDbType.VarChar,50),
                new SqlParameter("@First", SqlDbType.VarChar,50),
                new SqlParameter("@Second", SqlDbType.VarChar,50),
                new SqlParameter("@Third", SqlDbType.VarChar,50),
                new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Time", SqlDbType.Int),};
            parameters[0].Value = model.TeamNo;
            parameters[1].Value = model.First;
            parameters[2].Value = model.Second;
            parameters[3].Value = model.Third;
            parameters[4].Value = model.TeacherNo;
            parameters[5].Value = model.Time;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Delete(string teamNo)
        {
            string strSql = "delete from [teamhope] where teamno = @TeamNo";
            SqlParameter[] parameters = {
				new SqlParameter("@teamNo", SqlDbType.VarChar,50),};
            parameters[0].Value = teamNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Update(Model.Teamhope model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [teamhope] set ");
            strSql.Append("teamno=@teamNo,");
            strSql.Append("first=@First,");
            strSql.Append("second=@Second,");
            strSql.Append("third=@Third,");
            strSql.Append("teacherNo=@TeacherNo,");
            strSql.Append("time=@Time");
            strSql.Append(" where teamno=@teamNo ");
            SqlParameter[] parameters = {
				new SqlParameter("@TeamNo", SqlDbType.VarChar,50),
                new SqlParameter("@First", SqlDbType.VarChar,50),
                new SqlParameter("@Second", SqlDbType.VarChar,50),
                new SqlParameter("@Third", SqlDbType.VarChar,50),
                new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Time", SqlDbType.Int),};
            parameters[0].Value = model.TeamNo;
            parameters[1].Value = model.First;
            parameters[2].Value = model.Second;
            parameters[3].Value = model.Third;
            parameters[4].Value = model.TeacherNo;
            parameters[5].Value = model.Time;
            int n = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  Model.Teamhope Get(string teamNo)
        {
            string strSql = "select top 1 first,second,third,teacherno,time from [teamhope] where teamno=@TeamNo";
            SqlParameter[] parameters = {
				new SqlParameter("@TeamNo", SqlDbType.VarChar,50),};
            parameters[0].Value = teamNo;
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                Model.Teamhope model = new Model.Teamhope();
                model.TeamNo = teamNo;
                if (dt.Rows[0]["teamNo"] != null && dt.Rows[0]["teamNo"].ToString() != "")
                {
                    model.TeamNo = dt.Rows[0]["StuName"].ToString();
                }
                if (dt.Rows[0]["first"] != null && dt.Rows[0]["first"].ToString() != "")
                {
                    model.First = dt.Rows[0]["Grade"].ToString();
                }
                if (dt.Rows[0]["second"] != null && dt.Rows[0]["second"].ToString() != "")
                {
                    model.Second = dt.Rows[0]["Subject"].ToString();
                }
                if (dt.Rows[0]["third"] != null && dt.Rows[0]["third"].ToString() != "")
                {
                    model.Third = dt.Rows[0]["College"].ToString();
                }
                if (dt.Rows[0]["teacherno"] != null && dt.Rows[0]["teacherno"].ToString() != "")
                {
                    model.TeacherNo = dt.Rows[0]["Phone"].ToString();
                }
                if (dt.Rows[0]["time"] != null && dt.Rows[0]["time"].ToString() != "")
                {
                    model.Time = Convert.ToInt32(dt.Rows[0]["Living"]);
                }
                return model;
            }
            else
            {
                return null;
            }

        }


        #region GetNotTeamDisb
        public DataTable GetNotTeamDisb(string grade,string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT teamno FROM teamhope where teacherno is null ");
            sb.Append(" and teamno in (select teamno from [team] where [team].grade = @grade ) ");
            sb.Append(" and teamno in (select teamno from student join team on team.LeaderNo = student.StuNo where subject = @subject)");
            SqlParameter[] parameters = { new SqlParameter("@grade", SqlDbType.VarChar, 50), new SqlParameter("@subject", SqlDbType.VarChar, 50) };
            parameters[0].Value = grade;
            parameters[1].Value = subject;
            return SqlDbHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, parameters);
        }

        public DataTable GetNotTeamDisb(string grade,int i)
        {
            string sql = "SELECT teamno FROM teamhope where teacherno is null and teamno in (select teamno from [team] where [team].grade = @grade );";
            SqlParameter[] parameters = { new SqlParameter("@grade", SqlDbType.VarChar, 50)};
            parameters[0].Value = grade;
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        public DataTable GetNotTeamDisb(string subject,char i)
        {
            string sql = "SELECT teamno FROM teamhope where teacherno is null and teamno in (select teamno from student join team on team.LeaderNo = student.StuNo where subject = @subject);";
            SqlParameter[] parameters = { new SqlParameter("@subject", SqlDbType.VarChar, 50) };
            parameters[0].Value = subject;
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        public DataTable GetNotTeamDisb()
        {
            string sql = "SELECT teamno FROM teamhope where teacherno is null;";
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        #endregion

        #region GetNotTeamHopeDisb
        public DataTable GetNotTeamHopeDisb(string grade, string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT teamno,first,second,third FROM teamhope where teacherno is null ");
            sb.Append(" and teamno in (select teamno from [team] where [team].grade = @grade ) ");
            sb.Append(" and teamno in (select teamno from student join team on team.LeaderNo = student.StuNo where subject = @subject)");
            SqlParameter[] parameters = { new SqlParameter("@grade", SqlDbType.VarChar, 50), new SqlParameter("@subject", SqlDbType.VarChar, 50) };
            parameters[0].Value = grade;
            parameters[1].Value = subject;
            return SqlDbHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, parameters);
        }

        public DataTable GetNotTeamHopeDisb(string grade, int i)
        {
            string sql = "SELECT teamno,first,second,third FROM teamhope where teacherno is null and teamno in (select teamno from [team] where [team].grade = @grade );";
            SqlParameter[] parameters = { new SqlParameter("@grade", SqlDbType.VarChar, 50) };
            parameters[0].Value = grade;
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        public DataTable GetNotTeamHopeDisb(string subject, char i)
        {
            string sql = "SELECT teamno,first,second,third FROM teamhope where teacherno is null and teamno in (select teamno from student join team on team.LeaderNo = student.StuNo where subject = @subject);";
            SqlParameter[] parameters = { new SqlParameter("@subject", SqlDbType.VarChar, 50) };
            parameters[0].Value = subject;
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        public DataTable GetNotTeamHopeDisb()
        {
            string sql = "SELECT teamno,first,second,third FROM teamhope where teacherno is null;";
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        #endregion
    }
}
