using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Matematik
{
    class AlanHesaplayici
    {
        public double AlanHesapla(double kenar)
        {
            return kenar * kenar; // Kare
        }

        public double AlanHesapla(double uzunluk, double genislik)
        {
            return uzunluk * genislik; // Dikdörtgen
        }

        public double AlanHesapla(double yaricap, bool daireMi)
        {
            return Math.PI * yaricap * yaricap; // Daire
        }
    }
}
