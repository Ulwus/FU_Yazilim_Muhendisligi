using System;
using System.Windows.Forms;

namespace ArabaYarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin!");
            }
            else
            {
                Form2 gameForm = new Form2(txtUserName.Text); 
                gameForm.Show();
                this.Hide();
            }
        }
    }
}
