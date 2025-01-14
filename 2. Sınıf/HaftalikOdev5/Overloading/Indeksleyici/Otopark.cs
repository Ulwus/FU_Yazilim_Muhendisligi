using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Indeksleyici
{
    class Otopark
    {
        private string[,] parkYerleri = new string[3, 80]; // 3 kat, her katta 80 yer

        public string this[int kat, int yer]
        {
            get
            {
                if (GecerliYerMi(kat, yer))
                    return parkYerleri[kat, yer] ?? "Boş";
                throw new ArgumentException("Geçersiz park yeri");
            }
            set
            {
                if (GecerliYerMi(kat, yer))
                    parkYerleri[kat, yer] = value;
                else
                    throw new ArgumentException("Geçersiz park yeri");
            }
        }

        private bool GecerliYerMi(int kat, int yer)
        {
            return kat >= 0 && kat < 5 && yer >= 0 && yer < 20;
        }
    }
}
