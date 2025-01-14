using HaftalikOdev3;

/*
 Giriş:
 Çıkış:
 Kontrol:
 Tekrar:
 Matematik:
*/
public class Program
{
    public static void Main()
    {
        BankaHesabi bankaHesabi = new BankaHesabi("1210",8);
        bankaHesabi.ParaYatir(20);
        bankaHesabi.ParaCek(30);

        Urun urun = new Urun("Kitap", 100);
        urun.Indirim = 10;
        Console.WriteLine($"Ürünün Güncel Parası: {urun.IndirimliFiyat()}");

        KiralikArac kiralikArac = new KiralikArac("34AA3434", 1000);
        kiralikArac.AraciKirala();
        kiralikArac.AraciTeslimEt();

        Kisi kisi = new Kisi("Oğuzhan", "Gündüz", "505000000");
        Console.WriteLine("Merhaba, {0}", kisi.KisiBilgisi());

        Kutuphane kutuphane = new Kutuphane();
        Kitap kitap = new Kitap("Martin Eden","Jack London");
        Kitap kitap2 = new Kitap("Kızıl Veba", "Jack London");
        kutuphane.KitapEkle(kitap);
        kutuphane.KitapEkle(kitap2);
        kutuphane.KitaplariListele();

    }
}