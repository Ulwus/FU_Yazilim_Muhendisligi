using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev2_3
{
    internal class Yazar
    {

        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar() 
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
        public DateTime YayinTarihi { get; set; }
        public Yazar Yazar { get; set; }
        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;

        }

    }
}