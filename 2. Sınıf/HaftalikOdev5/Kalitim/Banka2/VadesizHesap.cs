using HaftalikOdev5.Kalitim.Banka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka2
{
    public class VadesizHesap : Hesap
    {
        private const decimal IslemUcreti = 1.0m;

        public override decimal ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            return Bakiye;
        }

        public override decimal ParaCek(decimal miktar)
        {
            decimal toplamCekim = miktar + IslemUcreti;
            if (toplamCekim <= Bakiye)
            {
                Bakiye -= toplamCekim;
                Console.WriteLine($"Çekilen: {miktar} TL, İşlem Ücreti: {IslemUcreti} TL");
                return miktar;
            }
            throw new Exception("Yetersiz bakiye!");
        }

        public override void HesapOzeti()
        {
            Console.WriteLine($"Vadesiz Hesap - No: {HesapNo}");
            Console.WriteLine($"Açılış Tarihi: {HesapAcilisTarihi}");
            Console.WriteLine($"Bakiye: {Bakiye} TL");
        }
    }
}
