using System;
namespace Model
{
    /// <summary>
    /// 学生账号
    /// </summary>
    [Serializable]
    public partial class StudentAccount
    {
        public StudentAccount()
        { 
        }
        #region Model
        private string _stuno;
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
        public string StuNo
        {
            get { return _stuno; }
            set { _stuno = value; }
        }

        #endregion Model
    }
}
