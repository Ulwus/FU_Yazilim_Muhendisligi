using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.Overloading.Matematik
{
    class Hesaplayici
    {
        public int Topla(int a, int b)
        {
            return a + b;
        }

        public int Topla(int a, int b, int c)
        {
            return a + b + c;
        }

        public int Topla(int[] sayilar)
        {
            return sayilar.Sum();
        }
    }
}
