using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev4_3
{
    internal class Otomobil
    {
        public string Marka { get; set; }
        public Motor Motor { get; set; }

        public void MotorOlustur()
        {
            Motor = new Motor(1,"VTEC");
        }
    }

    internal class Motor
    {
        public int Guc {  get; set; }
        public string Tip { get; set; }

        public Motor(int guc, string tip)
        {
            Guc = guc;
            Tip = tip;
        }

        public void MotorBilgisi()
        {
            Console.WriteLine($"Güç değeri: {Guc} Tip: {Tip}");
        }
    }
}