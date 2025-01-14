using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Giriş: Kitapların buluunduğu liste ve kitap bilgileri
 Çıkış: Kitapların bulunduğu liste
 Kontrol: -
 Tekrar: -
 Matematik: -
*/

namespace HaftalikOdev3
{
    internal class Kutuphane
    {
        /*
         Normalde Camel Case kullanacaktım fakat ödevde böyle belirttiğiniz için değişken isimlerini böyle yaptım.
         Özellik: Kitaplar (List<Kitap> türünde)
         Yapıcı Metot: Kitap listesi boş olarak başlatılsın.
         Metotlar: KitapEkle(Kitap yeniKitap) – Bu metot kitap eklesin ve KitaplariListele() metodu tüm kitapları ekrana yazdırsın. this anahtar kelimesini kullanarak eklenen kitabın kütüphaneye ait olduğunu belirtin.
        */

        List<Kitap> kitaplar;
        public Kutuphane() {
            kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap yeniKitap)
        {
            kitaplar.Add(yeniKitap);
            Console.WriteLine($"Başarıyla {yeniKitap.Baslik} Eklendi!");

        }

        //Mevcut bulunan kitapları ekrana yazdırır.

        public void KitaplariListele()
        {
            Console.WriteLine("Kitaplar: ");
            foreach (var i in kitaplar)
            {
                Console.WriteLine($"Kitap Başlığı: {i.Baslik}, Yazar: {i.Yazar}, Sayfa Sayısı: {i.SayfaSayisi}");
            }
        }
    }
}
