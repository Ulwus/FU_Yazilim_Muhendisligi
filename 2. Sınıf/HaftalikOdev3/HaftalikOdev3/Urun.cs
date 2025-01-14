using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 Giriş: Ürün ismi, Ürün fiyatı ve ürünün indirim oranı
 Çıkış: Ürün bilgisini ekrana yazdırır
 Kontrol: -
 Tekrar: -
 Matematik: İndirim oranı ile mevcut ürünün fiyatında indirim uygular.
*/

namespace HaftalikOdev3
{
    internal class Urun
    {
        /*
         Normalde Camel Case kullanacaktım fakat ödevde böyle belirttiğiniz için değişken isimlerini böyle yaptım.
         Özellikler: Ad (string), Fiyat (decimal), Indirim (decimal) 
         Get/Set: İndirim için get/set metodları kullanın. İndirimi 0-50% arasında sınırlandırın.
         Yapıcı Metot: Ad ve fiyat bilgilerini parametre olarak alıp başlatan bir yapıcı metot tanımlayın. 
         Metot: IndirimliFiyat() metodu, indirimli fiyatı döndürsün.
         */

        decimal indirimOrani;

        string Ad;
        decimal Fiyat;

        // İndirim oranının %0-50 arasında değer verilecek şekilde set ve get ayarlandı.
        public decimal Indirim { 
            get
            {
                return indirimOrani;
            }
            set {
                if (value < 50 && value > 0)
                {
                    indirimOrani = value;
                }
                else
                {
                    Console.WriteLine("0-50 Arası Oran Belirle!");
                }
            } 
        }


        // Ürün bilgilerini ekrana yazdıran method
        public Urun(string Ad, decimal Fiyat) {
            this.Ad = Ad;
            this.Fiyat = Fiyat;
        }

        public decimal IndirimliFiyat()
        {
            return Fiyat * (100 - indirimOrani) / 100;
        }


    }
}
