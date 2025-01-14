// GİRİŞ: Sol ve Sağ tık

// ÇIKIŞ: Oyun boyunca kullanıcıya sağlanan görsel çıktı

// KONTROL: Kullanıcının oyun sırasında yapabileceği işlemler kontrol edilir.
// - Sol tıklama: Hücre açma işlemi (mayın var mı yok mu kontrol edilir).
// - Sağ tıklama: Bayrak ekleme veya kaldırma işlemi.


// TEKRAR: Oyundaki döngüler, hem mayınların rastgele yerleştirilmesi hem de oyun alanındaki komşu hücrelerin kontrolü için kullanılır.

// MATEMATİK: Oyundaki matematiksel işlemler:
// - Rastgele mayın pozisyonlarının belirlenmesi (`Random` sınıfı).
// - Komşu hücrelerin hesaplanması için indeks aritmetiği.
// - Formun ve butonların boyutlarının dinamik olarak ayarlanması (genişlik ve yükseklik hesaplamaları).


// Gerekli kütüphaneleri ekliyoruz
using System;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        // Oyun alanı için buton matrisi ve mayın dizisi tanımlıyoruz
        private Button[,] buttons;
        private int[,] mines;
        // Satır ve sütun sayıları ile mayın sayısını belirliyoruz
        private int rows = 9;
        private int cols = 9;
        private int mineCount = 10;

        // Formun yapıcı metodu
        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlatıyoruz
        }

        // Form yüklendiğinde çalışan metot
        private void Form1_Load(object sender, EventArgs e)
        {
            OyunuBaslat(); // Oyunu başlatıyoruz
        }

        // Oyunu başlatan metot
        private void OyunuBaslat()
        {
            buttons = new Button[rows, cols]; // Buton matrisi oluşturuyoruz
            mines = new int[rows, cols]; // Mayın dizisini oluşturuyoruz
            MayinlariOlustur(); // Mayınları rastgele yerleştiriyoruz
            ButonlariOlustur(); // Butonları oluşturup form üzerine ekliyoruz
            lblMineCount.Text = "Mayın Sayısı: " + mineCount; // Mayın sayısını ekranda gösteriyoruz
        }

        // Mayınları rastgele pozisyonlara yerleştiren metot
        private void MayinlariOlustur()
        {
            Random rand = new Random();
            int placedMines = 0;

            // Belirtilen sayıda mayın yerleştirene kadar döngüye devam ediyoruz
            while (placedMines < mineCount)
            {
                int r = rand.Next(rows); // Rastgele bir satır seçiyoruz
                int c = rand.Next(cols); // Rastgele bir sütun seçiyoruz

                // Seçilen pozisyonda daha önce mayın yoksa mayın yerleştiriyoruz
                if (mines[r, c] == 0)
                {
                    mines[r, c] = -1; // -1 değeri mayını temsil ediyor
                    placedMines++;
                }
            }
        }

        // Oyun alanındaki butonları oluşturan metot
        private void ButonlariOlustur()
        {
            int buttonSize = 30; // Buton boyutunu belirliyoruz

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button(); // Yeni bir buton oluşturuyoruz
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = j * buttonSize;
                    btn.Top = i * buttonSize + 30; // Üstteki label için yer bırakıyoruz
                    btn.Tag = new int[] { i, j }; // Butonun konum bilgilerini tag olarak saklıyoruz
                    btn.MouseUp += Btn_MouseUp; // MouseUp olayını butona ekliyoruz
                    this.Controls.Add(btn); // Butonu forma ekliyoruz
                    buttons[i, j] = btn; // Butonu matrise ekliyoruz
                }
            }
            // Formun boyutlarını dinamik olarak ayarlıyoruz
            this.Width = cols * buttonSize + 16;
            this.Height = rows * buttonSize + 39 + 30; // Label yüksekliğini ekliyoruz
        }

        // Butona tıklandığında çalışan olay metodu
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int[] position = btn.Tag as int[]; // Butonun konum bilgisini alıyoruz
            int i = position[0];
            int j = position[1];

            if (e.Button == MouseButtons.Left) // Sol tıklama işlemi
            {
                if (mines[i, j] == -1) // Eğer mayına tıklandıysa
                {
                    btn.Text = "*"; // Butona mayın sembolü koyuyoruz
                    btn.BackColor = System.Drawing.Color.Red; // Arka plan rengini kırmızı yapıyoruz
                    MessageBox.Show("Oyun bitti!"); // Kullanıcıya mesaj gösteriyoruz
                    TumMayinlariGoster(); // Tüm mayınları gösteriyoruz
                }
                else
                {
                    int count = KomsuMayinSayisi(i, j); // Etrafındaki mayın sayısını hesaplıyoruz
                    btn.Text = count.ToString(); // Butonun üzerine mayın sayısını yazıyoruz
                    btn.Enabled = false; // Butonu devre dışı bırakıyoruz
                    // Boş hücreleri açma işlemini kaldırdık
                }
            }
            else if (e.Button == MouseButtons.Right) // Sağ tıklama işlemi
            {
                // Butona bayrak koyma veya kaldırma işlemi
                if (btn.Text == "F")
                {
                    btn.Text = ""; // Bayrağı kaldırıyoruz
                }
                else
                {
                    btn.Text = "F"; // Butona bayrak koyuyoruz
                }
            }
        }

        // Oyun bittiğinde tüm mayınları gösteren metot
        private void TumMayinlariGoster()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mines[i, j] == -1)
                    {
                        buttons[i, j].Text = "*"; // Mayınları gösteriyoruz
                    }
                }
            }
        }

        // Belirtilen hücrenin etrafındaki mayın sayısını hesaplayan metot
        private int KomsuMayinSayisi(int row, int col)
        {
            int count = 0;

            // Etrafındaki 8 hücreyi kontrol ediyoruz
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    // Sınırlar içinde olup olmadığını kontrol ediyoruz
                    if (i >= 0 && i < rows && j >= 0 && j < cols)
                    {
                        if (mines[i, j] == -1)
                        {
                            count++; // Mayın buldukça sayacı artırıyoruz
                        }
                    }
                }
            }
            return count; // Toplam mayın sayısını döndürüyoruz
        }
    }
}