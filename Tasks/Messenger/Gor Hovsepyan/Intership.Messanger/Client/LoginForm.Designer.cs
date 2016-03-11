namespace MessangerClient
{
    partial class LoginForm
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
            this.NicknameTxtbox = new System.Windows.Forms.TextBox();
            this.ServerIpTxtbox = new System.Windows.Forms.TextBox();
            this.LoginBt = new System.Windows.Forms.Button();
            this.ServerPortTxtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NicknameTxtbox
            // 
            this.NicknameTxtbox.Location = new System.Drawing.Point(44, 55);
            this.NicknameTxtbox.Name = "NicknameTxtbox";
            this.NicknameTxtbox.Size = new System.Drawing.Size(184, 20);
            this.NicknameTxtbox.TabIndex = 0;
            // 
            // ServerIpTxtbox
            // 
            this.ServerIpTxtbox.Location = new System.Drawing.Point(44, 100);
            this.ServerIpTxtbox.Name = "ServerIpTxtbox";
            this.ServerIpTxtbox.Size = new System.Drawing.Size(184, 20);
            this.ServerIpTxtbox.TabIndex = 1;
            // 
            // LoginBt
            // 
            this.LoginBt.Location = new System.Drawing.Point(96, 187);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(75, 23);
            this.LoginBt.TabIndex = 2;
            this.LoginBt.Text = "Login";
            this.LoginBt.UseVisualStyleBackColor = true;
            // 
            // ServerPortTxtbox
            // 
            this.ServerPortTxtbox.Location = new System.Drawing.Point(44, 143);
            this.ServerPortTxtbox.Name = "ServerPortTxtbox";
            this.ServerPortTxtbox.Size = new System.Drawing.Size(184, 20);
            this.ServerPortTxtbox.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 320);
            this.Controls.Add(this.ServerPortTxtbox);
            this.Controls.Add(this.LoginBt);
            this.Controls.Add(this.ServerIpTxtbox);
            this.Controls.Add(this.NicknameTxtbox);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NicknameTxtbox;
        private System.Windows.Forms.TextBox ServerIpTxtbox;
        private System.Windows.Forms.Button LoginBt;
        private System.Windows.Forms.TextBox ServerPortTxtbox;
    }
}

