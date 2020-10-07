namespace UI
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelMsg = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(109, 59);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(249, 26);
            this.tbPassword.TabIndex = 10;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(305, 105);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(63, 14);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "忘记密码";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUser.ForeColor = System.Drawing.Color.Black;
            this.labelUser.Location = new System.Drawing.Point(31, 21);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(42, 22);
            this.labelUser.TabIndex = 12;
            this.labelUser.Text = "账号";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPassword.ForeColor = System.Drawing.Color.Black;
            this.labelPassword.Location = new System.Drawing.Point(31, 63);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(42, 22);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "密码";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(163, 138);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 39);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(35, 138);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 39);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(88, 34);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(378, 33);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "广东医双选系统管理员端";
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.BackgroundImage = global::UI.Properties.Resources.panel;
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogin.Controls.Add(this.labelMsg);
            this.panelLogin.Controls.Add(this.tbUser);
            this.panelLogin.Controls.Add(this.btnExit);
            this.panelLogin.Controls.Add(this.cbRemember);
            this.panelLogin.Controls.Add(this.picPassword);
            this.panelLogin.Controls.Add(this.picUser);
            this.panelLogin.Controls.Add(this.linkLabel1);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.tbPassword);
            this.panelLogin.Controls.Add(this.btnClear);
            this.panelLogin.Controls.Add(this.labelUser);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelLogin.Location = new System.Drawing.Point(74, 87);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(392, 189);
            this.panelLogin.TabIndex = 16;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMsg.ForeColor = System.Drawing.Color.Red;
            this.labelMsg.Location = new System.Drawing.Point(171, 101);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(0, 14);
            this.labelMsg.TabIndex = 21;
            this.labelMsg.Click += new System.EventHandler(this.labelMsg_Click);
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("宋体", 12F);
            this.tbUser.FormattingEnabled = true;
            this.tbUser.Location = new System.Drawing.Point(109, 19);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(249, 24);
            this.tbUser.TabIndex = 19;
            this.tbUser.SelectedIndexChanged += new System.EventHandler(this.tbUser_SelectedIndexChanged);
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(288, 138);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 39);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.ForeColor = System.Drawing.Color.Black;
            this.cbRemember.Location = new System.Drawing.Point(35, 101);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(82, 18);
            this.cbRemember.TabIndex = 20;
            this.cbRemember.Text = "记住密码";
            this.cbRemember.UseVisualStyleBackColor = true;
            this.cbRemember.CheckedChanged += new System.EventHandler(this.cbRemember_CheckedChanged);
            // 
            // picPassword
            // 
            this.picPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPassword.Image = global::UI.Properties.Resources.Password;
            this.picPassword.Location = new System.Drawing.Point(79, 63);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(24, 22);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPassword.TabIndex = 17;
            this.picPassword.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picUser.Image = global::UI.Properties.Resources.user;
            this.picUser.Location = new System.Drawing.Point(79, 21);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(24, 22);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 16;
            this.picUser.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::UI.Properties.Resources.btnclose1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(513, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 17;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseMove);
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::UI.Properties.Resources.formloginbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(544, 313);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseMove);
            this.Resize += new System.EventHandler(this.FormLogin_Resize);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox tbUser;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.Label labelMsg;
    }
}

