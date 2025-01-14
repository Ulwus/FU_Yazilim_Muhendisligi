/*
        Giriş:
        - Kullanıcıdan matematiksel bir ifade alınır (örnek: 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3).
        - İfade, karakter karakter işlenmek üzere hazırlanır.
        
        Çıkış:
        - İfadeyi çözerken yapılan işlemler adım adım ekrana yazdırılır.
        - Sonuç ekrana yazdırılır.
        
        Kontrol:
        - İfade içindeki parantezlerin uyumlu olup olmadığı kontrol edilir.
        - Geçersiz karakterler veya eksik operantlar için hata kontrolü yapılır.
        
        Tekrar:
        - İfade, işlem önceliklerine göre sırasıyla değerlendirilir:
   
        Matematik:
            İşlem önceliği
            1. Parantez içindeki ifadeler
            2. Üs alma işlemleri
            3. Çarpma ve bölme işlemleri
            4. Toplama ve çıkarma işlemleri
        
*/


using System;


    public class Soru4
    {
        

        // Geçerli pozisyonu ve mevcut karakteri tutmak için değişkenler
        static int pos = -1, ch;

        public static void Run()
        {
            // Giriş:
            Console.WriteLine("Matematiksel ifadeyi girin (örnek: 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3):");
            string input = Console.ReadLine();

            try
            {
                pos = -1;
                Console.WriteLine("\nÇözüm Adımları:");
                double result = ParseExpression(input);
                Console.WriteLine($"\nSonuç: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nHata: {ex.Message}");
            }
        }

        // İfadeyi bir sonraki karaktere ilerletme
        static void NextChar(string s)
        {
            pos++;
            if (pos < s.Length)
                ch = s[pos];
            else
                ch = -1; // İfade sonu
        }

        // Belirli bir karakteri tüketip tüketmediğini kontrol etme
        static bool Eat(string s, int charToEat)
        {
            // Boşlukları atla
            while (ch == ' ') NextChar(s);
            if (ch == charToEat)
            {
                NextChar(s);
                return true;
            }
            return false;
        }

        // İfadeyi değerlendirmeye başlama
        static double ParseExpression(string s)
        {
            NextChar(s);
            double x = ParseAddSubtract(s);
            if (pos < s.Length)
                throw new Exception("Geçersiz ifade.");
            return x;
        }

        // Toplama ve çıkarma işlemlerini gerçekleştirme
        static double ParseAddSubtract(string s)
        {
            double x = ParseMultiplyDivide(s);
            while (true)
            {
                if (Eat(s, '+'))
                {
                    double y = ParseMultiplyDivide(s);
                    Console.WriteLine($"{x} + {y} = {x + y}");
                    x += y;
                }
                else if (Eat(s, '-'))
                {
                    double y = ParseMultiplyDivide(s);
                    Console.WriteLine($"{x} - {y} = {x - y}");
                    x -= y;
                }
                else
                {
                    return x;
                }
            }
        }

        // Çarpma ve bölme işlemlerini gerçekleştirme
        static double ParseMultiplyDivide(string s)
        {
            double x = ParsePower(s);
            while (true)
            {
                if (Eat(s, '*'))
                {
                    double y = ParsePower(s);
                    Console.WriteLine($"{x} * {y} = {x * y}");
                    x *= y;
                }
                else if (Eat(s, '/'))
                {
                    double y = ParsePower(s);
                    Console.WriteLine($"{x} / {y} = {x / y}");
                    x /= y;
                }
                else
                {
                    return x;
                }
            }
        }

        // Üs alma işlemlerini gerçekleştirme
        static double ParsePower(string s)
        {
            double x = ParseUnary(s);
            while (true)
            {
                if (Eat(s, '^'))
                {
                    double y = ParseUnary(s);
                    double res = Math.Pow(x, y);
                    Console.WriteLine($"{x} ^ {y} = {res}");
                    x = res;
                }
                else
                {
                    return x;
                }
            }
        }

        // Ünary işlemleri (örneğin, negatif sayılar) değerlendirme
        static double ParseUnary(string s)
        {
            if (Eat(s, '+')) return ParseUnary(s); // Ünary artı
            if (Eat(s, '-'))
            {
                double y = ParseUnary(s);
                Console.WriteLine($"-1 * {y} = {-y}");
                return -y; // Ünary eksi
            }
            return ParseParentheses(s);
        }

        // Parantez içindeki ifadeleri değerlendirme
        static double ParseParentheses(string s)
        {
            if (Eat(s, '('))
            {
                double x = ParseAddSubtract(s);
                if (!Eat(s, ')'))
                    throw new Exception("Parantezler uyumsuz.");
                return x;
            }
            return ParseNumber(s);
        }

        // Sayıları okuma ve döndürme
        static double ParseNumber(string s)
        {
            int startPos = pos;
            while ((ch >= '0' && ch <= '9') || ch == '.') NextChar(s);
            string numberStr = s.Substring(startPos, pos - startPos);
            if (!double.TryParse(numberStr, out double x))
                throw new Exception($"Geçersiz sayı: {numberStr}");
            return x;
        }
    }

