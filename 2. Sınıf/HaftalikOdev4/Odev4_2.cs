using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev4_2
{
    internal class Bilgisayar
    {
        public string Model { get; set; }
        public Islemci Islemci { get; set; }


        public void IslemciOlustur()
        {
            Islemci = new Islemci(5,5);
        }

    }


    internal class Islemci
    {
        public int Cekirdekler { get; set; }
        public int Frekans {  get; set; }

        public Islemci(int cekirdekler, int frekans)
        {
            Cekirdekler = cekirdekler;
            Frekans = frekans;
        }
        public void IslemciBilgisi()
        {
            Console.WriteLine($"Çekirdek Sayısı: {Cekirdekler}, Frekans: {Frekans}");
        }

    }
}