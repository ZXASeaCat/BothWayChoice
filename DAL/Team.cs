using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{

    public partial class Team
    {
        public Team()
        { }

        public DataTable getAllTeamSelects()
        {

            DataTable dt = new DataTable();
            string strSql = "select teamno 队伍编号,teamname 队伍名称,grade 年级,LeaderName 队长,stuname2 成员2,stuname3 成员3, teachername 分配教师, Topic 课题名 from [team] join [teacher] on [team].teacherno = [teacher].teacherno";  //查询对应年级的队伍
            dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 查看已匹配的全部队伍结果
        /// </summary>
        /// <param name="subject">队长的专业</param>
        /// <param name="team"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public DataTable getAllTeamSelects(string subject,Model.Team team , string teacherName)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select teamno 队伍编号,teamname 队伍名称,team.grade 年级,student.Subject 专业,leadername 队长,stuname2 成员2,stuname3 成员3, teachername 分配教师, topic 课题名");
            sb.Append("  from [team] join [student] on [team].LeaderName = [student].StuName join [teacher] on [team].teacherno = [teacher].teacherno ");
            sb.Append(" where 1=1 ");
            if(team.TeamNo !="")
                sb.Append(" and teamno = @teamno");
            if(team.Grade != "")
                sb.Append(" and [team].grade = @grade");
            if(team.LeaderName != "")
                sb.Append(" and (leadername = @leadername or stuname2 = @stuname2 or stuname3 = @stuname3)");
            if (teacherName != "" )
                sb.Append(" and [teacher].teachername = @teachername");
            if (subject != "")
                sb.Append(" and [student].subject = @subject");
            SqlParameter[] parameters = {
				new SqlParameter("@teamno", SqlDbType.VarChar,50),
                new SqlParameter("@grade", SqlDbType.VarChar,50),
                new SqlParameter("@leadername", SqlDbType.VarChar,50),
                new SqlParameter("@stuname2", SqlDbType.VarChar,50),
                new SqlParameter("@stuname3", SqlDbType.VarChar,50),
                new SqlParameter("@teachername", SqlDbType.VarChar,50),
                new SqlParameter("@subject", SqlDbType.VarChar,50)};
            parameters[0].Value = team.TeamNo;
            parameters[1].Value = team.Grade;
            parameters[2].Value = team.LeaderName;
            parameters[3].Value = team.StuName2;
            parameters[4].Value = team.StuName3;
            parameters[5].Value = teacherName;
            parameters[6].Value = subject;
            dt = SqlDbHelper.ExecuteDataTable(sb.ToString(), CommandType.Text,parameters);
            return dt;
        }

        /// <summary>
        /// 查看未匹配的全部队伍结果
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public DataTable getAllTeamSelects(string subject, Model.Team team)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select teamno 队伍编号,teamname 队伍名称,team.grade 年级,student.Subject 专业,leadername 队长,stuname2 成员2,stuname3 成员3, teacherno 分配教师, topic 课题名");
            sb.Append("  from [team] join [student] on [team].LeaderName = [student].StuName");
            sb.Append(" where 1=1 ");
            if (team.TeamNo != "")
                sb.Append(" and teamno = @teamno");
            if (team.Grade != "")
                sb.Append(" and [team].grade = @grade");
            if (team.LeaderName != "")
                sb.Append(" and (leadername = @leadername or stuname2 = @stuname2 or stuname3 = @stuname3)");
            if (subject != "")
                sb.Append(" and [student].subject = @subject");
            sb.Append(" and teacherno is null");
            SqlParameter[] parameters = {
				new SqlParameter("@teamno", SqlDbType.VarChar,50),
                new SqlParameter("@grade", SqlDbType.VarChar,50),
                new SqlParameter("@leadername", SqlDbType.VarChar,50),
                new SqlParameter("@stuname2", SqlDbType.VarChar,50),
                new SqlParameter("@stuname3", SqlDbType.VarChar,50),
                new SqlParameter("@subject", SqlDbType.VarChar,50)};
            parameters[0].Value = team.TeamNo;
            parameters[1].Value = team.Grade;
            parameters[2].Value = team.LeaderName;
            parameters[3].Value = team.StuName2;
            parameters[4].Value = team.StuName3;
            parameters[5].Value = subject;
            dt = SqlDbHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, parameters);
            return dt;
        }

        /// <summary>
        /// 查看全部队伍
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public DataTable getAllTeamSelectsOutTeachers(string subject, Model.Team team)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select teamno 队伍编号,teamname 队伍名称,team.grade 年级,student.Subject 专业,leadername 队长,stuname2 成员2,stuname3 成员3, teacherno 分配教师, topic 课题名");
            sb.Append("  from [team] join [student] on [team].LeaderName = [student].StuName");
            sb.Append(" where 1=1 ");
            if (team.TeamNo != "")
                sb.Append(" and teamno = @teamno");
            if (team.Grade != "")
                sb.Append(" and [team].grade = @grade");
            if (team.LeaderName != "")
                sb.Append(" and (leadername = @leadername or stuname2 = @stuname2 or stuname3 = @stuname3)");
            if (subject != "")
                sb.Append(" and [student].subject = @subject");
            SqlParameter[] parameters = {
				new SqlParameter("@teamno", SqlDbType.VarChar,50),
                new SqlParameter("@grade", SqlDbType.VarChar,50),
                new SqlParameter("@leadername", SqlDbType.VarChar,50),
                new SqlParameter("@stuname2", SqlDbType.VarChar,50),
                new SqlParameter("@stuname3", SqlDbType.VarChar,50),
                new SqlParameter("@subject", SqlDbType.VarChar,50)};
            parameters[0].Value = team.TeamNo;
            parameters[1].Value = team.Grade;
            parameters[2].Value = team.LeaderName;
            parameters[3].Value = team.StuName2;
            parameters[4].Value = team.StuName3;
            parameters[5].Value = subject;
            dt = SqlDbHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, parameters);
            return dt;
        }


        
        public DataTable selectteamgrade(string sgrade)
        {
            DataTable DB = new DataTable();
            string strSql = "select teamno 队伍编号,teamname 队伍名,grade 年级,LeaderName 队长名,Topic 课题名  from team where grade=@sgrade";  //查询对应年级的队伍
            SqlParameter p1 = new SqlParameter("sgrade", sgrade);
            SqlParameter[] parameters = { p1 };
            DB = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            return (DB);
        }
        public DataTable selectteamall()
        {
            DataTable DB = new DataTable();
            string strSql = "select teamno 队伍编号,teamname 队伍名,grade 年级,LeaderName 队长名,Topic 课题名  from team";      //查询全部队伍
            DB = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text);
            return (DB);
        }
        public DataTable selectteamselect(string userNo)
        {
            DataTable DB = new DataTable();
            string strSql = "select teamno 队伍编号,teamname 队伍名,grade 年级,LeaderName 队长名,Topic 课题名  from team where teamno in(select teamno from teacherselect where teacherno=@uid)";  //查询在老师选择表中本老师选择的队伍的信息
            SqlParameter p = new SqlParameter("uid", userNo);
            SqlParameter[] parameters = { p };
            DB = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            return (DB);
        }
        public DataTable selectteamok(string userNo)
        {
            DataTable DB = new DataTable();
            string strSql = "select teamno 队伍编号,teamname 队伍名,grade 年级, LeaderName 队长名,Topic 课题名  from team where teacherno=@uid";  //查询志愿情况表中成功配对到本老师的队伍信息
            SqlParameter p = new SqlParameter("uid", userNo);
            SqlParameter[] parameters = { p };
            DB = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            return (DB);
        }
        public DataTable selectteamno(string teamno)
        {
            DataTable DB = new DataTable();
            string strSql = "select * from team where teamno=@tuid";                      //查询队伍号对应的队伍信息
            SqlParameter p1 = new SqlParameter("tuid", teamno);
            SqlParameter[] parameters = { p1 };
            DB = SqlDbHelper.ExecuteDataTable(strSql.ToString(), CommandType.Text, parameters);
            return (DB);
        }
    }
}
