using System;
namespace Model
{
    /// <summary>
    /// 学生信息
    /// </summary>
    [Serializable]
    public partial class Student
    {
        public Student()
        { }
        #region Model
        private string _stuno;
        private string _stuname;
        private string _grade;       
	    private string _subject;
        private string _college;
        private string _phone;
        private string _living;
        /// <summary>
        /// 学号
        /// </summary>
        public string StuNo
        {
          get { return _stuno; }
          set { _stuno = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StuName
        {
            get { return _stuname; }
            set { _stuname = value; }
        }
        /// <summary>
        /// 年级
        /// </summary>
        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string College
        {
            get { return _college; }
            set { _college = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// 居住地
        /// </summary>
        public string Living
        {
          get { return _living; }
          set { _living = value; }
        }
        #endregion Model
    }
}
