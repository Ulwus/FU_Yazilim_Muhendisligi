/*
Giriş:
- Kullanıcıdan iki polinom alınır (örnek: 2x^2 + 3x - 5 ve x^2 - 4).
- Kullanıcı, 'exit' yazarak programı sonlandırabilir.
- Polinomlar, terimler arasında '+' veya '-' işaretleri kullanılarak girilmelidir.

Çıkış:
- İki polinomun toplamı ve farkı ekrana yazdırılır.
- Her işlem sonrası kullanıcıya yeni polinom girişi yapma imkanı sunulur.

Kontrol:
- Polinom girişlerinin doğru formatta olup olmadığı kontrol edilir.
- Geçersiz polinom formatları için hata mesajları gösterilir.
- Polinomlardaki terimlerin doğru şekilde ayrıştırılıp ayrıştırılmadığı kontrol edilir.

Tekrar:
- Kullanıcı 'exit' yazana kadar polinom girişi yapmaya devam eder.
- Her yeni giriş için toplama ve çıkarma işlemleri tekrarlanır ve sonuçlar gösterilir.

Matematik:
- Polinomlar, üsleri anahtar ve katsayıları değer olarak tutan `Dictionary<int, double>` yapısında temsil edilir.
- Toplama ve çıkarma işlemleri, polinomların aynı üslerine sahip terimlerinin katsayılarının toplanması veya çıkarılması ile gerçekleştirilir.
- Sıfır katsayıya sahip terimler sonucun okunabilirliğini artırmak için kaldırılır.
*/

