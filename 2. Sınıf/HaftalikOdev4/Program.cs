using System;

public class Program
{
    public static void Main(string[] args)
    {
        Odev3.Urun urun = new Odev3.Urun();
        urun.Ad = "Su";
        urun.Fiyat = 2;

        Odev3.Urun urun2 = new Odev3.Urun();
        urun.Ad = "Fırın";
        urun2.Fiyat = 2111;

        Odev3.Siparis siparis = new Odev3.Siparis(urun,urun2);
        siparis.SiparisOlustur();

    }
}