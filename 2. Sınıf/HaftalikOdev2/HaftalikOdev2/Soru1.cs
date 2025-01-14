/*

Giriş:
- Kullanıcıdan dizi uzunluğu alınır.
- Kullanıcıdan liste elemanları alınır.
- Kullanıcıdan bir sayı istenilir.

Çıkış:
- Kullanıcıdan alınan sayı listede bulunuyorsa, hem listedeki konumu hem de işlemler çıktı alınır.
- Kullanıcıdan alınan sayı listede bulunmuyorsa, bulunmadığına dair çıktı alınır.

Kontrol:
- Listedeki j indisdeki değeri i indisdeki değerinden büyük mü?
- Seçilen sayı orta değere mi eşit?
- Seçilen sayı orta değerden küçük mü?
- Seçilen sayı orta değerden büyük mü?

Tekrar:
- Liste tekrarlana tekrarlana karşılaştırmalar ile sıraya konulur.
- Liste adım adım ekrana yazdırılır.
- Seçilen sayı bulunmaya çalışılırken her adımda baslangıç, bitiş ve orta değerleri değiştirilir.

Matematik:
- Orta değer bulunması
- İkili arama algoritması.


*/



using System;

public class Soru1
{
    public static void Run()
    {
        // Kullanıcıdan dizi uzunluğu alınıyor
        Console.WriteLine("Kaç Adet Sayı İstersiniz");
        int uzunluk = Convert.ToInt32(Console.ReadLine());
        int temp = 0;

        // Girilen uzunluğa göre dizi oluşturuluyor
        int[] sayilar = new int[uzunluk];

        // Dizi elemanları kullanıcıdan alınıyor
        for (int i = 0; i < uzunluk; i++)
        {
            Console.WriteLine($"{i + 1}. Sayıyı Giriniz");
            sayilar[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Diziyi sıralamak için iç içe döngülerle basit bir sıralama (bubble sort) yapılıyor
        for (int i = 0; i < uzunluk; i++)
        {
            for (int j = 0; j < uzunluk; j++)
            {
                if (sayilar[i] < sayilar[j])
                {
                    // Sayıları yer değiştir
                    temp = sayilar[i];
                    sayilar[i] = sayilar[j];
                    sayilar[j] = temp;
                }
            }
        }

        // Sıralanmış diziyi ekrana yazdırma
        for (int i = 0; i < uzunluk; i++)
        {
            Console.Write(sayilar[i] + " ");
        }

        // Kullanıcıdan aranacak sayı isteniyor
        Console.WriteLine("Aranılan Sayıyı Seçiniz");
        int aranan = Convert.ToInt32(Console.ReadLine());

        // Binary search algoritması için başlangıç ve bitiş indexleri tanımlanıyor
        int baslangic = 0;
        int bitis = uzunluk - 1;
        int orta;

        // İkili arama başlatılıyor
        while (baslangic <= bitis)
        {
            // Orta index hesaplanıyor
            orta = (baslangic + bitis) / 2;

            // Aranan sayı ortadaki sayıya eşit mi?
            if (aranan == sayilar[orta])
            {
                // Aranan sayı bulundu ve indexi yazdırılıyor
                Console.WriteLine($"Sayı bulundu. Sayı listede: {orta + 1}. sırada");
                return;
            }

            // Aranan sayı ortadaki sayıdan küçükse, arama aralığını daralt
            if (aranan < sayilar[orta])
            {
                bitis = orta - 1;
                Console.WriteLine("Solda"); // Yön gösteriliyor
                continue;
            }

            // Aranan sayı ortadaki sayıdan büyükse, arama aralığını daralt
            if (aranan > sayilar[orta])
            {
                baslangic = orta + 1;
                Console.WriteLine("Sağda"); // Yön gösteriliyor
                continue;
            }
        }

        // Aranan sayı bulunamadığında ekrana yazdır
        Console.WriteLine("Sayı Listede Yok!");
    }
}
        
















