using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form2 : Form
{
    // Oyuncu isimleri ve oyun alanı boyutu
    string birinciOyuncu;
    string ikinciOyuncu;
    int oyunAlani;

    // Oyun alanını tutan matris (0: boş, 1: X, 2: O)
    int[,] alan;

    // Aktif oyuncuyu belirtir (1: birinci oyuncu, 2: ikinci oyuncu)
    int aktifOyuncu = 1;

    // Oyun paneli
    Panel oyunPanel;

    // Constructor: Form2'yi başlatır, oyuncu isimlerini ve oyun alanı boyutunu alır
    public Form2(string birinciOyuncu, string ikinciOyuncu, int oyunAlani)
    {
        InitializeComponent();

        // Oyuncu isimlerini ve oyun alanı boyutunu ayarlama
        this.birinciOyuncu = birinciOyuncu;
        this.ikinciOyuncu = ikinciOyuncu;
        this.oyunAlani = oyunAlani;

        // Etiketlere oyuncu isimlerini ekleme
        label1.Text = $"1. Oyuncu: {birinciOyuncu}";
        label2.Text = $"2. Oyuncu: {ikinciOyuncu}";

        // Oyun alanını oluşturma
        alan = oyunAlaniOlustur(oyunAlani);

        // Oyun panelini oluşturma
        oyunPanelOlustur();
    }

    // Oyun panellerini (butonları) oluşturur
    private void oyunPanelOlustur()
    {
        // Oyun panelini oluşturma
        oyunPanel = new Panel
        {
            Location = new Point(50, 50), // Panelin ekrana yerleştirileceği konum
            Size = new Size(400, 400), // Panelin boyutu
            BorderStyle = BorderStyle.FixedSingle // Panelin kenarlığı
        };
        this.Controls.Add(oyunPanel);

        // Buton boyutlarını dinamik olarak hesapla
        int butonBoyutu = oyunPanel.Width / oyunAlani;

        // Oyun alanı boyutuna göre butonları yerleştir
        for (int i = 0; i < oyunAlani; i++)
        {
            for (int j = 0; j < oyunAlani; j++)
            {
                Button btn = new Button
                {
                    Width = butonBoyutu,
                    Height = butonBoyutu,
                    Location = new Point(j * butonBoyutu, i * butonBoyutu),
                    Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                    Tag = new Point(i, j) // Konum bilgisi için butona Tag ekleyelim
                };
                btn.Click += Btn_Click; // Buton tıklandığında tetiklenecek olay
                oyunPanel.Controls.Add(btn); // Panel üzerine butonu ekle
            }
        }
    }

    // Buton tıklandığında gerçekleşen işlem
    private void Btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn == null) return;

        Point konum = (Point)btn.Tag;
        int x = konum.X;
        int y = konum.Y;

        // Oyuncunun hamlesini yerleştir
        TasYerleştir(x, y, btn);
    }

    // Taş yerleştirme işlemi
    public void TasYerleştir(int indexX, int indexY, Button btn)
    {
        // Eğer hücre doluysa, oyuncuya uyarı ver
        if (alan[indexX, indexY] != 0)
        {
            MessageBox.Show("Bu hücre dolu!");
            return;
        }

        // Oyuncunun taşını yerleştir
        alan[indexX, indexY] = aktifOyuncu;
        btn.Text = aktifOyuncu == 1 ? "X" : "O"; // Oyuncunun taşını butona yaz
        btn.Enabled = false; // Butonu devre dışı bırak

        // Kazanma kontrolü
        if (oyunBitir(alan, indexX, indexY))
        {
            // Kazananı belirle
            string kazanan = aktifOyuncu == 1 ? birinciOyuncu : ikinciOyuncu;
            MessageBox.Show($"Tebrikler, {kazanan} kazandı!"); // Kazananı ekrana yazdır
            Close(); // Oyunu bitir
            return;
        }

        // Sıra değiştir
        aktifOyuncu = aktifOyuncu == 1 ? 2 : 1;
    }

    // Oyun alanını oluşturur (başlangıçta tüm hücreler boş)
    public int[,] oyunAlaniOlustur(int oyunAlani)
    {
        int[,] alan = new int[oyunAlani, oyunAlani];
        for (int i = 0; i < oyunAlani; i++)
        {
            for (int j = 0; j < oyunAlani; j++)
            {
                alan[i, j] = 0; // 0: Boş hücre
            }
        }
        return alan;
    }

    // Kazanma durumu kontrolü
    public bool oyunBitir(int[,] alan, int indexX, int indexY)
    {
        int hedef = 3; // Kazanmak için gereken ardışık taş sayısı
        int oyuncu = alan[indexX, indexY];
        if (oyuncu == 0) return false; // Eğer taş yerleştirilmemişse, kazanma kontrolü yapılamaz

        // Her bir doğrultuyu ayrı ayrı kontrol et
        if (oyunBitirRecursive(alan, indexX, indexY, -1, 0, oyuncu) + oyunBitirRecursive(alan, indexX, indexY, 1, 0, oyuncu) + 1 >= hedef)
            return true; // Dikey kontrol
        if (oyunBitirRecursive(alan, indexX, indexY, 0, -1, oyuncu) + oyunBitirRecursive(alan, indexX, indexY, 0, 1, oyuncu) + 1 >= hedef)
            return true; // Yatay kontrol
        if (oyunBitirRecursive(alan, indexX, indexY, -1, -1, oyuncu) + oyunBitirRecursive(alan, indexX, indexY, 1, 1, oyuncu) + 1 >= hedef)
            return true; // Sol yukarıdan sağ aşağı çapraz
        if (oyunBitirRecursive(alan, indexX, indexY, -1, 1, oyuncu) + oyunBitirRecursive(alan, indexX, indexY, 1, -1, oyuncu) + 1 >= hedef)
            return true; // Sağ yukarıdan sol aşağı çapraz

        return false; // Hiçbir yönde kazanan yok
    }

    // Yön bazında ardışık taşları sayan yardımcı metot
    private int oyunBitirRecursive(int[,] alan, int indexX, int indexY, int yonX, int yonY, int oyuncu)
    {
        int oyunBoyutu = alan.GetLength(0);
        int yeniX = indexX + yonX;
        int yeniY = indexY + yonY;

        // Taşın dışarıda olma durumunu kontrol et
        if (yeniX < 0 || yeniX >= oyunBoyutu || yeniY < 0 || yeniY >= oyunBoyutu)
            return 0;

        // Eğer aynı oyuncunun taşına rastlanırsa, bir sonraki hücreyi kontrol et
        if (alan[yeniX, yeniY] == oyuncu)
            return 1 + oyunBitirRecursive(alan, yeniX, yeniY, yonX, yonY, oyuncu);

        return 0;
    }
}
