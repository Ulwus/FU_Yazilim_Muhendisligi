using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Struct
{
    struct GPSKonum
    {
        public double Enlem { get; set; }
        public double Boylam { get; set; }

        public GPSKonum(double enlem, double boylam)
        {
            Enlem = enlem;
            Boylam = boylam;
        }

        public static double MesafeHesapla(GPSKonum konum1, GPSKonum konum2)
        {
            const double R = 6371; // Dünya'nın yarıçapı (km)
            var dLat = RadyanaCevir(konum2.Enlem - konum1.Enlem);
            var dLon = RadyanaCevir(konum2.Boylam - konum1.Boylam);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(RadyanaCevir(konum1.Enlem)) * Math.Cos(RadyanaCevir(konum2.Enlem)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double RadyanaCevir(double derece)
        {
            return derece * Math.PI / 180;
        }
    }
}
