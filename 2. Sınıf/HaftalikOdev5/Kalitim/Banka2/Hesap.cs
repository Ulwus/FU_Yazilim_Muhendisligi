using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Kalitim.Banka2
{
    public abstract class Hesap : IBankaHesabi
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public abstract decimal ParaYatir(decimal miktar);
        public abstract decimal ParaCek(decimal miktar);
        public abstract void HesapOzeti();
    }
}
