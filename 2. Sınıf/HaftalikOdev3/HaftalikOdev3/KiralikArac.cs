using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*
 Giriş: Kullanıcıdan plaka ve günlük ücret değerleri alınıyor.
 Çıkış: Araç kiralama ve aracı teslim etme fonksiyonları ile kullanıcıya çıktı veriliyor.
 Kontrol: Arabanın müsaitlik durumuna göre araç kiralama veya aracı teslim etme işlemleri.
 Tekrar: -
 Matematik: -
*/

namespace HaftalikOdev3
{
    internal class KiralikArac
    {
        /*
        Normalde Camel Case kullanacaktım fakat ödevde böyle belirttiğiniz için değişken isimlerini böyle yaptım
        Özellikler: Plaka(string), GunlukUcret(decimal), MusaitMi(bool)
        Yapıcı Metot: Plaka ve günlük kiralama ücretini alarak başlatan bir yapıcı metot
        yazın.MusaitMi varsayılan olarak true olmalı.
        Metotlar: AraciKirala(), AraciTeslimEt() – Bu metotlar aracın uygunluk durumunu
        değiştirsin.
        */

        string Plaka;
        decimal GunlukUcret;
        bool MusaitMi;

        public KiralikArac(string Plaka, decimal GunlukUcret)
        {
            this.Plaka = Plaka;
            this.GunlukUcret = GunlukUcret;
            MusaitMi = true;

        }


        //Aracı MusaitMi değerini ile kiralama
        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine("Başarıyla Aracı Kiraladınız Aracın Ücreti: {0}, Aracın Plakası: {1}", GunlukUcret, Plaka);

            }
            else
            {
                Console.WriteLine("Araba Müsait Değil!");
            }
        }

        //Aracı MusaitMi değeri kontrolü ile teslim etme
        public void AraciTeslimEt() 
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine("Başarıyla Aracı Bıraktınız Aracın Plakası: {0}", Plaka);

            } else
            {
                Console.WriteLine("Araba Zaten Teslim Edilmiş");
            }

        }


    }
}
