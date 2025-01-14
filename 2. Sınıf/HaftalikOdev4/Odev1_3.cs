using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Odev1_3
{
    internal class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        public void DepertmanAtama(Departman departman)
        {
            Departman = departman;
        }
    }

    internal class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

    }
}

