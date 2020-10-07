using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 对SQL Server数据库操作的通用类
    /// </summary>
    public class SqlDbHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }

        #region 执行一个查询,并返回查询结果
        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);//填充DataTable
                    command.Parameters.Clear();
                }
            }
            return data;
        }
        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns>返回查询结果集</returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }
        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }


        #endregion

        #region 将 CommandText 发送到 Connection 并生成一个 SqlDataReader

        /// <summary>
        /// 将 CommandText 发送到 Connection 并生成一个 SqlDataReader。
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(commandText, connection);
			command.CommandType = commandType;
            //如果同时传入了参数，则添加这些参数
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            connection.Open();
            //CommandBehavior.CloseConnection参数指示关闭Reader对象时关闭与其关联的Connection对象
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 将 CommandText 发送到 Connection 并生成一个 SqlDataReader。
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }
        /// <summary>
        /// 将 CommandText 发送到 Connection 并生成一个 SqlDataReader。
        /// </summary>
        /// <param name="commandText">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, CommandType.Text, null);
        }

        #endregion

        #region 从数据库中检索单个值（例如一个聚合值）

        /// <summary>
        /// 从数据库中检索单个值（例如一个聚合值）。
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    result = command.ExecuteScalar();
                    command.Parameters.Clear();
                }
            }
            return result;//返回查询结果的第一行第一列，忽略其它行和列
        }
        /// <summary>
        /// 从数据库中检索单个值（例如一个聚合值）。
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }
        /// <summary>
        /// 从数据库中检索单个值（例如一个聚合值）。
        /// </summary>
        /// <param name="commandText">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }

        #endregion

        #region  对数据库执行增删改操作

        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns>返回执行操作受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    count = command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
            return count;//返回执行增删改操作之后，数据库中受影响的行数
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="commandText">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="commandText">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null);
        }
        #endregion

        #region  更新数据表
        /// <summary>
        /// 更新数据表
        /// </summary>
        /// <param name="dtsource">数据源</param>
        /// <param name="tablename">数据表名称</param>
        public static void UpdateDataTable(DataTable dtsource, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string s;
                for (int i = 0; i < dtsource.Rows.Count; i++)
                {
                    DataColumnCollection d= dtsource.Columns;
                    s = dtsource.Rows[i]["stuno"].ToString();
                }
                string sqlCmd = string.Format("select * from [{0}]", tablename);
                SqlCommand dbCommand = new SqlCommand(sqlCmd, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                connection.Open();
                adapter.Update(dtsource);
            }
        }
        #endregion

        #region 批量插入
        /// <summary>
        /// 将DataTable数据批量插入某个数据表
        /// </summary>
        /// <param name="strTableName">数据库中对应的表名</param>
        /// <param name="dtData">需要导入的数据源</param>
        public static bool SqlBulkCopyInsert(string strTableName, DataTable dtData)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(ConnectionString))//引用SqlBulkCopy  
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;//数据库中对应的表名  
                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;//有几行数据  
                    sqlRevdBulkCopy.WriteToServer(dtData);//数据导入数据库  
                    sqlRevdBulkCopy.Close();//关闭连接  
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}