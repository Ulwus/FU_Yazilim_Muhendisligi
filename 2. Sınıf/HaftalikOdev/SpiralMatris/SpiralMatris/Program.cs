using System;  


class Program
{
    // Programın başlangıç noktası olan Main metodu.
    static void Main()
    {
        // Kullanıcıdan matrisin boyutunu alıyoruz.
        Console.Write("Matris boyutunu giriniz (N): ");
        int matrisBoyutu = int.Parse(Console.ReadLine());


        // Spiral matris için sınırları belirleyen değişkenler tanımlıyoruz ve sayının başlangıç değerini belirliyoruz.
        int yukari = 0, asagi = matrisBoyutu - 1, sol = 0, sag = matrisBoyutu - 1, sayi = 1;

        // İki boyutlu matris tanımlıyoruz.
        int[,] spiralMatris = new int[matrisBoyutu, matrisBoyutu];

        // Matris tamamen dolana kadar bu döngü çalışacak (artacak sayı, en fazla matrisin alanına eşit olacak şekilde artabilir).
        //Matrisi doldururken aynı zamanda sayıyı da arttırıyoruz.
        while (sayi <= matrisBoyutu * matrisBoyutu)
        {
            // Soldan sağa doğru.
            for (int i = sol; i <= sag; i++)  
            {
                
                spiralMatris[yukari, i] = sayi++;  
            }
            yukari++;  // Yukarı sınırını bir alt satıra kaydırıyoruz.

            // Yukarıdan aşağıya doğru.
            for (int i = yukari; i <= asagi; i++)  
            {
                // Artan sayıyı matrisin ilgili yerine setliyoruz ve sayıyı bir arttırıyoruz.
                spiralMatris[i, sag] = sayi++;  
            }
            sag--;  // Sağ sınırını bir sola kaydırıyoruz.

            // Sağdan sola doğru.
            for (int i = sag; i >= sol; i--)  
            {
                // Artan sayıyı matrisin ilgili yerine setliyoruz ve sayıyı bir arttırıyoruz.
                spiralMatris[asagi, i] = sayi++;  
            }
            asagi--;  // Aşağı sınırını bir yukarı kaydırıyoruz.

            // Aşağıdan yukarıya doğru.
            for (int i = asagi; i >= yukari; i--) 
            {
                // Artan sayıyı matrisin ilgili yerine setliyoruz ve sayıyı bir arttırıyoruz.
                spiralMatris[i, sol] = sayi++;  
            }
            sol++;  // Sol sınırını bir sağa kaydırıyoruz.
        }

        // Spiral matrisin ekrana yazdırılması.
        for (int i = 0; i < matrisBoyutu; i++)  
        {
            for (int j = 0; j < matrisBoyutu; j++) 
            {
                Console.Write(spiralMatris[i, j] + "  ");
            }
            Console.WriteLine();  
        }
    }
}
