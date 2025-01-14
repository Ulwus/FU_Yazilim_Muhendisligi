using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka
{
    public class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }
        private DateTime VadeBitis;

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            VadeBitis = DateTime.Now.AddMonths(VadeSuresi);
            Console.WriteLine($"{miktar} TL yatırıldı. Vade bitişi: {VadeBitis.ToShortDateString()}");
        }

        public override bool ParaCek(decimal miktar)
        {
            if (DateTime.Now < VadeBitis)
            {
                Console.WriteLine("Vade süresi dolmadan para çekilemez!");
                return false;
            }
            return base.ParaCek(miktar);
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} ay");
            Console.WriteLine($"Faiz Oranı: %{FaizOrani}");
            Console.WriteLine($"Vade Bitiş: {VadeBitis.ToShortDateString()}");
        }
    }
}
