using System;  

class Program
{
    // Programın başlangıç noktası olan Main metodu.
    static void Main()
    {
        // Kullanıcıdan bir sayı girmesini istiyoruz.
        Console.WriteLine("Sayı Giriniz");
        int sayi = int.Parse(Console.ReadLine()); 

        // Girilen sayıya kadar olan asal sayıların toplamını hesaplayan asal fonksiyonu çağrıp ekrana yazmasını sağlar.
        Console.WriteLine(asal(sayi));

        // Program sonlandıktan sonra kapanıyor. Bunu engellemek için kullanıcıdan bir şeye basmasını istiyoruz.
        Console.ReadLine();
    }

    // Kullanıcının girdiği sayıya kadar olan asal sayıların toplamını hesaplayan fonksiyon.
    static int asal(int x)
    {

        // Asal sayıların toplamını tutmak için bir değişken.
        int toplam = 0;  

        // 0'dan x'e kadar olan sayıları kontrol ediyoruz.
        for (int i = 0; i < x; i++)
        {
            // Eğer i sayısı asal ise, toplam değişkenine ekliyoruz. asalMi fonksiyonu ile kontrol ediyoruz.
            if (asalMi(i))  
            {
                // Asal olan sayıyı toplam değişkenine ekliyoruz.
                toplam += i;  
            }
        }

        // Toplam değerini geri döndürüyoruz.
        return toplam;  
    }

    // Verilen sayının asal olup olmadığını kontrol eden fonksiyon.
    static Boolean asalMi(int x)
    {
        // Eğer sayı 2'den küçükse asal sayı değildir.
        if (x < 2)
        {
            return false;  
        }

        // 2'den başlayarak verilen sayıya kadar olan tüm sayılarla bölen kontrolü yapıyoruz.
        for (int i = 2; i < x; i++)
        {
            // Eğer x, i'ye tam bölünüyorsa asal değildir.
            if (x % i == 0)
            {
                return false;  
            }
        }

        // Eğer hiç bir bölen bulunamazsa, bu sayı asaldır. Bundan dolayı true döndürüyoruz.
        return true;  
    }
}
