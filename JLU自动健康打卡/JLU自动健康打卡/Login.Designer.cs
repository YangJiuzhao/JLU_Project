
namespace JLU自动健康打卡
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBox_account = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_account = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            label_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_account
            // 
            this.textBox_account.Location = new System.Drawing.Point(101, 53);
            this.textBox_account.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_account.Name = "textBox_account";
            this.textBox_account.Size = new System.Drawing.Size(120, 21);
            this.textBox_account.TabIndex = 2;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(101, 83);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(120, 21);
            this.textBox_password.TabIndex = 3;
            // 
            // label_account
            // 
            this.label_account.AutoSize = true;
            this.label_account.Location = new System.Drawing.Point(49, 58);
            this.label_account.Name = "label_account";
            this.label_account.Size = new System.Drawing.Size(41, 12);
            this.label_account.TabIndex = 0;
            this.label_account.Text = "账号：";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(49, 88);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(41, 12);
            this.label_password.TabIndex = 1;
            this.label_password.Text = "密码：";
            this.label_password.Click += new System.EventHandler(this.Label_password_Click_1);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(25, 118);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(65, 12);
            this.label_time.TabIndex = 4;
            this.label_time.Text = "打卡时间：";
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(101, 113);
            this.textBox_time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(120, 21);
            this.textBox_time.TabIndex = 5;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(266, 54);
            this.button_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(96, 81);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);



            label_result.AutoSize = true;
            label_result.Location = new System.Drawing.Point(100, 138);
            label_result.Name = "label_result";
            label_result.Size = new System.Drawing.Size(100, 21);
            label_result.TabIndex = 4;
            label_result.Text = "";
            label_result.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.label_account);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_account);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.button_login);
            this.Controls.Add(label_result);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "JLU本科生健康打卡";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_account;
        private System.Windows.Forms.TextBox textBox_account;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Button button_login;
        protected static System.Windows.Forms.Label label_result;
    }
}