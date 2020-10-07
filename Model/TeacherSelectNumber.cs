using System;
namespace Model
{
    /// <summary>
    /// 教师队伍数量
    /// </summary>
    [Serializable]
    public partial class TeacherSelectNumber
    {
        public TeacherSelectNumber()
        { }
        #region Model
        private string _teacherno;
        private int _sum;
        private int _rest;
        
        /// <summary>
        /// 剩余管理队伍数量
        /// </summary>
        public int Rest
        {
            get { return _rest; }
            set { _rest = value; }
        }
        /// <summary>
        /// 最多管理队伍数量
        /// </summary>
        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
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
