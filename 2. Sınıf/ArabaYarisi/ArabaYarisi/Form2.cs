// GİRİŞ: Kullanıcı adı, sol ve sağ ok tuşları


// ÇIKIŞ: Kullanıcıya gösterilen bilgiler ve görsel çıktı.

// KONTROL: Kullanıcı girişi ve oyundaki kurallar.
// - Klavyeden sola ve sağa hareket kontrolleri (ok tuşları).
// - Engellerin ekrandan çıkıp yeniden yerleştirilmesi.
// - Araç ve engel çarpışmalarının kontrolü.

// TEKRAR: Oyun sırasında engellerin hareketini ve çarpışma kontrollerini sürekli güncellemek için zamanlayıcı ve döngüler kullanılır.


// MATEMATİK: Rastgelelik ve pozisyon hesaplamaları.
// - Engellerin rastgele yatay konumları `Random` sınıfıyla belirlenir.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArabaYarisi
{
    public partial class Form2 : Form
    {
        // Arabanın başlangıç yatay pozisyonunu belirleyen değişken
        private int carXPosition = 150;

        // Arabanın başlangıç dikey pozisyonunu belirleyen değişken
        private int carYPosition = 300;

        // Oyunun hızını kontrol eden değişken
        private int speed = 10;

        // Rastgele sayı üretmek için Random nesnesi
        private Random random = new Random();

        // Oyun zamanlayıcısı
        private Timer gameTimer = new Timer();

        // Kullanıcı adını parametre olarak alan yapıcı method
        public Form2(string userName)
        {
            // Form bileşenlerini başlatan method
            InitializeComponent();

            // Kullanıcı adını ekranda göster
            lblUserName.Text = $"Oyuncu: {userName}";

            // Zamanlayıcı ayarları
            gameTimer.Interval = 50; // 50 milisaniyede bir çalış
            gameTimer.Tick += GameTimer_Tick; // Zamanlayıcı her çalıştığında GameTimer_Tick metodunu çağır
            gameTimer.Start(); // Zamanlayıcıyı başlat
        }

        // Oyunun ana mantığını işleyen zamanlayıcı metodu
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Tüm form kontrollerini döngüye al
            foreach (Control control in this.Controls)
            {
                // Engel olarak işaretlenmiş kontrolleri bul
                if (control.Tag != null && control.Tag.ToString() == "obstacle")
                {
                    // Engelleri belirlenen hızda aşağı doğru hareket ettir
                    control.Top += speed;

                    // Engel ekranın altına çıkarsa
                    if (control.Top > this.ClientSize.Height)
                    {
                        // Engeli ekranın üstüne geri yerleştir
                        control.Top = -control.Height;
                        // Engeli rastgele yatay konumda yerleştir
                        control.Left = random.Next(50, this.ClientSize.Width - control.Width);
                    }

                    // Çarpışma kontrolü
                    if (picCar.Bounds.IntersectsWith(control.Bounds))
                    {
                        // Zamanlayıcıyı durdur
                        gameTimer.Stop();
                        // Çarpışma mesajı göster
                        MessageBox.Show("Çarptınız! Oyun bitti.");
                        // Formu kapat
                        this.Close();
                    }
                }
            }
        }

        // Klavye tuş basışlarını yakalayan metod
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            // Sol ok tuşuna basıldığında ve araç ekranın solunda ise sola hareket ettir
            if (e.KeyCode == Keys.Left && carXPosition > 0)
                carXPosition -= 10;

            // Sağ ok tuşuna basıldığında ve araç ekranın sağında ise sağa hareket ettir
            else if (e.KeyCode == Keys.Right && carXPosition < this.ClientSize.Width - picCar.Width)
                carXPosition += 10;

            // Araç resminin konumunu güncelle
            picCar.Top = carYPosition;
            picCar.Left = carXPosition;
        }
    }
}