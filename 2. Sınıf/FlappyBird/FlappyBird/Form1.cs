/*
Giriş:
space tuşu
Çıkış:
Oyun, kuşun borulara çarpması, yerle çarpması veya üst sınırı aşması durumunda sona erer. Oyun sona erdiğinde, geçerli puan ile en yüksek puan gösterilir. Oyuncu, 'SPACE' tuşuna basarak oyunu yeniden başlatabilir.

Kontrol:
- Boşluk tuşuna (SPACE) basarak kuşu yukarı doğru hareket ettirin. Her boşluk tuşuna basış, kuşun yukarı doğru bir itme almasını sağlar.
- Oyun başladıktan sonra, kuşu yukarı zıplatmak için boşluk tuşuna basmaya devam edebilirsiniz.
- 'R' tuşuna basarak oyunu yeniden başlatabilirsiniz. Oyun sona erdikten sonra, bu tuşa basarak yeni bir oyun başlayabilirsiniz.

Tekrar:
Oyun sona erdiğinde, 'R' tuşuna basarak oyunu baştan oynayabilirsiniz. Bu, skoru sıfırlar ve oyunu yeniden başlatır.

Matematik:
Oyunda, puanlama sistemi, boruları geçtikçe puan kazanmanızı sağlar. Her geçen boru için bir puan kazanırsınız. Oyuncunun puanı, oyun ilerledikçe gösterilir. Belirli puan aralıklarında, boruların hızı artar, bu da oyunun zorluğunu artırır.

Oyun, 'highscore.txt' adlı bir dosyada en yüksek puanı saklar. Oyun başladığında veya sona erdiğinde, dosyadan bu değer okunur ve oyunun başlangıcında ekrana yazdırılır. Eğer oyuncunun geçerli skoru yüksek skordan fazlaysa, yüksek skor güncellenir ve dosyaya yazılır.
*/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        int gravity = 10; // Kuşun düşme hızını temsil eder. Düşük değerler, kuşun daha yavaş düşmesine neden olur.
        int pipeSpeed = 5; // Boruların sola doğru hareket hızını temsil eder. Bu değer, oyuncunun ilerlemesine bağlı olarak değişir.
        int score = 0; // Oyuncunun geçerli skorunu tutar. Her boruyu geçtiğinde 1 artar.
        int highScore = 0; // Oyuncunun en yüksek skorunu saklar. Oyun sona erdiğinde, bu değer güncellenir.
        bool isGameStarted = false; // Oyun başlayıp başlamadığını kontrol eder. Oyun başlamadan borular hareket etmez.
        Random random = new Random(); // Rastgele sayı üretmek için kullanılır. Boruların yüksekliğini belirlemek için rastgele bir değer üretir.

        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlatır.
            LoadHighScore(); // Yüksek skoru dosyadan yükle.
        }

        private void LoadHighScore()
        {
            // Eğer yüksek skor dosyası mevcutsa, dosyadan oku ve yüksek skoru ayarla.
            if (File.Exists("highscore.txt"))
            {
                highScore = int.Parse(File.ReadAllText("highscore.txt")); // Dosyadan oku ve yüksek skoru int olarak ayarla.
            }
            scoreText.Text = "Score: 0 | High Score: " + highScore; // Başlangıçta skor ve yüksek skoru göster.
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Oyun başlamadıysa, işlemleri atla.
            if (!isGameStarted) return;

            // Kuşun konumunu güncelle. Düşme hızına bağlı olarak yukarı veya aşağı hareket eder.
            flappyBird.Top += gravity;
            // Boruların sola doğru hareketini güncelle.
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;

            // Eğer alt boru ekranın sol tarafını geçerse, boruları yeniden başlat.
            if (pipeBottom.Left < -150)
            {
                // Boruları sağ tarafa yerleştir.
                pipeBottom.Left = 800;
                pipeTop.Left = 800;
                // Boruların yüksekliğini rastgele ayarla.
                int pipeHeight = random.Next(100, 300); // 100 ile 300 arasında rastgele bir yükseklik belirle.
                pipeTop.Height = pipeHeight; // Üst borunun yüksekliğini ayarla.
                pipeBottom.Top = pipeTop.Bottom + 150; // Alt borunun yüksekliğini ayarla, üst borunun altı ile 150 piksel arasında bir boşluk bırak.
                score++; // Skoru bir artır.
            }

            // Skor ve yüksek skor metnini güncelle.
            scoreText.Text = "Score: " + score + " | High Score: " + highScore;

            // Oyunun zorluk seviyesini artır.
            if (score > 5 && score <= 10)
            {
                pipeSpeed = 8; // Skor 5 ile 10 arasındaysa boruların hızını artır.
            }
            else if (score > 10)
            {
                pipeSpeed = 10; // Skor 10'dan büyükse, boruların hızını daha da artır.
            }

            // Kuş ve boru çarpışmaları için kontroller.
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                EndGame(); // Çarpışma durumunda oyunu bitir.
            }
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            // Eğer boşluk tuşuna basıldıysa.
            if (e.KeyCode == Keys.Space)
            {
                // Oyun başlamadıysa, oyunu başlat.
                if (!isGameStarted)
                {
                    StartGame(); // Oyun başlangıcını başlat.
                }
                gravity = -10; // Yukarı doğru itme. Düşmeyi engeller.
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            // Eğer boşluk tuşu bırakıldıysa, kuşu aşağıya doğru düşür.
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10; // Aşağı düşme hızını ayarla.
            }
        }

        private void StartGame()
        {
            isGameStarted = true; // Oyunun başlangıcını işaretle.
            score = 0; // Skoru sıfırla.
            pipeSpeed = 5; // Boru hızını başlangıç değerine ayarla.
            flappyBird.Location = new Point(75, 150); // Kuşun başlangıç konumunu ayarla.
            pipeBottom.Left = 400; // Boruların başlangıç konumunu ayarla.
            pipeTop.Left = 400;
            // Rastgele bir yükseklik oluştur ve boruları bu yüksekliğe göre ayarla.
            int pipeHeight = random.Next(100, 300); // Rastgele üst boru yüksekliği.
            pipeTop.Height = pipeHeight; // Üst borunun yüksekliğini ayarla.
            pipeBottom.Top = pipeTop.Bottom + 150; // Alt borunun yüksekliğini ayarla, üst borunun altı ile 150 piksel arasında bir boşluk bırak.
            gameTimer.Start(); // Oyun zamanlayıcısını başlat.
        }

        private void EndGame()
        {
            gameTimer.Stop(); // Oyun zamanlayıcısını durdur.
            isGameStarted = false; // Oyunun bitişini işaretle.

            // Eğer geçerli skor yüksek skordan fazlaysa, yüksek skoru güncelle.
            if (score > highScore)
            {
                highScore = score; // Yeni yüksek skoru ayarla.
                File.WriteAllText("highscore.txt", highScore.ToString()); // Yüksek skoru dosyaya yaz.
            }

            // Oyun bitiminde gösterilecek mesaj.
            scoreText.Text = "Score: " + score + " | High Score: " + highScore + " Game Over! Press 'SPACE' to Restart."; // Oyun bitiş mesajı.
        }

        private void GameRestart(object sender, KeyEventArgs e)
        {
            // Eğer 'R' tuşuna basıldıysa, oyunu yeniden başlat.
            if (e.KeyCode == Keys.R)
            {
                StartGame(); // Yeniden oyunu başlat.
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(GameRestart); // Form yüklendiğinde tuş olaylarını ekle.
            scoreText.Text = "Press Space to Start"; // Oyun başlangıcında gösterilecek mesaj.
        }

        
    }
}
