using System;

namespace Model
{
    /// <summary>
    /// 教师信息
    /// </summary>
    [Serializable]
    public partial class Teacher
    {
        public Teacher()
        { }
        private string _teacherno;
        private string _teachername;
        private string _subject;
        private string _college;
        private string _research;
        private string _brief;

        /// <summary>
        /// 教师号
        /// </summary>
        public string TeacherNo
        {
            get { return _teacherno; }
            set { _teacherno = value; }
        }

        /// <summary>
        /// 教师名字
        /// </summary>
        public string TeacherName
        {
            get { return _teachername; }
            set { _teachername = value; }
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
        /// 学院
        /// </summary>
        public string College
        {
            get { return _college; }
            set { _college = value; }
        }
        /// <summary>
        /// 研究方向
        /// </summary>
        public string Research
        {
            get { return _research; }
            set { _research = value; }
        }

        /// <summary>
        /// 教师详细内容
        /// </summary>
        public string Brief
        {
            get { return _brief; }
            set { _brief = value; }
        }
    }
}
