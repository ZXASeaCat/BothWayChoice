using System;
namespace Model
{
    /// <summary>
    /// 教师选择的队伍
    /// </summary>
    [Serializable]
    public partial class TeacherSelect
    {
        public TeacherSelect()
        { }
        #region Model
        private string _teacherno;
        private string _stuno;

        /// <summary>
        /// 学生学号
        /// </summary>
        public string StuNo
        {
            get { return _stuno; }
            set { _stuno = value; }
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
