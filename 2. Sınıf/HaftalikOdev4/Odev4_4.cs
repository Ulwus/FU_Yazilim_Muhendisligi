using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev4_4
{
    internal class Okul
    {
        public string Ad { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; }
        public Okul() 
        { 
            Ogrenciler = new List<Ogrenci>();
        }

        public void OgrenciOlustur()
        {
            Ogrenci ogrenci1 = new Ogrenci("Oğuzhan", 19);
            Ogrenci ogrenci2 = new Ogrenci("Oğuzhan", 21);
            Ogrenciler.Add(ogrenci1);
            Ogrenciler.Add(ogrenci2);
        }

    }

    internal class Ogrenci
    {
        public string Ad { get; set; }
        public int Yas { get; set; }

        public Ogrenci(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void OgrenciBilgisi()
        {
            Console.WriteLine($"Ad: {Ad},Yaş: {Yas}");
        }

    }
}