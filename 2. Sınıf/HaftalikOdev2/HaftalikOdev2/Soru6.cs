/*
Giriş:
- Kullanıcıdan başlangıç tarihi alınır ve gün-ay-yıl formatında ayrıştırılır.
- Kullanıcı tarafından girilen başlangıç tarihi bir `DateTime` nesnesine dönüştürülür.

Çıkış:
- Belirlenen koşullara uyan tarihler ekrana yazdırılır.
- Koşulları sağlayan tarihler listeye eklenir ve döngü sonunda bu liste ekrana gösterilir.

Kontrol:
- Tarih koşulları `kontrol` fonksiyonunda sağlanır:
    - `gun` değeri asal mı?
    - `ay` değeri çift mi?
    - `yil` toplamı belirli bir değerden küçük mü?

Tekrar:
- Başlangıç tarihinden itibaren belirtilen koşullara uyan tarihleri bulmak için günlük olarak döngü tekrar eder.
- Döngü 31 Aralık 2999 tarihine kadar devam eder.

Matematik:
- `asalMi` fonksiyonu gün değerinin asal olup olmadığını kontrol eder.
- `ciftMi` fonksiyonu ayın rakamlarının toplamının çift olup olmadığını kontrol eder.
- `kucukMu` fonksiyonu yılın rakamlarının toplamının belirli bir şartı sağlayıp sağlamadığını kontrol eder.
*/

using System;

public class Soru6
{
    public static void Run()
    {
        // Kullanıcıdan başlangıç tarihi alınır
        Console.WriteLine("Şimdiki Tarih: ");
        string date = Console.ReadLine();

        // Girilen tarih "gün-ay-yıl" formatında int diziye dönüştürülür
        int[] lastDate = Array.ConvertAll(date.Split('-'), int.Parse);
        int gun = lastDate[0];
        int ay = lastDate[1];
        int yil = lastDate[2];

        // Uygun tarihler için bir liste oluşturulur
        List<string> uygunTarihler = new List<string>();

        // Kullanıcıdan alınan tarih bir DateTime nesnesine dönüştürülür
        DateTime simdikiTarih = new DateTime(yil, ay, gun);

        // Döngünün sona ereceği tarih belirlenir
        DateTime sonTarih = new DateTime(2999, 12, 31);

        // Belirtilen tarihe kadar döngü devam eder
        while (simdikiTarih <= sonTarih)
        {
            int day = simdikiTarih.Day;
            int month = simdikiTarih.Month;
            int year = simdikiTarih.Year;

            // Koşulları sağlayan tarihler listeye eklenir
            if (kontrol(day, month, year))
            {
                uygunTarihler.Add(simdikiTarih.ToString("dd-MM-yyyy"));
            }

            // Tarih bir gün ileri alınır
            simdikiTarih = simdikiTarih.AddDays(1);
        }

        // Koşullara uyan tarihler ekrana yazdırılır
        Console.WriteLine("Koşullara uyan tarihler:");
        foreach (var tarih in uygunTarihler)
        {
            Console.WriteLine(tarih);
        }
    }

    // Tarih koşullarını kontrol eden fonksiyon
    public static bool kontrol(int gun, int ay, int yil)
    {
        // Gün asal ve ay rakamları toplamı çift ve yıl koşulları sağlanıyorsa true döner
        if (asalMi(gun) && ciftMi(ay) && kucukMu(yil))
        {
            return true;
        }
        return false;
    }

    // Günün asal olup olmadığını kontrol eden fonksiyon
    public static bool asalMi(int gun)
    {
        // 2'den küçük sayılar asal olamaz
        if (gun < 2) return false;

        // Gün sayısının asal olup olmadığı kontrol edilir
        for (int i = 2; i < gun / 2; i++)
        {
            if (gun % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    // Ay rakamlarının toplamının çift olup olmadığını kontrol eden fonksiyon
    public static bool ciftMi(int ay)
    {
        int onlar = ay / 10; // Onlar basamağı
        int birler = ay % 10; // Birler basamağı

        // Rakamlar toplamı çift değilse false döner
        if ((onlar + birler) % 2 != 0)
        {
            return false;
        }
        return true;
    }

    // Yılın rakamları toplamının belirli bir şartı sağlama durumunu kontrol eden fonksiyon
    public static bool kucukMu(int yil)
    {
        int binler = yil / 1000; // Binler basamağı
        int yuzler = (yil / 100) % 10; // Yüzler basamağı
        int onlar = (yil / 10) % 10; // Onlar basamağı
        int birler = yil % 10; // Birler basamağı
        int toplam = binler + yuzler + onlar + birler; // Basamakların toplamı hesaplanır

        // Eğer yıl 4'e bölündüğünde çıkan sonuç toplamdan küçükse false döner
        if ((yil / 4) < toplam)
        {
            return false;
        }
        return true;
    }
}
    