using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Enum
{
    public enum CalisanRolu
    {
        Mudur = 1,
        Gelistirici,
        Tasarimci,
        TestUzmani
    }

    public class MaasHesaplayici
    {
        private const decimal TemelMaas = 10000m;

        public decimal MaasHesapla(CalisanRolu rol)
        {
            switch (rol)
            {
                case CalisanRolu.Mudur:
                    return TemelMaas * 2.5m;
                case CalisanRolu.Gelistirici:
                    return TemelMaas * 2.0m;
                case CalisanRolu.Tasarimci:
                    return TemelMaas * 1.8m;
                case CalisanRolu.TestUzmani:
                    return TemelMaas * 1.5m;
                default:
                    return TemelMaas;
            }
        }
    }
}
