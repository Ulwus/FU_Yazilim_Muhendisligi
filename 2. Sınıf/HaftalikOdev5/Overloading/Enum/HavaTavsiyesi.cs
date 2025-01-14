using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Enum
{
    public enum HavaDurumu
    {
        Gunesli = 1,
        Yagmurlu,
        Bulutlu,
        Firtinali
    }

    public class HavaTavsiyesi
    {
        public string TavsiyeAl(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Gunesli:
                    return "Güneş kremi kullanın";
                case HavaDurumu.Yagmurlu:
                    return "Şemsiye alın";
                case HavaDurumu.Bulutlu:
                    return "Hava serin olabilir";
                case HavaDurumu.Firtinali:
                    return "Dışarı çıkmayın";
                default:
                    return "Bilinmeyen hava durumu";
            }
        }
    }
}
