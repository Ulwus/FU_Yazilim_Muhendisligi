/*
Giriş:
- Kullanıcıdan, 0 girilene kadar sayı istenir.

Çıkış:
- Varsa ardaşık sayı gruplarının başlangıç ve bitiş değeri ekrana yazdırılır.

Kontrol:
- Listedeki mevcut konumdaki sayı ile bir önceki konumdaki sayı arasındaki fark 1 mi?


Tekrar:
- Ardaşık sayı gruplarılarının uzunluğunu elde edene kadar tekrar eder.
- Ardaşık sayı grupları araştırılması için uzunluk ile mevcut indis değeri toplanır. Serinin sonuna ulaşana kadar tekrar eder.

Matematik:
- Listedeki mevcut konumdaki sayı ile bir önceki konumdaki sayı arasındaki fark 1 ise birbiri ile ardaşıktır.
*/

using System;

public class Soru3
{
    public static void Run()
    {
        List<int> sayilar = new List<int>(); // Kullanıcının girdiği sayılar listesi
        int sayi;

        // Kullanıcıdan sayı al, 0 girilene kadar devam et
        while (true)
        {
            Console.WriteLine("Sayı Giriniz");
            sayi = Convert.ToInt32(Console.ReadLine()); // Girilen sayıyı tam sayıya çevir

            if (sayi == 0) // 0 girildiğinde döngüden çık
            {
                break;
            }

            sayilar.Add(sayi); // Sayıyı listeye ekle
        }

        // Liste içindeki ardışık grupları bul ve ekrana yazdır
        for (int i = 0; i < sayilar.Count - 1; i++)
        {
            // Ardışık bir grup bulursa
            if (kontrol(sayilar, i) > 0)
            {
                Console.Write($" {sayilar[i]}-{sayilar[i + kontrol(sayilar, i)]}"); // Başlangıç ve bitiş değerini yazdır
                i += kontrol(sayilar, i); // İndeksi ardışık grubun sonuna kadar atlat
            }
        }
    }

    // Ardışık sayıları belirlemek için kontrol fonksiyonu
    public static int kontrol(List<int> sayilar, int indis)
    {
        int tekrar = 0; // Ardışık sayıları saymak için sayaç

        // İndisten itibaren ardışık olan sayıları say
        while (indis + tekrar < sayilar.Count - 1 && sayilar[indis + tekrar + 1] - sayilar[indis + tekrar] == 1)
        {
            tekrar++; // Eğer ardışık sayı varsa sayaç bir artırılır
        }

        return tekrar; // Ardışık sayıların sayısını döndür
    }
}
