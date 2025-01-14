using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Indeksleyici
{
    class NotSistemi
    {
        private Dictionary<string, int> notlar = new Dictionary<string, int>();

        public int this[string ders]
        {
            get
            {
                return notlar.ContainsKey(ders) ? notlar[ders] : throw new ArgumentException("Ders bulunamadı");
            }
            set
            {
                notlar[ders] = value;
            }
        }
    }
}
