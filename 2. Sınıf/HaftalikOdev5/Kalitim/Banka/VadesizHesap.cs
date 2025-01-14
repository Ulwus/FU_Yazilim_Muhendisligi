using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka
{
    public class VadesizHesap : Hesap
    {
        public decimal EkHesapLimit { get; set; }

        public override bool ParaCek(decimal miktar)
        {
            if (miktar <= (Bakiye + EkHesapLimit))
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
                return true;
            }
            Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            return false;
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimit} TL");
        }
    }
}
