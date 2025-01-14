using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev3_3
{
    internal class Sirket
    {
        public string Ad {  get; set; }
        public List<Calisan> Calisan { get; set; }
        public Sirket()
        {
            Calisan = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisan.Add(calisan);
        }

    }

    internal class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public void CalisanBilgisi()
        {
            Console.WriteLine($"{Ad} İsmine sahip, {Pozisyon}'unda");
        }
    }
}