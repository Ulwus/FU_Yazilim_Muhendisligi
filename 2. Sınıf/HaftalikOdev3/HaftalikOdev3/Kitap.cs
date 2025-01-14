using System;
public class Kitap
{
    // Özellikler
    public string Baslik { get; set; }
    public string Yazar { get; set; }
    public int SayfaSayisi { get; set; }
    // Yapıcı Metot: Sadece başlık ve yazarı alarak başlatan, sayfa sayısını varsayılan olarak 100 atan metot

    public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
            SayfaSayisi = 100; // Varsayılan değer
        }
        // Kitap Bilgilerini Gösteren Metot
        
    public void KitapBilgisiGoster()
     {
            Console.WriteLine($"; Başlık: { Baslik}, Yazar: { Yazar }, Sayfa Sayısı: { SayfaSayisi } ");
     }
}
