using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Giriş: Kullanıcıdan nesneyi oluşturabilmek için hesap numarası, ve ilk bakiye gerekiyor.
 Çıkış: ParaYatir ve ParaCek fonksiyonları ile beraber para yatırma ve çekme fonksiyonları.
 Kontrol: Çekilecek para mevcut bakiyeden fazla mı
 Tekrar: -
 Matematik: Çekilen veya yatırılan para kontrolleri ve işlemleri
*/
namespace HaftalikOdev3
{
    public class BankaHesabi
    {

        /* 
         Normalde Camel Case kullanacaktım fakat ödevde böyle belirttiğiniz için değişken isimlerini böyle yaptım.
         Özellikler: HesapNumarasi (string), Bakiye (decimal) 
         Get/Set: Bakiye özelliği için sadece sınıf içinden erişilebilen bir set metodu yazın.
        Yapıcı Metot: Hesap numarasını ve ilk bakiyeyi alarak başlatan bir yapıcı metot
         yazın.
         Metotlar: ParaYatir(decimal miktar) ve ParaCek(decimal miktar) metotları yazın.Para
         çekme işleminde bakiye yetersizse işlem yapılmamalı.
*/

        decimal ilkBakiye;
        public string HesapNumarasi { get; set; }
        public decimal Bakiye { get; private set; }

        public BankaHesabi(string HesapNumarasi, decimal ilkBakiye)
        {
            this.HesapNumarasi = HesapNumarasi;
            Bakiye = ilkBakiye;
        }

        //Para yatırma işlemleri
        public void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine("Başarıyla Para Çekildi: {0}.", miktar);
        }

        //Para çekme ve kontrol işlemleri
        public void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine("Para çekildi: {0}", miktar);

            }
            else
            {
                decimal gerekenPara = miktar - Bakiye;
                Console.WriteLine("Yeterli Para Mevcut Değil Gereken Para: {0}", gerekenPara);

            }
        }

    }
}
