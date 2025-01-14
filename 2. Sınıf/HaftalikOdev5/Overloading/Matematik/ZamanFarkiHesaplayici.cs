using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Matematik
{
    class ZamanFarkiHesaplayici
    {
        public int FarkHesapla(DateTime baslangic, DateTime bitis)
        {
            return (bitis - baslangic).Days;
        }

        public int SaatFarkiHesapla(DateTime baslangic, DateTime bitis)
        {
            return (int)(bitis - baslangic).TotalHours;
        }

        public (int yil, int ay, int gun) DetayliFarkHesapla(DateTime baslangic, DateTime bitis)
        {
            int yil = bitis.Year - baslangic.Year;
            int ay = bitis.Month - baslangic.Month;
            int gun = bitis.Day - baslangic.Day;

            if (ay < 0)
            {
                yil--;
                ay += 12;
            }
            if (gun < 0)
            {
                ay--;
                gun += DateTime.DaysInMonth(baslangic.Year, baslangic.Month);
            }

            return (yil, ay, gun);
        }
    }
}
