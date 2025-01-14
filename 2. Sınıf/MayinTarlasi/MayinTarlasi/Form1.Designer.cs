namespace MayinTarlasi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMineCount;

 


        private void InitializeComponent()
        {
            this.lblMineCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMineCount
            // 
            this.lblMineCount.AutoSize = true;
            this.lblMineCount.Location = new System.Drawing.Point(12, 9);
            this.lblMineCount.Name = "lblMineCount";
            this.lblMineCount.Size = new System.Drawing.Size(71, 13);
            this.lblMineCount.TabIndex = 0;
            this.lblMineCount.Text = "Mayın Sayısı: ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblMineCount);
            this.Name = "Form1";
            this.Text = "Mayın Tarlası";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}