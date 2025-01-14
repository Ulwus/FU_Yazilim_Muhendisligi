using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Struct
{
    struct KarmasikSayi
    {
        public double Reel { get; set; }
        public double Sanal { get; set; }

        public KarmasikSayi(double reel, double sanal)
        {
            Reel = reel;
            Sanal = sanal;
        }

        public static KarmasikSayi Topla(KarmasikSayi k1, KarmasikSayi k2)
        {
            return new KarmasikSayi(k1.Reel + k2.Reel, k1.Sanal + k2.Sanal);
        }

        public static KarmasikSayi Cikar(KarmasikSayi k1, KarmasikSayi k2)
        {
            return new KarmasikSayi(k1.Reel - k2.Reel, k1.Sanal - k2.Sanal);
        }

        public override string ToString()
        {
            return $"{Reel} + {Sanal}i";
        }
    }
}
