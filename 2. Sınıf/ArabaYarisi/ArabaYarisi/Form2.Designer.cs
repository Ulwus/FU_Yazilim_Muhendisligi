namespace ArabaYarisi
{
    partial class Form2
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCar = new System.Windows.Forms.PictureBox();
            this.obstacle1 = new System.Windows.Forms.PictureBox();
            this.obstacle2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Oyuncu: ---";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArabaYarisi.Properties.Resources.obstacle2;
            this.pictureBox1.Location = new System.Drawing.Point(252, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;

            this.pictureBox1.Tag = "obstacle";
            // 
            // picCar
            // 
            this.picCar.BackColor = System.Drawing.Color.Transparent;
            this.picCar.Image = global::ArabaYarisi.Properties.Resources.picCar;
            this.picCar.Location = new System.Drawing.Point(150, 300);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(50, 100);
            this.picCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCar.TabIndex = 1;
            this.picCar.TabStop = false;
            // 
            // obstacle1
            // 
            this.obstacle1.Image = global::ArabaYarisi.Properties.Resources.obstacle1;
            this.obstacle1.Location = new System.Drawing.Point(100, 50);
            this.obstacle1.Name = "obstacle1";
            this.obstacle1.BackColor = System.Drawing.Color.Transparent;
            this.obstacle1.Size = new System.Drawing.Size(50, 50);
            this.obstacle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacle1.TabIndex = 2;
            this.obstacle1.TabStop = false;
            this.obstacle1.Tag = "obstacle";
            // 
            // obstacle2
            // 
            this.obstacle2.Image = global::ArabaYarisi.Properties.Resources.obstacle2;
            this.obstacle2.Location = new System.Drawing.Point(250, -100);
            this.obstacle2.Name = "obstacle2";
            this.obstacle2.BackColor = System.Drawing.Color.Transparent;

            this.obstacle2.Size = new System.Drawing.Size(50, 50);
            this.obstacle2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacle2.TabIndex = 3;
            this.obstacle2.TabStop = false;
            this.obstacle2.Tag = "obstacle";
            // 
            // Form2
            // 
            this.BackgroundImage = global::ArabaYarisi.Properties.Resources.road;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picCar);
            this.Controls.Add(this.obstacle1);
            this.Controls.Add(this.obstacle2);
            this.Name = "Form2";
            this.Text = "Araba Yarışı";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.PictureBox obstacle1;
        private System.Windows.Forms.PictureBox obstacle2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
