using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev3_4
{
    internal class Kutuphane
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Kutuphane() 
        {
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

    }

    internal class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }
    }
}