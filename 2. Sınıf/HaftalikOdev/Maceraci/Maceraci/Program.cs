// Şuanda bulunan mevcut kod sadece tek bir yol bulup onu en kısa yol olarak kabul etmekte. Bütün yollar arasından en kısa olanı bu kod şuanki haliyle vermiyor.


using System;  
public class Program
{
    // Ana programın başlangıç noktası olan Main metodu
    static void Main()
    {
        // Kullanıcıdan labirent boyutunu girmesini istiyoruz.
        Console.WriteLine("Oyun Boyutunu Giriniz: ");
        int boyut = int.Parse(Console.ReadLine());

        // Boyut x Boyut şeklinde bir iki boyutlu dizi (matris) oluşturuyoruz. Bu matris, labirenti temsil edecek.
        int[,] matris = new int[boyut, boyut];

        // Rastgele sayı üretmek için Random sınıfı kullanılıyor.
        Random rnd = new Random();

        // Matrisin her bir hücresi için rastgele bir değer ataması yapılacak. 0 veya 1 değerleri kullanılıyor.
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                matris[i, j] = rnd.Next(0, 2);
            }
        }

        // Başlangıç noktası ve bitiş noktası 1'e ayarlanıyor.
        matris[0, 0] = 1;  
        matris[boyut - 1, boyut - 1] = 1; 

        // Matrisin oluşturulan halini ekrana yazdırıyoruz.
        Console.WriteLine("Oluşturulan Labirent:");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(matris[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Ziyaret edilen hücreleri takip etmek için boyut x boyut bir bool matris oluşturuyoruz.
        bool[,] ziyaretEdildi = new bool[boyut, boyut];

        // En kısa adım sayısını hesaplayan fonksiyonu çağırıyoruz. Başlangıç noktası (0,0).
        int adimSayisi = EnKisaAdimSayisi(matris, boyut, 0, 0, ziyaretEdildi);

        // Eğer adım sayısı -1 ise bir yol bulunamadı, aksi takdirde yol bulundu ve kaç adım sürdüğünü yazdırıyoruz.
        if (adimSayisi == -1)
        {
            Console.WriteLine("Yol Bulunamadı");
        }
        else
        {
            Console.WriteLine($"En kısa yol {adimSayisi} adımda bulundu.");
        }
    }

    // EnKisaAdimSayisi fonksiyonu, verilen matriste (i,j) yani matrisin en sol üst noktasından bitiş noktasına (n-1,n-1) yani matrisin en sağ altına kadar en kısa yolu bulmayı amaçlar.
    static int EnKisaAdimSayisi(int[,] matris, int boyut, int i, int j, bool[,] ziyaretEdildi)
    {
        // Koordinatlar matrisin dışına çıkıyor mu? ve
        // Hücre daha önce ziyaret edilmiş mi? kontrolleri yapılıyor.
        if (i < 0 || i >= boyut || j < 0 || j >= boyut || matris[i, j] == 0 || ziyaretEdildi[i, j])
        {
            return -1;  // Eğer bu koşullardan biri sağlanıyorsa bu yol geçersizdir.
        }

        // Eğer (i,j) noktası bitiş noktasıysa yani matrisin en sağ altıysa, yolu bulmuşuz demektir, bu yüzden 0 döndürürüz.
        if (i == boyut - 1 && j == boyut - 1)
        {
            return 0;
        }

        // Bu noktayı ziyaret ettiğimizi işaretliyoruz.
        ziyaretEdildi[i, j] = true;

        // Aşağı hareket etmeyi deniyoruz.
        int asagi = EnKisaAdimSayisi(matris, boyut, i + 1, j, ziyaretEdildi);
        // Eğer aşağı doğru geçerli bir yol bulunmuşsa, adım sayısını bir artırarak döneriz.
        if (asagi != -1)
        {
            return asagi + 1;
        }

        // Sağa hareket etmeyi deniyoruz.
        int sag = EnKisaAdimSayisi(matris, boyut, i, j + 1, ziyaretEdildi);
        if (sag != -1)
        {
            return sag + 1;
        }

        // Yukarı hareket etmeyi deniyoruz.
        int yukari = EnKisaAdimSayisi(matris, boyut, i - 1, j, ziyaretEdildi);
        if (yukari != -1)
        {
            return yukari + 1;
        }

        // Sola hareket etmeyi deniyoruz.
        int sol = EnKisaAdimSayisi(matris, boyut, i, j - 1, ziyaretEdildi);
        if (sol != -1)
        {
            return sol + 1;
        }

        // Eğer tüm olasılıklar tükendiyse ve bir yol bulunmadıysa, bu noktayı tekrar ziyaret edilmemiş olarak işaretliyoruz.
        ziyaretEdildi[i, j] = false;

        // Geçerli bir yol bulunamazsa -1 döneriz.
        return -1;
    }
}
