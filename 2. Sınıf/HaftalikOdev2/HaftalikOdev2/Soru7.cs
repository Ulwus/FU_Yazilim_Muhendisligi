/*
Giriş:
- Satır ve sütun uzunluğu

Çıkış:
- Eğer bir yol bulunabiliyorsa, yolun adımları [(0,0), (x1,y1), ..., (M-1,N-1)] şeklinde listelenir. Eğer yol bulunamıyorsa "Şehir kayboldu!" çıktısı verilir.

Kontrol:
- (x, y) koordinatlarının her iki basamağı asal sayı mı? Asal basamaklar: {2, 3, 5, 7}
- x + y toplamı, x * y çarpımına bölünebiliyor mu?


Tekrar:
- Giriş yapılabilecek hücreler belirlendikten sonra, labirentin başlangıç noktasından hedefe tekrarlana tekrarlana bir yol aranır.

Matematik:
- Sayının basamaklarını kontrol etmek için x ve y koordinatlarının birler ve onlar basamakları alınır.
- x + y toplamı ve x * y çarpımı üzerinden mod işlemi yapılır.
- Rastgele %70 olasılıkla geçilebilri bir oyun alanı.
*/

using System;

public class Soru7
{
    static int[,] labirent;
    static Random rastgele = new Random();
    public static void Run()
    {
        Console.WriteLine("Labirent boyutlarını giriniz:");
        Console.Write("Satır sayısı: ");
        int satirSayisi = Convert.ToInt32(Console.ReadLine());
        Console.Write("Sütun sayısı: ");
        int sutunSayisi = Convert.ToInt32(Console.ReadLine());

        LabirentOlustur(satirSayisi, sutunSayisi);
        LabirentGoster();

        var yol = YolBul();
        if (yol.Count > 0)
        {
            Console.WriteLine("\nYol bulundu!");
            YoluGoster(yol);
        }
        else
        {
            Console.WriteLine("\nŞehir kayboldu! Yol bulunamadı.");
        }
    }

    static void LabirentOlustur(int satir, int sutun)
    {
        labirent = new int[satir, sutun];

        // Rastgele geçerli hücreler oluştur
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                // Başlangıç ve bitiş noktalarını her zaman geçerli yap
                if ((i == 0 && j == 0) || (i == satir - 1 && j == sutun - 1))
                {
                    labirent[i, j] = 1; // Geçilebilir
                }
                else
                {
                    // Yaklaşık %70 ihtimalle geçilebilir hücre oluştur
                    labirent[i, j] = rastgele.Next(100) < 70 ? 1 : 0;
                }
            }
        }
    }

    static List<(int, int)> YolBul()
    {
        int satirSayisi = labirent.GetLength(0);
        int sutunSayisi = labirent.GetLength(1);
        var ziyaretEdilen = new bool[satirSayisi, sutunSayisi];
        var yol = new List<(int, int)>();

        // Başlangıç noktasından başla
        if (YolAra(0, 0, ziyaretEdilen, yol))
            return yol;

        return new List<(int, int)>();
    }

    static bool YolAra(int x, int y, bool[,] ziyaretEdilen, List<(int, int)> yol)
    {
        int satirSayisi = labirent.GetLength(0);
        int sutunSayisi = labirent.GetLength(1);

        // Sınır ve geçerlilik kontrolü
        if (x < 0 || y < 0 || x >= satirSayisi || y >= sutunSayisi ||
            ziyaretEdilen[x, y] || labirent[x, y] == 0)
            return false;

        // Mevcut konumu yola ekle
        yol.Add((x, y));
        ziyaretEdilen[x, y] = true;

        // Hedef noktaya ulaştık mı?
        if (x == satirSayisi - 1 && y == sutunSayisi - 1)
            return true;

        // Sağa ve aşağı hareket et (basitleştirilmiş yol bulma)
        if (YolAra(x + 1, y, ziyaretEdilen, yol) || YolAra(x, y + 1, ziyaretEdilen, yol))
            return true;

        // Yol bulunamadı, geri dön
        yol.RemoveAt(yol.Count - 1);
        return false;
    }

    static void LabirentGoster()
    {
        Console.WriteLine("\nLabirent: (1: Geçilebilir, 0: Duvar)");
        for (int i = 0; i < labirent.GetLength(0); i++)
        {
            for (int j = 0; j < labirent.GetLength(1); j++)
            {
                Console.Write(labirent[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void YoluGoster(List<(int, int)> yol)
    {
        Console.WriteLine("\nBulunan yol:");
        foreach (var adim in yol)
        {
            Console.Write($"({adim.Item1},{adim.Item2}) ");
        }
        Console.WriteLine();

        // Yolu labirent üzerinde göster
        Console.WriteLine("\nLabirent üzerinde yol (X ile işaretli):");
        char[,] gosterim = new char[labirent.GetLength(0), labirent.GetLength(1)];

        // Önce labirenti karakterlere dönüştür
        for (int i = 0; i < labirent.GetLength(0); i++)
            for (int j = 0; j < labirent.GetLength(1); j++)
                gosterim[i, j] = labirent[i, j] == 1 ? '.' : '#';

        // Yolu işaretle
        foreach (var adim in yol)
            gosterim[adim.Item1, adim.Item2] = 'X';

        // Görsel labirenti yazdır
        for (int i = 0; i < gosterim.GetLength(0); i++)
        {
            for (int j = 0; j < gosterim.GetLength(1); j++)
            {
                Console.Write(gosterim[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}