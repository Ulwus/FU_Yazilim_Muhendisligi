using HaftalikOdev5.Kalitim.Banka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka2
{
    public class BirikimHesabi : Hesap
    {
        public double FaizOrani { get; set; }

        public override decimal ParaYatir(decimal miktar)
        {
            decimal faizMiktari = miktar * (decimal)(FaizOrani / 100);
            Bakiye += miktar + faizMiktari;
            Console.WriteLine($"Yatırılan: {miktar} TL, Faiz: {faizMiktari} TL");
            return Bakiye;
        }

        public override decimal ParaCek(decimal miktar)
        {
            if (miktar <= Bakiye)
            {
                Bakiye -= miktar;
                return miktar;
            }
            throw new Exception("Yetersiz bakiye!");
        }

        public override void HesapOzeti()
        {
            Console.WriteLine($"Birikim Hesabı - No: {HesapNo}");
            Console.WriteLine($"Açılış Tarihi: {HesapAcilisTarihi}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
            Console.WriteLine($"Faiz Oranı: %{FaizOrani}");
        }
    }
}
