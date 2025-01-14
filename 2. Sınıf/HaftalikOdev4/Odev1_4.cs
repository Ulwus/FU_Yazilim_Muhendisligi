using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Odev1_4
{
    internal class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        public string UrunBilgisi()
        {
            return $"{Ad}, İsimli Ürünün Fiyatı: {Fiyat}";
        }

    }


    // Burada UML diyagramında Sipariş için herhangi bir Ürünün refansını alan bir şey eklememişsiniz ama ikisi arasında bir tek yönlü ilişki olması için eklemeler yaptım.
    internal class Siparis
    {
        public DateTime Tarih { get; set; }
        public Decimal Toplam { get; set; }

        public List<Urun> Urunler { get; set; }

        public Siparis(params Urun[] urun)
        {
            Urunler = new List<Urun>();
            foreach (Urun i in urun)
            {
                Urunler.Add(i);
                Toplam += i.Fiyat;
            }

            Tarih = DateTime.Now;
        }

        public void SiparisOlustur()
        {
            Console.WriteLine($"{Urunler.Count()} Adet Ürün Sepette Toplam Tutar: {Toplam}");
        }
    }
}