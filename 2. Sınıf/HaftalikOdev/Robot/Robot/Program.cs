
// C# dilinde hem bilgim hem de zamanımız kısıtlı olduğu için async yapılarının C# dilinde nasıl kullanıldığını bilmiyorum. Bu yüzden async yapı kullanmadım.

using System;
class Program
{
    // Ana programın başlangıç noktası olan Main metodu
    static void Main()
    {
        // Kullanıcıdan oyun alanı boyutunu girmesini istiyoruz.
        Console.WriteLine("Oyun alanı boyutunu girin: ");
        int boyut = Convert.ToInt32(Console.ReadLine());

        // Oyun alanını temsil eden boyut x boyut bir matris (iki boyutlu dizi) oluşturuyoruz ve oluşan matrise 0 ve 1 olmak üzere rastgele değer atıyoruz.
        int[,] oyunAlani = new int[boyut, boyut];
        Random rnd = new Random();

        // Matrisin her bir hücresine rastgele 0 veya 1 ataması yapıyoruz.
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                oyunAlani[i, j] = rnd.Next(0, 2);
            }
        }

        // Oluşturulan matrisi ekrana yazdırıyoruz.
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
               Console.Write(oyunAlani[i, j] + " ");
            }
            Console.WriteLine();
        }


        // Robotun başlangıç konumunu (0, 0) olarak ayarlıyoruz.
        int robot1X = 0, robot1Y = 0;

        // Async yapı kullanmış olsaydık hepsini kullanırdık.
        int robot2X = 0, robot2Y = 0;
        int robot3X = 0, robot3Y = 0;

        // Robotun bulunduğu noktadaki ve çevresindeki kurtarılan düğüm sayısını hesaplayan fonksiyonu çağırıyoruz.
        int kurtarilanDugum = KurtarilanDugumSayisi(oyunAlani, robot1X, robot1Y);

        // Kurtarılan düğüm sayısını ekrana yazdırıyoruz.
        Console.WriteLine($"Kurtarılan düğüm sayısı: {kurtarilanDugum}");
    }
    // KurtarilanDugumSayisi fonksiyonu, robotun bulunduğu konumda ve komşu hücrelerde kurtarılan (1 olan) düğüm sayısını hesaplar.
    static int KurtarilanDugumSayisi(int[,] oyunAlani, int robotX, int robotY)
    {
        // Kurtarılan düğüm sayısını tutmak için bir değişken oluşturuyoruz.
        int kurtarilanSayisi = 0;
        // Oyun alanının boyutunu alıyoruz.
        int boyut = oyunAlani.GetLength(0);

        // Robotun sınır kontrolünü ve kurtarılan düğüm kontrolünü yapıyoruz. Geçersiz konum veya zaten kurtarılmış düğüm var ise 0 döndürüyoruz.
        if (robotX < 0 || robotX >= boyut || robotY < 0 || robotY >= boyut || oyunAlani[robotX, robotY] == 0)
        {
            return 0; 
        }

        // Düğümü kurtarıyoruz, kurtarılan düğüm sayısını bir arttırıyoruz ve oyun alanındaki değeri 0 yapıyoruz (kurtarıldı diye).
        kurtarilanSayisi++;
        oyunAlani[robotX, robotY] = 0;

        // Rekürsif olarak komşu hücreleri kontrol ediyoruz.

        // Yukarı yönde kurtarma işlemi yapıyoruz.
        kurtarilanSayisi += KurtarilanDugumSayisi(oyunAlani, robotX - 1, robotY);

        // Sağ yönde kurtarma işlemi yapıyoruz.
        kurtarilanSayisi += KurtarilanDugumSayisi(oyunAlani, robotX, robotY + 1); 

        // Aşağı yönde kurtarma işlemi yapıyoruz.
        kurtarilanSayisi += KurtarilanDugumSayisi(oyunAlani, robotX + 1, robotY); 

        // Sol yönde kurtarma işlemi yapıyoruz.
        kurtarilanSayisi += KurtarilanDugumSayisi(oyunAlani, robotX, robotY - 1); 

        // Kurtarılan düğüm sayısını geri döndürüyoruz.
        return kurtarilanSayisi;
    }
}