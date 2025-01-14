using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev1_5
{
    internal class Musteri
    {
        public string Ad { get; set; }
        public string Telefon { get; set; } 

        public void SiparisVer(Siparis siparis)
        {
            siparis.Tarih = DateTime.Now;
            siparis.Durum = "Satın Alındı";

        }

    }

    internal class Siparis
    {
        public DateTime Tarih {  get; set; }
        public string Durum { get; set; }

    }
}