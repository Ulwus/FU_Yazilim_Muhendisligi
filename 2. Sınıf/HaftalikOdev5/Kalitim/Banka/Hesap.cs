using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka
{
    public class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        public virtual bool ParaCek(decimal miktar)
        {
            if (miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
                return true;
            }
            Console.WriteLine("Yetersiz bakiye!");
            return false;
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNo}");
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
        }
    }
}
