using System;

namespace Model
{
    /// <summary>
    /// 教师账号
    /// </summary>
    [Serializable]
    public partial class TeacherAccount
    {
        public TeacherAccount()
        { }
        #region Model
        private string _teacherno;
        private string _password;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
          get { return _password; }
          set { _password = value; }
        } 
        /// <summary>
        /// 教师号
        /// </summary>
        public string TeacherNo
        {
          get { return _teacherno; }
          set { _teacherno = value; }
        }
        
        #endregion Model
    }
}
