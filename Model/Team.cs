using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 队伍信息
    /// </summary>
    [Serializable]
    public partial class Team
    {
        public Team()
        {}
        #region Model
        private string _teamno;
        private string _teamname;
        private string _grade;
        private string _leaderno;
        private string _leadername;
        private string _stuno1;
        private string _stuname1;
        private string _stuno2;
        private string _stuname2;
        private string _stuno3;
        private string _stuname3;
        private string _teacherno;
        private string _topic;
        private string _main;

        /// <summary>
        /// 队伍号
        /// </summary>
        public string TeamNo
        {
            get { return _teamno; }
            set { _teamno = value; }
        }
        
        /// <summary>
        /// 队伍名
        /// </summary>
        public string TeamName
        {
            get { return _teamname; }
            set { _teamname = value; }
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
        /// 队长学号
        /// </summary>
        public string LeaderNo
        {
            get { return _leaderno; }
            set { _leaderno = value; }
        }
        
        /// <summary>
        /// 队长名字
        /// </summary>
        public string LeaderName
        {
            get { return _leadername; }
            set { _leadername = value; }
        }
        
        
        /// <summary>
        /// 学生1学号
        /// </summary>
        public string Stuno1
        {
            get { return _stuno1; }
            set { _stuno1 = value; }
        }
        
        /// <summary>
        /// 学生1姓名
        /// </summary>
        public string StuName1
        {
            get { return _stuname1; }
            set { _stuname1 = value; }
        }
        
        /// <summary>
        /// 学生2学号
        /// </summary>
        public string StuNo2
        {
            get { return _stuno2; }
            set { _stuno2 = value; }
        }
        
        /// <summary>
        /// 学生2姓名
        /// </summary>
        public string StuName2
        {
            get { return _stuname2; }
            set { _stuname2 = value; }
        }
        
        /// <summary>
        /// 学生3学号
        /// </summary>
        public string StuNo3
        {
            get { return _stuno3; }
            set { _stuno3 = value; }
        }
        
        /// <summary>
        /// 学生3姓名
        /// </summary>
        public string StuName3
        {
            get { return _stuname3; }
            set { _stuname3 = value; }
        }
        
        /// <summary>
        /// 最终匹配的老师
        /// </summary>
        public string TeacherNo
        {
            get { return _teacherno; }
            set { _teacherno = value; }
        }
        
        /// <summary>
        /// 课题名字
        /// </summary>
        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }

        /// <summary>
        /// 课题详细内容
        /// </summary>
        public string Main
        {
            get { return _main; }
            set { _main = value; }
        }

        #endregion Model
    }
}
