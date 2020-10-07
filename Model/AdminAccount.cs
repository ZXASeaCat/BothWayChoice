using System;

namespace Model
{
    /// <summary>
    /// 管理员账号
    /// </summary>
    [Serializable]
    public partial class AdminAccount
    {
        public AdminAccount()
        {
        }
        #region Model
        private string _adminno;
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
        /// 学号
        /// </summary>
        public string AdminNo
        {
            get { return _adminno; }
            set { _adminno = value; }
        }

        #endregion Model
    }
}
