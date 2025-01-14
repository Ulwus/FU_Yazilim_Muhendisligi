using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Hayvanat
{
    public class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor.");
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Tür: {Tur}");
            Console.WriteLine($"Yaş: {Yas}");
        }
    }
}
