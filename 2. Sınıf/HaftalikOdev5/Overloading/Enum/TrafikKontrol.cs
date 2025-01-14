using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Enum
{
    public enum TrafiklIsigi
    {
        Kirmizi = 1,
        Sari,
        Yesil
    }

    public class TrafikkKontrol
    {
        public string DurumMesajiAl(TrafiklIsigi isik)
        {
            switch (isik)
            {
                case TrafiklIsigi.Kirmizi:
                    return "DUR!";
                case TrafiklIsigi.Sari:
                    return "HAZIRLAN!";
                case TrafiklIsigi.Yesil:
                    return "GEÇ!";
                default:
                    return "Geçersiz durum";
            }
        }
    }
}
