using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form

    {

        int oyunAlani;
        string birinciOyuncu;
        string ikinciOyuncu;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            oyunAlani = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            oyunAlani = 5;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            oyunAlani = 7;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            birinciOyuncu = textBox2.Text;
            ikinciOyuncu = textBox1.Text;

            Form2 form = new Form2(birinciOyuncu, ikinciOyuncu, oyunAlani);
            form.Show();
            this.Hide();
        }
    }
}
