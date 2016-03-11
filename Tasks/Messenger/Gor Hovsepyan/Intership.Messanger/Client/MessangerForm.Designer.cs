namespace MessangerClient
{
    partial class MessangerForm
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
            this.MessangerView = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SendBt = new System.Windows.Forms.Button();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // MessangerView
            // 
            this.MessangerView.FormattingEnabled = true;
            this.MessangerView.Location = new System.Drawing.Point(29, 56);
            this.MessangerView.Name = "MessangerView";
            this.MessangerView.Size = new System.Drawing.Size(554, 316);
            this.MessangerView.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 435);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(554, 62);
            this.textBox1.TabIndex = 1;
            // 
            // SendBt
            // 
            this.SendBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBt.Location = new System.Drawing.Point(605, 435);
            this.SendBt.Name = "SendBt";
            this.SendBt.Size = new System.Drawing.Size(75, 62);
            this.SendBt.TabIndex = 2;
            this.SendBt.Text = "Send";
            this.SendBt.UseVisualStyleBackColor = true;
            // 
            // UsersList
            // 
            this.UsersList.FormattingEnabled = true;
            this.UsersList.Location = new System.Drawing.Point(667, 56);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(120, 316);
            this.UsersList.TabIndex = 3;
            // 
            // MessangerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 509);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.SendBt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MessangerView);
            this.Name = "MessangerForm";
            this.Text = "MessangerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MessangerView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SendBt;
        private System.Windows.Forms.ListBox UsersList;
    }
}