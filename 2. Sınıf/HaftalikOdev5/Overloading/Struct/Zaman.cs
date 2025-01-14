using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Struct
{
    struct Zaman
    {
        private int saat;
        private int dakika;

        public int Saat
        {
            get => saat;
            set => saat = value >= 0 && value < 24 ? value : 0;
        }

        public int Dakika
        {
            get => dakika;
            set => dakika = value >= 0 && value < 60 ? value : 0;
        }

        public Zaman(int saat, int dakika)
        {
            this.saat = 0;
            this.dakika = 0;
            Saat = saat;
            Dakika = dakika;
        }

        public int ToplamDakika()
        {
            return Saat * 60 + Dakika;
        }

        public static int DakikaFarki(Zaman z1, Zaman z2)
        {
            return Math.Abs(z1.ToplamDakika() - z2.ToplamDakika());
        }
    }

}
