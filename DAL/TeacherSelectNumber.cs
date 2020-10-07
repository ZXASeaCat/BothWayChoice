using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// TeacherSelectNumber:教师队伍数量
    /// </summary>
    [Serializable]
    public partial class TeacherSelectNumber
    {
        public TeacherSelectNumber()
        { }


        public  bool Add(Model.TeacherSelectNumber model)
        {
            string strSql = "insert into [teacherselectnumber] values(@TeacherNo,@Sum,@Rest)";
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Sum", SqlDbType.Int),
                new SqlParameter("@Rest", SqlDbType.Int),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.Sum;
            parameters[2].Value = model.Rest;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public  bool Delete(string teacherNo)
        {
            string strSql = "delete from [teacherselectnumber] where teacherNo = @TeacherNo";
            SqlParameter[] parameters = {
				new SqlParameter("@teacherNo", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public bool Update(Model.TeacherSelectNumber model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [teacherselectnumber] set ");
            strSql.Append("sum=@Sum,");
            strSql.Append("rest=@Rest");
            strSql.Append(" where teacherno=@teacherNo ");
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),
                new SqlParameter("@Sum", SqlDbType.Int),
                new SqlParameter("@Rest", SqlDbType.Int),};
            parameters[0].Value = model.TeacherNo;
            parameters[1].Value = model.Sum;
            parameters[2].Value = model.Rest;
            int n = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (n == 1)
                return true;
            else
                return false;
        }
        public Model.TeacherSelectNumber Get(string teacherNo)
        {
            string strSql = "select top 1 sum,rest from [teacherselectnumber] where teacherno=@TeacherNo";
            SqlParameter[] parameters = {
				new SqlParameter("@TeacherNo", SqlDbType.VarChar,50),};
            parameters[0].Value = teacherNo;
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                Model.TeacherSelectNumber model = new Model.TeacherSelectNumber();
                model.TeacherNo = teacherNo;
                if (dt.Rows[0]["sum"] != null && dt.Rows[0]["sum"].ToString() != "")
                {
                    model.Sum = Convert.ToInt32(dt.Rows[0]["sum"].ToString());
                }
                if (dt.Rows[0]["rest"] != null && dt.Rows[0]["rest"].ToString() != "")
                {
                    model.Rest = Convert.ToInt32(dt.Rows[0]["rest"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }

        }

        public DataTable GetTeacherSelectRest(string subject)
        {
            string sql = "SELECT teacherselectnumber.teacherno,rest FROM teacherselectnumber join teacher on teacherselectnumber.TeacherNo = teacher.TeacherNo where rest != '0' and [teacher].subject = @subject;";
            SqlParameter[] parameters = { new SqlParameter("@subject", SqlDbType.VarChar, 50) };
            parameters[0].Value = subject;
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        public DataTable GetTeacherSelectRest()
        {
            string sql = "SELECT teacherno,rest FROM teacherselectnumber where rest != '0';";
            return SqlDbHelper.ExecuteDataTable(sql, CommandType.Text);
        }
    }
}
