using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    /// <summary>
    /// 数据访问类：管理员账号
    /// </summary>
    [Serializable]
    public partial class AdminAccount
    {
        public AdminAccount()
        {
        }
        public bool Add(Model.AdminAccount model)
        {
            //if(model.AdminNo)
            //string strSql = "insert into [admin_account] values(@AdminNo,@Password)";
            //SqlParameter[] parameters = {
            //    new SqlParameter("@AdminNo", SqlDbType.VarChar,50),
            //    new SqlParameter("@Password", SqlDbType.VarChar,50),};
            //parameters[0].Value = model.AdminNo;
            //parameters[1].Value = model.Password;
            //int n = SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
            //if (n == 1)
                return true;
            //else
            //    return false;
        }
        public bool Login(Model.AdminAccount model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select count(1) from [admin_account]");
            //strSql.Append(" where adminno=@AdminNo and password=@Password");
            //SqlParameter[] parameters = {
            //    new SqlParameter("@AdminNo", SqlDbType.VarChar,50),
            //    new SqlParameter("@Password", SqlDbType.VarChar,50),};
            //parameters[0].Value = model.AdminNo;
            //parameters[1].Value = model.Password;
            //int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters));
            //if (n == 1)
                return true;
            //else
            //    return false;
        }
        public bool Login(string userNo, string userPassword,out string message)
        {
            if (userNo.Trim() == "" || userPassword == "")
            {
                message = "用户名或密码不能为空";
                return false;
            }
            DAL.AdminAccount model = new DAL.AdminAccount();
            if (!model.Login(userNo, userPassword))
            {
                message = "用户名或密码错误";
                return false;
            }
            message = "";
            return true;
        }
        public bool Update(Model.AdminAccount model)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update [admin_account] set ");
            //strSql.Append("password=@Password");
            //strSql.Append(" where adminno=@AdminNo ");
            //SqlParameter[] parameters = {
            //    new SqlParameter("@Password", SqlDbType.VarChar,50),
            //    new SqlParameter("@AdminNo", SqlDbType.VarChar,50)};
            //parameters[0].Value = model.Password;
            //parameters[1].Value = model.AdminNo;
            //int rows = SqlDbHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            //if (rows == 1)
                return true;
            //else
            //    return false;
        }
    }
}
