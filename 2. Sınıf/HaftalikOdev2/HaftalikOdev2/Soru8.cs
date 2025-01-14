/*
Giriş:
- Kullanıcıdan şifreli mesaj alınır.

Çıkış:
- Çözülmüş orijinal mesaj.

Kontrol:
- Mesajdaki her karakterin ASCII değerine göre işlem yapılacaktır.
- Fibonacci serisi ile pozisyona göre çarpım yapılacaktır.
- Pozisyonun asallığına göre mod işlemi yapılacaktır (asal ise mod 100, değilse mod 256).

Tekrar:
- Mesajdaki her karakter için bu işlemler çözüm adımlarına göre ters çevrilerek uygulanacaktır. 

Matematik:
- Fibonacci serisi pozisyona göre hesaplanır.
- Pozisyon asal mı değil mi kontrol edilir.
- Mod 100 veya 256 işlemleri uygulanır.
- Tüm işlemler ters çevrilir ve orijinal ASCII değeri bulunur.
*/

using System;

public class Soru8
{
    public static void Run()
    {
        // Kullanıcıdan şifreli mesajı al
        Console.WriteLine("Şifreli mesajı giriniz:");
        string sifreliMesaj = Console.ReadLine();

        // Şifreyi çöz ve göster
        string orijinalMesaj = MesajCoz(sifreliMesaj);
        Console.WriteLine("Orijinal Mesaj: " + orijinalMesaj);
    }

    // Mesajı çözmek için kullanılan fonksiyon
    public static string MesajCoz(string sifreliMesaj)
    {
        var orijinalMesaj = "";
        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            int karakterKodu = (int)sifreliMesaj[i];
            int pozisyon = i + 1;
            int fibonacciDegeri = FibonacciHesapla(pozisyon);
            // Pozisyon asal mı kontrol et
            int modDegeri = AsalMi(pozisyon) ? 100 : 256;
            // Şifre çözme adımları
            int cozulmusKarakterKodu = ModVeFibonacciTersCevir(karakterKodu, fibonacciDegeri, modDegeri);
            orijinalMesaj += (char)cozulmusKarakterKodu;
        }
        return orijinalMesaj;
    }

    // Fibonacci değerini hesaplayan fonksiyon
    private static int FibonacciHesapla(int n)
    {
        if (n <= 0) return 0;
        if (n == 1 || n == 2) return 1;
        int a = 1, b = 1, sonuc = 0;
        for (int i = 3; i <= n; i++)
        {
            sonuc = a + b;
            a = b;
            b = sonuc;
        }
        return sonuc;
    }

    // Asal sayı kontrolü yapan fonksiyon
    private static bool AsalMi(int sayi)
    {
        if (sayi <= 1) return false;
        if (sayi <= 3) return true;
        if (sayi % 2 == 0 || sayi % 3 == 0) return false;
        for (int i = 5; i * i <= sayi; i += 6)
            if (sayi % i == 0 || sayi % (i + 2) == 0)
                return false;
        return true;
    }

    // Şifre çözme işlemlerini yapan fonksiyon
    private static int ModVeFibonacciTersCevir(int sifreliDeger, int fibonacciDegeri, int modDegeri)
    {
        int orijinalAscii = sifreliDeger;
        // Negatif değerler için düzeltme
        while (orijinalAscii < 0)
            orijinalAscii += modDegeri;

        // Olası tüm değerleri kontrol et
        for (int i = orijinalAscii; i < modDegeri * 2; i += modDegeri)
        {
            int kontrolDegeri = i * fibonacciDegeri;
            if ((kontrolDegeri % modDegeri) == sifreliDeger % modDegeri)
            {
                orijinalAscii = i;
                break;
            }
        }
        return orijinalAscii;
    }
}