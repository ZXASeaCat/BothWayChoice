using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLogin : Form
    {
        ////如果上一次登录记住过密码，以及当前用户没有更改tbUser和tbPassword的内容
        ////那么从User.xml获取的加密过的密码，不要再次加密
        bool encodeMD5 = true;

        public FormLogin()
        {
            InitializeComponent();
            UIDesign.SetFormClass(this);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            UIDesign.SetFormMove(this);
            //读取登录过的用户
            tbUser.Items.AddRange(BLL.FileXmlIO.readAllUser());
            //文本框赋值
            string username, password;
            BLL.FileXmlIO.readUser(out username, out password);
            tbUser.Text = username;
            tbPassword.PasswordChar = '*';
            tbPassword.Text = password;
            //选择框赋值
            if (BLL.FileXmlIO.getRemember())
            {
                cbRemember.Checked = true;
                encodeMD5 = false;
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BLL.AdminAccount model = new BLL.AdminAccount();
            string message;
            //判断登录成功
            if (encodeMD5 && model.Login(tbUser.Text, BLL.Encode.GenerateMD5(tbPassword.Text), out message) || model.Login(tbUser.Text, tbPassword.Text, out message))
            {
                //记住密码
                if (cbRemember.Checked)
                {
                    BLL.FileXmlIO.setRemember("true");
                    //此时的密码未加密过
                    if (encodeMD5)
                        BLL.FileXmlIO.saveUser(tbUser.Text, BLL.Encode.GenerateMD5(tbPassword.Text));
                    //此时密码已被MD5加密
                    else
                        BLL.FileXmlIO.saveUser(tbUser.Text, tbPassword.Text);
                }
                else
                    BLL.FileXmlIO.setRemember("false");
                //打开主界面
                FormMain formMain = new FormMain();
                formMain.Show();
                this.Hide();
            }
            else
                labelMsg.Text = message;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUser.Text = "";
            tbPassword.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            encodeMD5 = true;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            encodeMD5 = true;
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            encodeMD5 = true;
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            UIDesign.SetFormMove(this);
        }

        private void labelMsg_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnClose.BackgroundImage = global::UI.Properties.Resources.btnclose2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = global::UI.Properties.Resources.btnclose1;
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                UIDesign.SetWindowRegion(this,20);
                UIDesign.SetWindowRegion(panelLogin, 20);
            }
            else
            {
                this.Region = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // 29,87,169
        }

        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
 
        
    }
}
