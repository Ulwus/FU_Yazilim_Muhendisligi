using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class adamAsmaca : Form
    {
        // Butonlar için harf listesi
        private readonly string[] letters = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };
        private string selectedCity;
        private string currentWord;
        private int remainingAttempts;
        private const int maxAttempts = 10;

        public adamAsmaca()
        {
            InitializeComponent();
            //Form açıldıktan sonra oyunu başlatan fonksiyon.
            StartNewGame();
        }

        private void StartNewGame()
        {
            // Rastgele seçilen ili bir değişkene atar.
            selectedCity = Program.GetRandomCity();

            // Rastgele seçilen ilin uzunluğu kadar ipucu oluşturur.
            currentWord = new string('_', selectedCity.Length);

            // Kalan hakları sıfırlar.
            remainingAttempts = maxAttempts;
            UpdateDisplay();
            CreateButtons();
        }

        // Harf listesindeki butonları panele yerleştirir.
        private void CreateButtons()
        {
            panelButtons.Controls.Clear();
            int buttonWidth = 40;
            int buttonHeight = 40;
            int padding = 5;
            int currentX = padding;
            int currentY = padding;

            // Harf listesindeki bütün elemanlar için bir buton oluşturur.
           
            foreach (string letter in letters)
            {
                Button btn = new Button
                {
                    Text = letter,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(currentX, currentY),
                };

                // Eklenilen butona tıklarsak Btn_Click fonksiyonunu çağıracak. 
                btn.Click += Btn_Click;

                //Eklediğim panelin içersine eklenilen butonu ekler.
                panelButtons.Controls.Add(btn);
                
                //Butonun x konumunu en son butonun x değeri ile padding ve buton uzunluğu ile toplayıp belirliyor. 
                currentX += buttonWidth + padding;

                // Bir sonraki buton panelin dışına çıkacaksa alt satıra geçtirir.
                if (currentX + buttonWidth > panelButtons.Width)
                {   
                    currentX = padding;
                    currentY += buttonHeight + padding;
                }
            }
        }

        // Harf butonlarına basıldıktan sonraki olayları içeren fonkiyon.
        // Normalde bütün butonları teker teker koymuştum ama yapay zeka'dan bir öneri alıp böylesi daha mantıklı diye bunu kullanıyorum. 
        // object ile EventArgs'i kullandığımız zaman fonksiyonu çağırırken parametre almasına gerek yok. Mevcut butonun özelliklerini içeriyor.
        private void Btn_Click(object button, EventArgs events)
        {
            // Tıklanılan butonun bütün özelliklerini bir Button türünde bir değişkene atıyoruz.
            Button clickedButton = (Button)button;

            // Bir kere basılan butona bir kez daha basılamaz.
            clickedButton.Enabled = false;

            // Eğer seçilen harf rastgele seçilen ilin içinde bulunuyorsa  
            if (selectedCity.Contains(clickedButton.Text))
            {
                // Kelimeyi günceller.
                UpdateWord(clickedButton.Text[0]);

                // Kelimelerin hepsi doğruysa oyunu kazanır.
                if (currentWord == selectedCity)
                {
                    EndGame(true);
                }
            }

            // Eğer seçilen harf rastgele seçilen ilin içinde bulunmuyorsa bir hak eksilir. Eğer hak kalmamışsa oyun biter.
            else
            {
                remainingAttempts--;
                if (remainingAttempts == 0)
                {
                    EndGame(false);
                }
            }

            //E kranı Günceller
            UpdateDisplay();
        }

        // Kullanıcının seçtiği harf, il ne kadar o harfi içeriyorsa o kadar ip ucu (_) yerine güncellenir.
        private void UpdateWord(char letter)
        {
            for (int i = 0; i < selectedCity.Length; i++)
            {
                if (selectedCity[i] == letter)
                {
                    //İp ucu (_) harfi yerine kullanıcının seçtiği harf ile güncellenir.
                    currentWord = currentWord.Remove(i, 1).Insert(i, letter.ToString());
                }
            }
        }

        // Oyundaki panelde bulunan yazılar ve görselleri yeniler.
        private void UpdateDisplay()
        {
            // adamasmaca resimleri.
            Image[] resimler =
            {
            Properties.Resources.hangman_0,
            Properties.Resources.hangman_1,
            Properties.Resources.hangman_2,
            Properties.Resources.hangman_3,
            Properties.Resources.hangman_4,
            Properties.Resources.hangman_5,
            Properties.Resources.hangman_6,
            Properties.Resources.hangman_7,
            Properties.Resources.hangman_8,
            Properties.Resources.hangman_9,
            Properties.Resources.hangman_10,


            };
        lblWord.Text = string.Join(" ", currentWord.ToCharArray());
            
            // Ekrandaki bulunan resmi kullanıcının yaptığı yanlış sayısına eşit olan resim ile değiştirir.
            int sayac = maxAttempts - remainingAttempts;
            pictureBox1.Image = resimler[sayac];
        }

        // Oyun biterken true değeri alıp biterse tebrikler mesajı, false değeri ile biterse kaybettiniz mesajı çıkarır.
        // Ekstra olarak oyun bittikten sonra tekrar oynamak ister misiniz diye MessageBox çıkarır.
        private void EndGame(bool isWin)
        {
            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }

            string message = isWin
                ? $"Tebrikler! Doğru tahmin ettiniz: {selectedCity}"
                : $"Üzgünüm, kaybettiniz. Doğru cevap: {selectedCity}";

            MessageBox.Show(message, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Yeni oyuna başlamak isterse yeni oyun açar, başlamak istemezse oyunu kapatır.
            if (MessageBox.Show("Yeni bir oyun oynamak ister misiniz?", "Yeni Oyun", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StartNewGame();
            }
            else
            {
                Close();
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}