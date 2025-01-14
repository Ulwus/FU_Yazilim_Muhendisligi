using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Giriş: Kullanıcıdan ad, soyad ve telefon numarası alınıyor.
 Çıkış: Kullanıcının bilgileri ekrana çıktı olarak veriliyor
 Kontrol: - 
 Tekrar: -
 Matematik: -
*/

namespace HaftalikOdev3
{
    internal class Kisi
    {
        /*
         Normalde Camel Case kullanacaktım fakat ödevde böyle belirttiğiniz için değişken isimlerini böyle yaptım.
         Özellikler: Ad, Soyad, TelefonNumarasi (string türünde)
         Yapıcı Metot: Ad, soyad ve telefon numarasını alarak başlatan bir yapıcı metot tanımlayın.
         Metot: KisiBilgisi() – Bu metot, kişinin tam adını ve telefon numarasını döndürsün.
        */

        string Ad, Soyad, TelefonNumarasi;


        public Kisi(string Ad, string Soyad, string TelefonNumarasi)
        {
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.TelefonNumarasi = TelefonNumarasi;

        }

        // Kullanıcının bilgilerini ekrana yazdırır.
        public string KisiBilgisi()
        {
            return $"İsim Soyisim: {Ad} {Soyad}, Telefon Numarasi: {TelefonNumarasi}";
        }
    }
}
