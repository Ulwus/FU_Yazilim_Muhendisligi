/*
Giriş:
- Kullanıcıdan, 0 girilene kadar sayı istenir.

Çıkış:
- Medyan ve ortalama değerleri ekrana yazdırılır.
- Girilen sayıların ortalama ve medyanı hesaplanır ve ekrana gösterilir.

Kontrol:
- Kullanıcının girdiği sayı 0 mı? Eğer 0 ise döngü sonlanır.
- Liste eleman sayısı tek mi çift mi?

Tekrar:
- Sayı girişi döngüsü, kullanıcı 0 girene kadar tekrar eder.
- Listedeki tüm elemanların toplamı için döngü kurulur.
- Liste sıralandıktan sonra medyan değeri bulunur.

Matematik:
- Ortalama hesaplama: toplam / uzunluk
- Medyan hesaplama: 
    - Eğer eleman sayısı çift ise, ortadaki iki elemanın ortalaması medyan olarak alınır.
    - Eğer eleman sayısı tek ise, ortadaki eleman medyan olarak alınır.
*/

using System;

public class Soru2
{
    public static void Run()
    {
        int sayi;
        int toplam = 0; // Sayıların toplamını tutar
        double medyan = 0; // Medyan değerini tutar
        List<int> liste = new List<int>(); // Kullanıcıdan alınan sayılar listesi

        // Sayı girişi döngüsü
        while (true)
        {
            Console.WriteLine("Lütfen sayı giriniz (0 yazılana kadar listeye eklenecek!): ");
            sayi = Convert.ToInt32(Console.ReadLine());

            // Eğer sayı 0 ise döngüyü sonlandır
            if (sayi == 0)
            {
                break;
            }

            // 0 değilse listeye ekle
            liste.Add(sayi);
        }

        int uzunluk = liste.Count; // Listedeki eleman sayısı

        // Listedeki tüm sayıların toplamını hesapla
        for (int i = 0; i < liste.Count; i++)
        {
            toplam += liste[i];
        }

        // Listedeki elemanları sıralıyoruz, böylece medyan hesaplaması doğru olur
        liste.Sort();

        // Medyan hesaplaması
        if (uzunluk % 2 == 0)
        {
            // Eleman sayısı çiftse, ortadaki iki elemanın ortalamasını al
            medyan = (liste[uzunluk / 2] + liste[uzunluk / 2 + 1]) / 2.0;
        }
        else
        {
            // Eleman sayısı tekse, ortadaki eleman medyandır
            medyan = liste[uzunluk / 2];
        }

        // Ortalama hesaplaması ve ekrana yazdırma
        Console.WriteLine($"Medyan: {medyan}, Ortalama: {toplam / (double)uzunluk}");
    }
}
