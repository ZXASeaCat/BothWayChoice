using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.OleDb;  

namespace UI
{
    public partial class FormMain : Form
    {
        #region 主界面

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabPage1.BackColor = Color.Transparent;
            tbStudentPwd.Text = "123456";
            tbTeacherPwd.Text = "123456";
            cbDisb.Text = "全部";
            rbStudent.Checked = true;
            dgvAll.Visible = true;
            dgvAllTeacher.Visible = false;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.OpenForms[0].Show();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region  FormMain左边菜单栏
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }


        private void btnSelect3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnSelect4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnSelect5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        #endregion



        #region panelPage4
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.Rows.Clear();
                dt.Columns.Clear();
                dataGridView1.DataSource = dt;
            }

            this.openFileDialog1.ShowDialog();
            string fileName = this.openFileDialog1.FileName;
            string strCon = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;Imex=1'";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = "select * from [sheet1$]";
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            DataTable table = new DataTable();
            myCommand.Fill(table);
            this.dataGridView1.DataSource = table;      
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region panelPage3
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string message;
            Model.Student student = new Model.Student();
            student.StuNo = tbAddStuNo.Text;
            student.StuName = tbAddStuName.Text;
            student.Grade = tbAddStuGrade.Text;
            student.Subject = tbAddStuSubject.Text;
            student.College = tbAddStuCollege.Text;
            student.Phone = tbAddStuPhone.Text;
            student.Living = tbAddStuLiving.Text;
            new BLL.Student().Add(student,tbStudentPwd.Text, out message);
            labelStuMsg.Text = message;
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            string message;
            Model.Teacher teacher = new Model.Teacher();
            teacher.TeacherNo = tbAddTeacherNo.Text;
            teacher.TeacherName = tbAddTeacherName.Text;
            teacher.Subject = tbAddTeacherSubject.Text;
            teacher.College = tbAddTeacherCollege.Text;
            teacher.Research = tbAddTeacherResearch.Text;
            teacher.Brief = tbAddTeacherBrief.Text;
            new BLL.Teacher().Add(teacher,tbTeacherPwd.Text, out message);
            labelTeacherMsg.Text = message;
        }
        #endregion

        #region panelPage2



        private void btnAllQuery_Click(object sender, EventArgs e)
        {
            if (rbTeacher.Checked)
            {
                dgvAllTeacher.DataSource = new BLL.Teacher().GetAllTeachers();
            }
            else if (rbStudent.Checked)
            {
                dgvAll.DataSource = new BLL.Student().GetAllStudents();
            }
        }

        private void btnAllUpdate_Click(object sender, EventArgs e)
        {
            if (rbTeacher.Checked)
                new BLL.Teacher().UpdateTeacher((DataTable)dgvAllTeacher.DataSource);
            else if (rbStudent.Checked)
                new BLL.Student().UpdateStudent((DataTable)dgvAll.DataSource);
        }

        private void btnAllDelete_Click(object sender, EventArgs e)
        {
            string message = "";
            if (rbTeacher.Checked)
            {
                string id = (string)dgvAllTeacher.CurrentRow.Cells[0].Value;
                if (id != null)
                {
                    message = new BLL.Teacher().Delete(id);
                    labelMsg1.Text = message;
                }
                if (message != "")
                    dgvAllTeacher.DataSource = new BLL.Teacher().GetAllTeachers();
            }
            else if (rbStudent.Checked)
            {
                string id = (string)dgvAll.CurrentRow.Cells[0].Value;
                if (id != null)
                {
                    message = new BLL.Student().Delete(id);
                    labelMsg1.Text = message;
                }
                if (message != "")
                    dgvAll.DataSource = new BLL.Student().GetAllStudents();
            }
        }

        private void rbStudent_Click(object sender, EventArgs e)
        {
            dgvAllTeacher.Visible = false;
            dgvAll.Visible = true;
        }

        private void rbTeacher_Click(object sender, EventArgs e)
        {
            dgvAllTeacher.Visible = true;
            dgvAll.Visible = false;
        }

        #endregion

        #region panelPage1
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Model.Team team = new Model.Team();
            BLL.Team model = new BLL.Team();
            team.Grade = combGrade.Text;
            team.TeamNo = tbTeam.Text;
            team.LeaderName = tbStudent.Text;
            string teacherName = tbTeacher.Text;
            string subject = combSubject.Text;
            if (cbDisb.Text.Trim() == "已分配")
            {
                dgvTeam.DataSource = model.getAllTeamSelects(subject, team, teacherName);
            }
            else if (cbDisb.Text.Trim() == "未分配")
            {
                teacherName = null;
                dgvTeam.DataSource = model.getAllTeamSelects(subject, team, teacherName);
            }
            else
            {
                dgvTeam.DataSource = model.getAllTeamSelectsOutTeachers(subject, team);
            }
        }

        private void tbTeacher_Click(object sender, EventArgs e)
        {
            cbDisb.Text = "已分配";
        }

        private void cbDisb_Click(object sender, EventArgs e)
        {
            tbTeacher.Text = "";
        }
        #endregion

        private void buttonDisb_Click(object sender, EventArgs e)
        {
            DataTable dtDisb = new DataTable();
            dtDisb.Columns.Add("team", typeof(string));
            dtDisb.Columns.Add("teacher", typeof(string));
            DataTable dtFailTeam = new DataTable();
            dtFailTeam.Columns.Add("failteam", typeof(string));
            DataTable dtRestTeacher = new DataTable();
            dtRestTeacher.Columns.Add("restteacher", typeof(string));
            new BLL.Distribute().distribute(cbAllGrade.Text, cbAllSubject.Text, dtDisb, dtFailTeam, dtRestTeacher);
            dataDisb.DataSource = dtDisb;
            dataFailTeam.DataSource = dtFailTeam;
            //dataRestTeacher.DataSource = dtRestTeacher;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string grade = cbAllGrade.Text;
            string subject = cbAllSubject.Text;
            dataTeam.DataSource = new BLL.Distribute().GetNotTeamDisb(grade,subject);
            dataTeacher.DataSource = new BLL.Distribute().GetTeacherSelectRest(subject);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string message = "匹配结果空白";
            if (dataDisb.DataSource != null)
                new BLL.Distribute().UpdateSelectResult((DataTable)dataDisb.DataSource,out message);
            labelMsg2.Text = message;
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            gridPrinter = BLL.GridPrinter.InitializePrinting(dgvTeam, printDocument1);
            if (gridPrinter != null)
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument1;
                printPreviewDialog.ShowDialog();
            }
        }

        BLL.GridPrinter gridPrinter;//声明打印类

        //打印绘制
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = gridPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (rbTeacher.Checked)
                gridPrinter = BLL.GridPrinter.InitializePrinting(dgvAllTeacher, printDocument1);
            else if (rbStudent.Checked)
                gridPrinter = BLL.GridPrinter.InitializePrinting(dgvAll, printDocument1);
            if (gridPrinter != null)
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument1;
                printPreviewDialog.ShowDialog();
            }
        }

        private void rbTeacher_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {

        }







      
    }
}
