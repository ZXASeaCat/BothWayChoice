using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class Team
    {
        public Team()
        { }


        public DataTable getAllTeamSelects(string subject, Model.Team team, string teacherName)
        {
            team.StuName2 = team.StuName3 = team.LeaderName;
            DataTable dt;
            if(teacherName ==null)
                dt = new DAL.Team().getAllTeamSelects(subject, team);
            else
                dt = new DAL.Team().getAllTeamSelects(subject, team, teacherName);
            return dt;
        }

        public DataTable getAllTeamSelectsOutTeachers(string subject, Model.Team team)
        {
            team.StuName2 = team.StuName3 = team.LeaderName;
            return new DAL.Team().getAllTeamSelectsOutTeachers(subject, team);
        }
    }
}