using System;
using System.Text;
using System.Text.RegularExpressions;


    public class Soru5
    {


        public static void Run()
        {
            // Programın başlangıç mesajları ve kullanım talimatları
            Console.WriteLine("Polinom Hesaplayıcı Programına Hoş Geldiniz!");
            Console.WriteLine("Polinomları girmek için terimler arasında + veya - kullanın (örnek: 2x^2 + 3x - 5).");
            Console.WriteLine("Programdan çıkmak için 'exit' yazın.\n");

            // Sürekli olarak polinom girişi almak için sonsuz döngü
            while (true)
            {
                // Kullanıcıdan ilk polinomu girmesi istenir
                Console.WriteLine("İlk polinomu girin (veya çıkmak için 'exit'): ");
                string input1 = Console.ReadLine();

                // Kullanıcı 'exit' yazarsa program sonlandırılır
                if (input1.Trim().ToLower() == "exit")
                    break;

                // Kullanıcıdan ikinci polinomu girmesi istenir
                Console.WriteLine("İkinci polinomu girin (veya çıkmak için 'exit'): ");
                string input2 = Console.ReadLine();

                // Kullanıcı 'exit' yazarsa program sonlandırılır
                if (input2.Trim().ToLower() == "exit")
                    break;

                try
                {
                    // Kullanıcının girdiği polinomlar parse edilerek sözlük formatına dönüştürülür
                    Dictionary<int, double> poly1 = ParsePolynomial(input1);
                    Dictionary<int, double> poly2 = ParsePolynomial(input2);

                    // İki polinomun toplamı hesaplanır
                    Dictionary<int, double> sum = AddPolynomials(poly1, poly2);
                    // İki polinomun farkı hesaplanır
                    Dictionary<int, double> difference = SubtractPolynomials(poly1, poly2);

                    // Toplam polinom ekrana yazdırılır
                    Console.WriteLine("\nToplam Polinom:");
                    PrintPolynomial(sum);

                    // Fark polinom ekrana yazdırılır
                    Console.WriteLine("\nFark Polinom:");
                    PrintPolynomial(difference);

                    // Her işlem sonrası ayırıcı çizgi eklenir
                    Console.WriteLine(new string('-', 50));
                }
                catch (Exception ex)
                {
                    // Herhangi bir hata durumunda hata mesajı ekrana yazdırılır
                    Console.WriteLine($"\nHata: {ex.Message}\n");
                }
            }

            // Program sonlandırıldığında veda mesajı gösterilir
            Console.WriteLine("Program sonlandırıldı. İyi günler!");
        }

        // Polinomu parse ederek Dictionary<int, double> formatına dönüştürme fonksiyonu
        static Dictionary<int, double> ParsePolynomial(string input)
        {
            // Polinom girişindeki tüm boşluklar kaldırılır
            input = input.Replace(" ", "");

            // Polinom terimlerini '+' veya '-' işaretleriyle ayırmak için regex kullanılır
            // Pozitif lookbehind kullanılarak '-' işaretinin terimle birlikte kalması sağlanır
            string pattern = @"(?=[+-])";
            string[] terms = Regex.Split(input, pattern);

            // Polinomu temsil etmek için üsleri anahtar ve katsayıları değer olarak tutan sözlük oluşturulur
            Dictionary<int, double> polynomial = new Dictionary<int, double>();

            // Her bir terim ayrı ayrı işlenir
            foreach (string term in terms)
            {
                // Boş veya sadece boşluk içeren terimler atlanır
                if (string.IsNullOrWhiteSpace(term))
                    continue;

                double coefficient = 0; // Katsayı
                int exponent = 0;        // Üs

                // Terimi parse etmek için regex kullanılır
                // Grup 1: x içeren terimler (örneğin, 2x^2, -x)
                // Grup 3: Sabit terimler (örneğin, +5, -3)
                Match match = Regex.Match(term, @"([+-]?\d*\.?\d*)x(?:\^(\d+))?|([+-]?\d+\.?\d*)");

                if (match.Success)
                {
                    if (match.Groups[1].Success)
                    {
                        // x içeren terimlerin katsayıları belirlenir
                        string coeffStr = match.Groups[1].Value;

                        // Katsayı belirlenirken boş veya '+' ise 1, '-' ise -1 kabul edilir
                        if (coeffStr == "+" || coeffStr == "")
                            coefficient = 1;
                        else if (coeffStr == "-")
                            coefficient = -1;
                        else
                            coefficient = double.Parse(coeffStr);

                        // Üs değeri belirtilmişse alınır, aksi halde 1 kabul edilir
                        if (match.Groups[2].Success)
                            exponent = int.Parse(match.Groups[2].Value);
                        else
                            exponent = 1;
                    }
                    else if (match.Groups[3].Success)
                    {
                        // Sabit terimlerin katsayıları belirlenir
                        coefficient = double.Parse(match.Groups[3].Value);
                        exponent = 0; // Sabit terimlerin üssü 0'dır
                    }

                    // Polinom sözlüğüne terim eklenir
                    if (polynomial.ContainsKey(exponent))
                        polynomial[exponent] += coefficient; // Aynı üs varsa katsayı toplanır
                    else
                        polynomial.Add(exponent, coefficient); // Yeni üs eklenir
                }
                else
                {
                    // Terim formatı geçersizse hata fırlatılır
                    throw new Exception($"Geçersiz terim formatı: '{term}'");
                }
            }

            return polynomial;
        }

        // İki polinomu toplama fonksiyonu
        static Dictionary<int, double> AddPolynomials(Dictionary<int, double> poly1, Dictionary<int, double> poly2)
        {
            // Sonuç polinomu için poly1 kopyalanır
            Dictionary<int, double> result = new Dictionary<int, double>(poly1);

            // poly2'nin her terimi sonuç polinomuna eklenir
            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] += term.Value; // Aynı üs varsa katsayı toplanır
                else
                    result.Add(term.Key, term.Value); // Yeni üs eklenir
            }

            // Sıfır katsayıya sahip terimler kaldırılır
            RemoveZeroCoefficients(result);

            return result;
        }

        // İki polinomu çıkarma fonksiyonu
        static Dictionary<int, double> SubtractPolynomials(Dictionary<int, double> poly1, Dictionary<int, double> poly2)
        {
            // Sonuç polinomu için poly1 kopyalanır
            Dictionary<int, double> result = new Dictionary<int, double>(poly1);

            // poly2'nin her terimi sonuç polinomundan çıkarılır
            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] -= term.Value; // Aynı üs varsa katsayı çıkarılır
                else
                    result.Add(term.Key, -term.Value); // Yeni üs eklenir ve katsayı negatif yapılır
            }

            // Sıfır katsayıya sahip terimler kaldırılır
            RemoveZeroCoefficients(result);

            return result;
        }

        // Polinom içerisindeki sıfır katsayıya sahip terimleri kaldırma fonksiyonu
        static void RemoveZeroCoefficients(Dictionary<int, double> poly)
        {
            // Sıfır katsayıya sahip terimlerin üsleri toplanır
            List<int> keysToRemove = new List<int>();
            foreach (var term in poly)
            {
                if (Math.Abs(term.Value) < 1e-10) // Katsayı yaklaşık sıfırsa
                    keysToRemove.Add(term.Key);
            }

            // Toplanan üsler polinom sözlüğünden kaldırılır
            foreach (int key in keysToRemove)
            {
                poly.Remove(key);
            }
        }

        // Polinomu okunabilir formatta ekrana yazdırma fonksiyonu
        static void PrintPolynomial(Dictionary<int, double> poly)
        {
            // Eğer polinom boşsa '0' yazdırılır
            if (poly.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            // Terimler, üslerine göre büyükten küçüğe sıralanır
            List<int> exponents = new List<int>(poly.Keys);
            exponents.Sort();
            exponents.Reverse(); // Büyük üssel terimler önce gelir

            StringBuilder sb = new StringBuilder(); // Sonuç polinomu için StringBuilder kullanılır

            // Her bir üs için terim eklenir
            foreach (int exp in exponents)
            {
                double coeff = poly[exp]; // Üssün katsayısı alınır

                // Sıfır katsayıya sahip terimler atlanır
                if (coeff == 0)
                    continue;

                // İlk terim değilse, önceki terimin işaretine göre '+' veya '-' eklenir
                if (sb.Length > 0)
                {
                    sb.Append(coeff > 0 ? " + " : " - ");
                }
                else
                {
                    // İlk terim negatifse '-' işareti eklenir
                    if (coeff < 0)
                        sb.Append("-");
                }

                // Katsayının mutlak değeri alınır
                double absCoeff = Math.Abs(coeff);

                // Katsayı eklenir, ancak 'x' terimlerinde katsayı 1 ise yazılmaz
                if (exp == 0 || absCoeff != 1)
                {
                    sb.Append(absCoeff);
                }

                // Değişken ve üs eklenir
                if (exp > 0)
                {
                    sb.Append("x"); // Değişken eklenir
                    if (exp > 1)
                        sb.Append("^" + exp); // Üs eklenir
                }
            }

            // Oluşturulan polinom stringi ekrana yazdırılır
            Console.WriteLine(sb.ToString());
        }
    }

