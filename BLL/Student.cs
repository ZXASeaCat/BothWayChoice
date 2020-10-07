using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
        
        
namespace BLL
{
    public class Student
    {
        public bool Add(Model.Student student,string password,out string message)
        {
            message = "";
            if (student.StuNo.Trim() == "")
            {
                message = "学号不可为空白";
                return false;
            }
            if(student.StuName.Trim() =="")
            {
                message = "姓名不可为空白";
                return false;
            }
            if (!Check.CheckYear(student.Grade.Trim()))
            {
                message = "请选择正确的年级";
                return false;
            }
            if(student.Subject.Trim() =="")
            {
                message = "专业不可为空白";
                return false;
            }
            if(student.College.Trim() =="")
            {
                message = "学院不可为空白";
                return false;
            }
            if(!Check.CheckMobilePhone(student.Phone))
            {
                message = "请选择正确的手机号";
                return false;
            }
            if(student.Living.Trim() =="")
            {
                message = "居住地不可为空白";
                return false;
            }
            if (password.Trim() == "")
            {
                message = "默认密码不可空白";
                return false;
            }
            DAL.Student model = new DAL.Student();
            if (model.CheckExist(student.StuNo.Trim()))
            {
                message = "该学生已被录入！！！";
                return false;
            }
            message = "导入成功";
            model.Add(student);
            Model.StudentAccount account = new Model.StudentAccount();
            account.StuNo = student.StuNo;
            account.Password = Encode.GenerateMD5(password);
            return new DAL.StudentAccount().Add(account);
        }

        public DataTable GetAllStudents()
        {
            return new DAL.Student().GetAllStudents();
        }

        public void UpdateStudent(DataTable dtsource)
        {
            new DAL.Student().UpdateStudent(dtsource);
        }


        public string Delete(string stuNo)
        {
            //由于外键因素，必须先删掉对应的账户，才能删除个人信息
            //try
            //{
            //    new DAL.StudentAccount().Delete(stuNo);
            //}
            //catch
            //{
            //    return "该学生对应的账号密码未能删除";
            //}
            try
            {
                new DAL.Student().Delete(stuNo);
            }
            catch
            {
                return "该学生信息未能删除";
            }
            return "删除成功";
        }
    }
}
