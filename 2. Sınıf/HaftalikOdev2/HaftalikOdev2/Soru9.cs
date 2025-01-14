/*
Giriş:
- Matris uzunluğu alınır.
- Kullanıcıdan (N,N) matris alınır.

Çıkış:
- En az enerji harcanarak ulaşılabilecek toplam enerji maliyeti ve bu maliyeti sağlayan yol.

Kontrol:
- Madenciler sadece sağa, aşağıya veya sağ çapraz aşağıya hareket edebilirler.
- Geri dönüş yoktur, bu yüzden tüm hareketler ilerleyişi sağlamalıdır.

Tekrar:
- Matrisin elemanlarını teker teker dolaşarak kullanıcının matrisi doldurması sağlanır.
- Hücreden hücreye minimum enerji tüketimini sağlayacak şekilde hareket ederek (0,0) noktasından (N-1, N-1) noktasına ulaşılır.

Matematik:
 - En düşük maliyetli yol seçilir
- Minimum enerji tüketimi için her hücreye ulaşırken o ana kadarki toplam maliyet hesaplanır.
- Her hücre için maliyetler matrisi oluşturulur ve bu matris, o hücreye ulaşmak için gereken minimum enerji miktarını içerir. yolMaliyeti[i,j] = Min(üst, sol, çapraz) + güncelHücreMaliyeti
*/

using System;

public class Soru9
{
    public static void Run()
    {
        // Matris boyutunu al
        Console.Write("Matris boyutunu girin: ");
        int boyut = Convert.ToInt32(Console.ReadLine());

        // Matrisi oluştur
        int[,] enerjiMatrisi = MatrisiDoldur(boyut);

        // En kısa yolu bul
        int sonuc = EnKisaYoluBul(enerjiMatrisi);

        // Sonucu yazdır
        Console.WriteLine($"En düşük enerji maliyeti: {sonuc}");
    }

    static int[,] MatrisiDoldur(int boyut)
    {
        int[,] matris = new int[boyut, boyut];

        Console.WriteLine("Matris değerlerini sırayla girin:");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write($"[{i},{j}] değeri: ");
                matris[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        return matris;
    }

    static int EnKisaYoluBul(int[,] matris)
    {
        int boyut = matris.GetLength(0);
        int[,] yolMaliyeti = new int[boyut, boyut];

        // İlk hücreyi doldur
        yolMaliyeti[0, 0] = matris[0, 0];

        // İlk satırı doldur
        for (int j = 1; j < boyut; j++)
        {
            yolMaliyeti[0, j] = yolMaliyeti[0, j - 1] + matris[0, j];
        }

        // İlk sütunu doldur
        for (int i = 1; i < boyut; i++)
        {
            yolMaliyeti[i, 0] = yolMaliyeti[i - 1, 0] + matris[i, 0];
        }

        // Kalan hücreleri doldur
        for (int i = 1; i < boyut; i++)
        {
            for (int j = 1; j < boyut; j++)
            {
                // Üç yönden (yukarı, sol, çapraz) en küçük değeri al
                int enKucuk = Math.Min(
                    Math.Min(yolMaliyeti[i - 1, j], yolMaliyeti[i, j - 1]),
                    yolMaliyeti[i - 1, j - 1]
                );
                yolMaliyeti[i, j] = enKucuk + matris[i, j];
            }
        }

        return yolMaliyeti[boyut - 1, boyut - 1];
    }
}