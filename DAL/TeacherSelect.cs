using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public partial class Teacherselect
    {
        public Teacherselect()
        { }

        public bool AddDataTable(string tableName,DataTable dt)
        {
            return SqlDbHelper.SqlBulkCopyInsert(tableName, dt);
        }

        public void selectteam(string teacherID, string teamID)
        {
            string ssql = "select count(1) from teacherselect where teacherno=@teacheruid and teamno=@teamuid";//查询是否有重复选择
            string sql = "insert into teacherselect(teacherno,teamno) values(@teacheruid,@teamuid)";    //将选择的队伍放入教师选择表中
            SqlParameter p1 = new SqlParameter("teacheruid", teacherID);
            SqlParameter p2 = new SqlParameter("teamuid", teamID);
            SqlParameter[] sps = { p1, p2 };
            int i=Convert.ToInt32(SqlDbHelper.ExecuteScalar(ssql, CommandType.Text, sps));
            if (i!=1)
            {
                SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, sps);
            }
        }
    }
}
