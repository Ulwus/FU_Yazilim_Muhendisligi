using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev3_2
{
    internal class Ev
    {
        public string Ad {  get; set; }
        public List<Oda> Odalar { get; set; }

        public Ev() 
        { 
            Odalar = new List<Oda>();
        }
        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }
    }

    internal class Oda
    {
        public string Boyut { get; set; }
        public string Tip { get; set; }
    }
}