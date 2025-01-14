using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev2_5
{
    internal class Ebeveyn
    {
        public string Ad {  get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar {  get; set; }

        public Ebeveyn()
        {
            Cocuklar = new List<Cocuk>();
        }

        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
        }

    }

    internal class Cocuk
    {

        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; set; }
        public void EbeveynAtama(Ebeveyn ebeveyn)

        {
            Ebeveyn = ebeveyn;
        }

    }
}