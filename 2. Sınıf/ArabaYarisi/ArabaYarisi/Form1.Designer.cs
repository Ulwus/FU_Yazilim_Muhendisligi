namespace ArabaYarisi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblWelcome.Location = new System.Drawing.Point(60, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(250, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Araba Yarışına Hoş Geldiniz!";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(64, 80);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "Kullanıcı Adı";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(64, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Başla!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblWelcome);
            this.Name = "Form1";
            this.Text = "Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnStart;
    }
}
