using System;

public class Program
{
    // Ana programın başlangıç noktası olan Main metodu
    static void Main()
    {
        // İlk matrisin satır ve sütun boyutlarını tanımlıyoruz.
        int matris1i, matris1j;

        // İkinci matrisin satır ve sütun boyutlarını tanımlıyoruz.
        int matris2i, matris2j;

        // Kullanıcıdan 1. matrisin boyutunu girmesini istiyoruz. Kare matris olduğu için satır ve sütun sayısı eşit bir kere almamız yeterli.
        Console.WriteLine("1. kare matrisinin bir boyunu giriniz: ");
        matris1i = Convert.ToInt32(Console.ReadLine());
        // 1. matrisin sütun sayısı da satır sayısına eşittir (kare matris).
        matris1j = matris1i;

        // Kullanıcıdan 2. matrisin boyutunu girmesini istiyoruz. Bu da kare matris olduğundan satır ve sütun sayıları eşit bir kere almamız yeterli.
        Console.WriteLine("2. kare matrisinin bir boyunu giriniz: ");
        matris2i = Convert.ToInt32(Console.ReadLine());
        // 2. matrisin sütun sayısı da satır sayısına eşittir.
        matris2j = matris2i;

        // Matris çarpımı için, 1. matrisin sütun sayısının (matris1j) 2. matrisin satır sayısına (matris2i) eşit olması gerekir.
        // Bu kod satırını ilk başta kare matris değil de tüm değerlerle yapılacağını sandığım için koymuştum.
        // Eğer eşit değilse ki eşit olması mecbur kare matris ve ikiside birbirine eşit olmalı, kullanıcıya uyarı verip programı sonlandırıyoruz
        // Yukarıdaki kod satırlarında sadece bir değer almak yeterli olur çünkü kare matris olduğundan diğer değerler zaten aynı olmak zorunda.
        if (matris1j != matris2i)
        {
            Console.WriteLine("Matrislerin çarpımı için 1. matrisin sütun sayısı ile 2. matrisin satır sayısı eşit olmalıdır.");
            return; 
        }

        // Matrislerin elemanlarını tutmak için iki boyutlu diziler tanımlanıyor.
        int[,] matris1 = new int[matris1i, matris1j];  // 1. matrisin boyutları
        int[,] matris2 = new int[matris2i, matris2j];  // 2. matrisin boyutları
        int[,] matris3 = new int[matris1i, matris2j];  // Sonuç matrisinin boyutları (çarpım sonucu oluşan matris)


        // 1. matrisin elemanlarını kullanıcıdan tek tek alıyoruz.
        Console.WriteLine("1. matrisin elemanlarını giriniz: ");
        for (int i = 0; i < matris1i; i++)
        {
            for (int j = 0; j < matris1j; j++)
            {
                Console.WriteLine("1. matrisin {0} {1}: ", i + 1, j + 1);
                matris1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // 2. matrisin elemanlarını kullanıcıdan tek tek alıyoruz.
        Console.WriteLine("2. matrisin elemanlarını giriniz: ");
        for (int i = 0; i < matris2i; i++)
        {
            for (int j = 0; j < matris2j; j++)
            {
                Console.WriteLine("2. matrisin {0} {1}", i + 1, j + 1);
                matris2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // 1. matrisin elemanlarını ekrana yazdırıyoruz.
        Console.WriteLine("1. matris: ");
        for (int i = 0; i < matris1i; i++)
        {
            for (int j = 0; j < matris1j; j++)
            {
                Console.Write(matris1[i, j] + " ");
            }
            Console.WriteLine();
        }

        // 2. matrisin elemanlarını ekrana yazdırıyoruz.
        Console.WriteLine("2. matris: ");
        for (int i = 0; i < matris2i; i++)
        {
            for (int j = 0; j < matris2j; j++)
            {
                Console.Write(matris2[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Matris çarpımı işlemi (her iki matrisin elemanlarını çarparak üçüncü matrise yani sonuç matrisine sonuçları koyuyoruz).
        for (int i = 0; i < matris1i; i++)
        {
            for (int j = 0; j < matris2j; j++)
            {
                // Her hücrede üçüncü matrisin yani sonuç matrisinin değeri için; satırlar satırlarla, sütunlar sütunlarla teker teker çarpılıp bütün değerler toplanıyor.
                for (int k = 0; k < matris1j; k++)
                {
                    matris3[i, j] += matris1[i, k] * matris2[k, j];
                }
            }
        }

        // Çarpım sonucu elde edilen 3. matrisin elemanlarını ekrana yazdırıyoruz.
        for (int i = 0; i < matris1i; i++)
        {
            for (int j = 0; j < matris2j; j++)
            {
                Console.Write((matris3[i, j]) + " ");
            }
            Console.WriteLine();
        }
    }
}
