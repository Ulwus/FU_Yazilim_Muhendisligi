using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Indeksleyici
{
    class SatrancTahtasi
    {
        private string[,] tahta = new string[8, 8];

        public string this[int satir, int sutun]
        {
            get
            {
                if (GecerliPozisyonMu(satir, sutun))
                    return tahta[satir, sutun] ?? "Boş";
                throw new ArgumentException("Geçersiz pozisyon");
            }
            set
            {
                if (GecerliPozisyonMu(satir, sutun))
                    tahta[satir, sutun] = value;
                else
                    throw new ArgumentException("Geçersiz pozisyon");
            }
        }

        private bool GecerliPozisyonMu(int satir, int sutun)
        {
            return satir >= 0 && satir < 8 && sutun >= 0 && sutun < 8;
        }
    }
}
