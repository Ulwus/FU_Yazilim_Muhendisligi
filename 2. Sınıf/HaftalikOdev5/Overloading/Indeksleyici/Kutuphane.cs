using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Indeksleyici
{
    class Kutuphane
    {
        private string[] kitaplar = new string[100];

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= kitaplar.Length)
                    return "Geçersiz indeks";
                return kitaplar[index] ?? "Boş raf";
            }
            set
            {
                if (index >= 0 && index < kitaplar.Length)
                    kitaplar[index] = value;
            }
        }
    }
}
