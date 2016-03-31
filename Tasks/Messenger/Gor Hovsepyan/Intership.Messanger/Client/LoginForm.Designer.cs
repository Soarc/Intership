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
            this.IptxtTxtbox = new System.Windows.Forms.TextBox();
            this.PortTxtbox = new System.Windows.Forms.TextBox();
            this.LoginBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NickTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IptxtTxtbox
            // 
            this.IptxtTxtbox.Location = new System.Drawing.Point(90, 55);
            this.IptxtTxtbox.Name = "IptxtTxtbox";
            this.IptxtTxtbox.Size = new System.Drawing.Size(184, 20);
            this.IptxtTxtbox.TabIndex = 0;
            // 
            // PortTxtbox
            // 
            this.PortTxtbox.Location = new System.Drawing.Point(90, 93);
            this.PortTxtbox.Name = "PortTxtbox";
            this.PortTxtbox.Size = new System.Drawing.Size(184, 20);
            this.PortTxtbox.TabIndex = 1;
            // 
            // LoginBt
            // 
            this.LoginBt.Location = new System.Drawing.Point(124, 138);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(75, 23);
            this.LoginBt.TabIndex = 2;
            this.LoginBt.Text = "Connect";
            this.LoginBt.UseVisualStyleBackColor = true;
            this.LoginBt.Click += new System.EventHandler(this.LoginBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ServerIp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ServerPort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nickname";
            // 
            // NickTxt
            // 
            this.NickTxt.Location = new System.Drawing.Point(90, 22);
            this.NickTxt.Name = "NickTxt";
            this.NickTxt.Size = new System.Drawing.Size(184, 20);
            this.NickTxt.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 198);
            this.Controls.Add(this.NickTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBt);
            this.Controls.Add(this.PortTxtbox);
            this.Controls.Add(this.IptxtTxtbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IptxtTxtbox;
        private System.Windows.Forms.TextBox PortTxtbox;
        private System.Windows.Forms.Button LoginBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NickTxt;
    }
}

