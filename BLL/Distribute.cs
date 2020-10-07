using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class Distribute
    {
        /// <summary>
        /// 获得未分配的所有队伍
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public DataTable GetNotTeamDisb(string grade, string subject)
        {
            if(grade.Trim() == "" && subject.Trim() == "")
                return new DAL.Teamhope().GetNotTeamDisb();
            else if(grade.Trim() == "")
                return new DAL.Teamhope().GetNotTeamDisb(subject,' ');
            else if(subject.Trim() == "")
                return new DAL.Teamhope().GetNotTeamDisb(grade, 1);
            else
                return new DAL.Teamhope().GetNotTeamDisb(grade, subject);
        }

        /// <summary>
        /// 获得未分配完的所有教师
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public DataTable GetTeacherSelectRest(string subject)
        {
            if (subject == null || subject.Trim() == "")
                return new DAL.TeacherSelectNumber().GetTeacherSelectRest();
            else
                return new DAL.TeacherSelectNumber().GetTeacherSelectRest(subject);
        }

        /// <summary>
        /// 获得未分配的所有队伍，以及对应的三个志愿
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public DataTable GetNotTeamHopeDisb(string grade, string subject)
        {
            if (grade.Trim() == "" && subject.Trim() == "")
                return new DAL.Teamhope().GetNotTeamHopeDisb();
            else if (grade.Trim() == "")
                return new DAL.Teamhope().GetNotTeamHopeDisb(subject, ' ');
            else if (subject.Trim() == "")
                return new DAL.Teamhope().GetNotTeamHopeDisb(grade, 1);
            else
                return new DAL.Teamhope().GetNotTeamHopeDisb(grade, subject);
        }

        /// <summary>
        /// 根据匈牙利分配法，对队伍教师进行分配
        /// </summary>
        /// <param name="grade">输入年级</param>
        /// <param name="subject">输入专业</param>
        /// <param name="dtDisb">输出队伍分配表</param>
        /// <param name="dtFailTeam">输出队伍分配失败表</param>
        /// <param name="dtRestTeacher">输出教师剩余管理位表</param>
        public void distribute(string grade, string subject,DataTable dtDisb, DataTable dtFailTeam, DataTable dtRestTeacher)
        {
            ///********
            //    查询队伍配对表和教师选择表。
            //*********/
            DataTable dtTeam = this.GetNotTeamHopeDisb(grade, subject);
            DataTable dtTeacher = this.GetTeacherSelectRest(subject);
            if (dtTeam.Rows.Count == 0 || dtTeacher.Rows.Count == 0)
                return;

            ///********
            //    获取队伍点集team和教师点集teacher，以及队伍的志愿集volunte；
            //    并生成队伍与教师的邻接矩阵graph。
            //*********/
            List<string> team = new List<string>();
            List<string> teacher = new List<string>();
            List<string[]> volunte = new List<string[]>();
            int[][] graph = new int[dtTeam.Rows.Count][];
            for (int i = 0; i < dtTeam.Rows.Count; i++)
            {
                team.Add(dtTeam.Rows[i]["teamno"].ToString());
                volunte.Add(new string[] { dtTeam.Rows[i]["first"].ToString(), dtTeam.Rows[i]["second"].ToString(), dtTeam.Rows[i]["third"].ToString() });
            }
            for (int i = 0; i < dtTeacher.Rows.Count; i++)
            {
                for (int k = 0; k < Convert.ToInt16(dtTeacher.Rows[i]["rest"]); k++)
                {
                    teacher.Add(dtTeacher.Rows[i]["teacherno"].ToString());
                }
            }
            for (int i = 0; i < dtTeam.Rows.Count; i++)
            {
                graph[i] = Enumerable.Repeat(1, teacher.Count).ToArray();
            }
            for (int i = 0; i < teacher.Count; i++)     //这里用的是teacher.Count而不是dtTeam.Rows.Count
            {
                for (int j = 0; j < dtTeam.Rows.Count; j++)     //查看老师分别在每个学生志愿表中是否存在。若存在，就将老师与该学生设置为不可匹配
                {
                    if (Array.IndexOf(volunte[j], teacher[i]) >= 0)
                        graph[j][i] = 0;
                }
            }

            ///********
            //    对邻接矩阵进行匈牙利匹配
            //*********/
            Hungary.hungary(graph);

            ///********
            //    输出结果
            //*********/

            DataRow dr;
            for (int i = 0; i < Hungary.linker.Length; i++)
            {
                //linker = -1，即v点集的某一点没有匹配
                if (Hungary.linker[i] >= 0)
                {
                    dr = dtDisb.NewRow();
                    dr["team"] = team[Hungary.linker[i]];
                    dr["teacher"] = teacher[i];
                    dtDisb.Rows.Add(dr);
                }
            }
            for (int i = 0; i < Hungary.restU.Length; i++)
            {
                dr = dtFailTeam.NewRow();
                dr["failteam"] = team[Hungary.restU[i]];
                dtFailTeam.Rows.Add(dr);
            }
            for (int i = 0; i < Hungary.restV.Length; i++)
            {
                dr = dtRestTeacher.NewRow();
                dr["restteacher"] = teacher[Hungary.restV[i]];
                dtRestTeacher.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 将分配结果提交到数据库中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool UpdateSelectResult(DataTable dt,out string message)
        {
            message = "";
            //将数据表更新到teacherselect
            if(new DAL.Teacherselect().AddDataTable("teacherselect",dt))
            {
                message = "提交成功";
                return true;
            }
            //更新到teamhope
            //更新到team的老师
            //插入“自动配对表”，同时更新TeacherSelect的rest减1
            message = "提交失败";
            return false;
        }
    }
}
