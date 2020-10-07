using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace DAL
{
    /// <summary>
    /// 对数据库的备份与恢复
    /// </summary>
    public partial class BackupRestore
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        private static string SqlServerDB = ConfigurationManager.AppSettings["SqlServerDB"];

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="backupPath">备份路径</param>
        public static void BackupDb(string backupPath)
        {
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }
            string strSql = "backup database " + SqlServerDB + " to disk=@backupPath";
            SqlParameter[] parameters = {
                    new SqlParameter("@backupPath", SqlDbType.NVarChar,200)
                    };
            parameters[0].Value = backupPath;
            SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
        }

        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="backupPath">恢复路径</param>
        public static void RestoreDb(string restorePath)
        {
            string strSql = "Alter Database " + SqlServerDB + " Set Offline with Rollback immediate;use master;restore database " + SqlServerDB + " from disk=@restorePath With Replace;Alter Database " + SqlServerDB + " Set OnLine With rollback Immediate";
            SqlParameter[] parameters = {
                    new SqlParameter("@restorePath", SqlDbType.NVarChar,200)  
                    };
            parameters[0].Value = restorePath;
            SqlDbHelper.ExecuteNonQuery(strSql, CommandType.Text, parameters);
        }
    }
}
