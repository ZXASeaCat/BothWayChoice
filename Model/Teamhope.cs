using System;

namespace Model
{
    /// <summary>
    /// 队伍志愿
    /// </summary>
    [Serializable]
    public partial class Teamhope
    {
        public Teamhope()
        {}
        private string _teamno;
        private string _first;
        private string _second;
        private string _third;
        private string _teacherno;
        private int _time;

        /// <summary>
        /// 第一志愿
        /// </summary>
        public string First
        {
            get { return _first; }
            set { _first = value; }
        }

        /// <summary>
        /// 第二志愿
        /// </summary>
        public string Second
        {
            get { return _second; }
            set { _second = value; }
        }

        /// <summary>
        /// 第三志愿
        /// </summary>
        public string Third
        {
            get { return _third; }
            set { _third = value; }
        }

        /// <summary>
        /// 志愿可修改次数
        /// </summary>
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// 队伍号
        /// </summary>
        public string TeamNo
        {
            get { return _teamno; }
            set { _teamno = value; }
        }

        /// <summary>
        /// 最终匹配教师号
        /// </summary>
        public string TeacherNo
        {
            get { return _teacherno; }
            set { _teacherno = value; }
        }
    }
}
