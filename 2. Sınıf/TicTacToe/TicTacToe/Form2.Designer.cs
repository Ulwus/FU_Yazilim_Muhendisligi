partial class Form2
{
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Gerekli tasarımcı değişkenini temizler.
    /// </summary>
    /// <param name="disposing"></param>
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
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.SuspendLayout();

        // label1
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(50, 470);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(62, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "1. Oyuncu: ";

        // label2
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(50, 490);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(62, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "2. Oyuncu: ";

        // Form2
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 550);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.label2);
        this.Name = "Form2";
        this.Text = "Tic Tac Toe";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
}
