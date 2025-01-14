using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Odev1_2
{
    public class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitap { get; set; }

        public void KitapEkle(Kitap kitap)
        {
            Kitap = new List<Kitap>();
            Kitap.Add(kitap);

        }

    }

    public class Kitap
    {
            public string Baslik { get; set; }
            public string ISBN { get; set; }

            public Kitap(string baslik, string isbn) {
                Baslik = baslik;
                ISBN = isbn;
            }

    }
}
