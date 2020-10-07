using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class Teacher
    {
        public Teacher()
        { }

        public bool Add(Model.Teacher teacher,string password, out string message)
        {
            message = "";
            if (teacher.TeacherNo.Trim() == "")
            {
                message = "学号不可为空白";
                return false;
            }
            if (teacher.TeacherName.Trim() == "")
            {
                message = "姓名不可为空白";
                return false;
            }
            if (teacher.Subject.Trim() == "")
            {
                message = "专业不可为空白";
                return false;
            }
            if (teacher.College.Trim() == "")
            {
                message = "学院不可为空白";
                return false;
            }
            if (teacher.Research.Trim() == "")
            {
                message = "研究方向不可为空白";
                return false;
            }
            if (teacher.Brief.Trim() == "")
            {
                message = "详细情况不可为空白";
                return false;
            }
            if (password.Trim() == "")
            {
                message = "默认密码不可空白";
                return false;
            }
            DAL.Teacher model = new DAL.Teacher();
            if (model.CheckExist(teacher.TeacherNo.Trim()))
            {
                message = "该导师已被录入！！！";
                return false;
            }
            message = "导入成功";
            model.Add(teacher);
            Model.TeacherAccount account = new Model.TeacherAccount();
            account.TeacherNo = teacher.TeacherNo;
            account.Password = Encode.GenerateMD5(password);
            return new DAL.TeacherAccount().Add(account);
        }

        public DataTable GetAllTeachers()
        {
            return new DAL.Teacher().GetAllTeachers();
        }

        public void UpdateTeacher(DataTable dtsource)
        {
            new DAL.Teacher().UpdateTeacher(dtsource);
        }

        public string Delete(string teacherNo)
        {
            //由于外键因素，必须先删掉对应的账户，才能删除个人信息
            //try 
            //{ 
            //    new DAL.TeacherAccount().Delete(teacherNo); 
            //}
            //catch 
            //{
            //    return "该教师对应的账号密码未能删除";
            //}
            try
            {
                new DAL.Teacher().Delete(teacherNo);
            }
            catch 
            {
                return "该教师信息未能删除";
            }
            return  "删除成功";
        }
    }
}
