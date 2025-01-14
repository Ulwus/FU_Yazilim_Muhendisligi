/*
Giriş:
- Kullanıcıdan sayı dizisi alınır

Çıkış:
- Kapıyı açmak için gerekli doğru kombinasyonu sağlayan işlem dizisi veya "Kapı açılamadı" mesajı.

Kontrol:
- Sayı pozitif mi?
- Her sayı başka bir sayıya bağlanmak zorundadır.
- Operatörler sadece toplama (+), çıkarma (-), çarpma (*) ve bölme (/) olabilir.
- İki operatör ardışık olarak eklenemez.
- İşlem sonucu her zaman sıfırdan büyük olmalıdır.

Tekrar:
- Tüm kombinasyonları deneyerek işlemi oluşturan algoritma, verilen kısıtlamalara uyacak şekilde sonuç sıfırdan büyük olduğunda diziyi geçerli kabul eder

Matematik:
- İşlemler soldan sağa yapılır.

*/

using System;

public class Soru10
{
    public static void Run()
    {
        // Kullanıcıdan sayıları al
        int[] sayilar = SayilariAl();

        // Şifreyi çözmeyi dene
        if (!OperatorDizisiBul(sayilar))
        {
            Console.WriteLine("Kapı açılamadı.");
        }
    }

    static int[] SayilariAl()
    {
        Console.Write("Kaç adet sayı gireceksiniz?: ");
        int adet = Convert.ToInt32(Console.ReadLine());

        int[] sayilar = new int[adet];
        for (int i = 0; i < adet; i++)
        {
            Console.Write($"{i + 1}. sayıyı girin: ");
            sayilar[i] = Convert.ToInt32(Console.ReadLine());
        }
        return sayilar;
    }

    static bool OperatorDizisiBul(int[] sayilar)
    {
        char[] operatorler = { '+', '-', '*', '/' };
        return OperatorleriDene(sayilar, operatorler, 1, sayilar[0].ToString(), sayilar[0]);
    }

    static bool OperatorleriDene(int[] sayilar, char[] operatorler, int index, string ifade, int sonuc)
    {
        // Tüm sayılar işlendiyse sonucu kontrol et
        if (index == sayilar.Length)
        {
            if (sonuc > 0)
            {
                Console.WriteLine($"Kapı açıldı! Doğru kombinasyon: {ifade} = {sonuc}");
                return true;
            }
            return false;
        }

        // Her operatörü dene
        foreach (char op in operatorler)
        {
            string yeniIfade = $"{ifade} {op} {sayilar[index]}";
            int yeniSonuc = IslemYap(sonuc, sayilar[index], op);

            // Sonuç pozitifse devam et
            if (yeniSonuc > 0 && OperatorleriDene(sayilar, operatorler, index + 1, yeniIfade, yeniSonuc))
            {
                return true;
            }
        }
        return false;
    }

    static int IslemYap(int a, int b, char op)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': return b != 0 ? a / b : int.MinValue;
            default: return 0;
        }
    }
}