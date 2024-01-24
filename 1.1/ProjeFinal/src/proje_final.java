import java.io.*;
import java.util.Objects;
import java.util.Scanner;

// Teknoloji Fakültesi, Yazılım Mühendisliği , Oğuzhan Gündüz, 230541054
//BOM BOM OYUNU
public class proje_final {

    static int SATIR = 10;
    static int SUTUN = 10;

    static String[][] dizi = new String[SATIR][SUTUN];

    static Scanner input = new Scanner(System.in);

    static int birinciDeger;
    static int ikinciDeger;

    public static void main(String[] args) throws IOException {

        //proje_final.txt, Dosyasındaki Sayıları Diziye Dönüştüren Fonksiyonu Çağırır.
        dosyadanDiziyeDonusturme();

        //Oyunun, Kullanıcıdan Alınan Değerlerden Biri 0 Olana Kadar Devam Etmesini Sağlayan Döngüdür.
        while (true) {

            //dosyaGosterme, Oyunun Durumunu Kullanıcıya Gösteren Fonksiyonu Çağırır.
            dosyaGosterme();

            //Kullanıcıdan Değerler Alınır.
            System.out.println("Lütfen Koordinatlari Giriniz!: ");
            birinciDeger = input.nextInt() - 1;
            ikinciDeger = input.nextInt() - 1;

            // Alınan Değerlerden Biri 0 İse Oyunun Son Halini Konsola Yazdırıp Oyunu Kapatır.
            if (birinciDeger == -1 || ikinciDeger == -1) {
                System.out.println("Oyun Bitmistir Oyunun Son Hali");
                dosyaGosterme();
                break;

            } else {
                //yukariOyunIslemi, Oyunun Her Adımda İşlemlerini Başlatan Fonksiyonu Çağırır.
                yukariOyunIslemi(ikinciDeger, birinciDeger);
            }
        }

    }//main

    //proje_final.txt, Dosyasındaki Sayıları Diziye Dönüştüren Fonksiyondur.
    public static void dosyadanDiziyeDonusturme() throws IOException {

        //File Sınıfını Dosyayı Açmak İçin Çağırırız.
        File dosya = new File("src/proje_final.txt");

        //FileReader Sınıfını Dosyayı Teker Teker Okumak İçin Çağırırız.
        FileReader dosyaOku = new FileReader(dosya);

        //BufferedReader Sınıfını, FileReader Sınıfının Okuduğu Değerleri Satır Satır Okumak İçin Çağırırız.
        BufferedReader bReader = new BufferedReader(dosyaOku);

        // İç İçe For Döngüsü İle Dosyadaki Tüm Sütunları Okumayı Sağlar.
        for (int i = 0; i < 10; i++) {

            // Satır Satır Okunmuş Dosyanın İçeriğinde Her 2 Boşluk Gördüğünde sayi Dizisine Aktarır.
            String[] sayi = bReader.readLine().split(" {2}");

            // İç İçe For Döngüsü İle Dosyadaki Tüm Satırları Okumayı Sağlar.
            for (int j = 0; j < 10; j++) {

                // İç İçe For Döngüsünden Elde Edilen Değerleri sayi Dizisinden Ana Dizimize Aktarır.
                dizi[j][i] = sayi[j];
            }
        }

        //Dosyayı Kapatmamızı Sağlar.
        bReader.close();

    }//Fonksiyon

    //Oyunun Durumunu Konsol Ekranına Yazdırmamızı Sağlayan Fonksiyondur.
    public static void dosyaGosterme() {
        System.out.println("--------------------------------------------");

        // Bu Döngü İle Sütun Sütun Değerler Okunur.
        for (int i = 0; i < SUTUN; i++) {

            // Bu Döngü İle Satır Satır Değerler Okunur.
            for (int j = 0; j < SATIR; j++) {

                //dizi, Ana Dizimizdeki Değeri İki Boşluk İle Ekrana Yazdırır.
                System.out.print(dizi[j][i] + "  ");
            }

            //Her Satır Okuma Döngüsü Bittiğinde Alt Satıra Geçer.
            System.out.println();
        }
        System.out.println("--------------------------------------------");

    }//Fonksiyon

    // Bu fonksiyon, 2 boyutlu dizinin yukarı kısmındaki eşleşen değerleri bulur ve "X" ile değiştirir.
    // Bu Fonksiyon; Sağa, Aşşağıya ve Sola Da İşlem Yapmak İçin Gerekli Fonksiyonları Çağırır.
    // Bu fonksiyon, Kendi Kendini Çağırma Yeteneğine Sahiptir.
    public static void yukariOyunIslemi(int yukariIlk, int yukariIkinci) {

        //Kullanıcıdan Alınan Değer ile Fonksiyona Döndürülen Değer Eşit İse;
        if (Objects.equals(dizi[ikinciDeger][birinciDeger], dizi[yukariIlk][yukariIkinci])) {

            //Fonksiyonda Döndürülen Değer Sol Köşede İse;
            if (yukariIkinci != 0) {

                //Fonksiyonda Döndürülen Değer ile Yukarıya Doğru İşlem Yapan Fonksiyonu Geri Çağırır.
                yukariOyunIslemi(yukariIlk, yukariIkinci - 1);

            }

            //Fonksiyonda Döndürülen x Eksenindeki Değerlerini Değerlendirir.
            switch (yukariIlk) {

                //Eğer Döndürülen Değer En Sol Kenarda İse;
                case 0:

                    //Bir Sonraki Değeri X Değil İse;
                    if (!Objects.equals(dizi[yukariIlk + 1][yukariIkinci], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Sağa Doğru İşlem Yapan Fonksiyonu Çağırır.
                        sagaOyunIslemi(yukariIlk + 1, yukariIkinci);
                    }

                    //Eğer Fonksiyonda Döndürülen y Ekseni Değeri Matrisin Sağ Kenarında Değil İse;
                    if (yukariIkinci != 9 && !Objects.equals(dizi[yukariIlk][yukariIkinci + 1], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                        assagiOyunIslemi(yukariIlk, yukariIkinci + 1);
                    }

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[yukariIlk][yukariIkinci] = "X";

                    //Durumu Sonlandırır.
                    break;

                //Eğer Döndürülen Değer En Sağ Kenarda İse;
                case 9:

                    //Bir Sonraki Değeri X Değil İse;
                    if (!Objects.equals(dizi[yukariIlk - 1][yukariIkinci], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Sola Doğru İşlem Yapan Fonksiyonu Çağırır.
                        solaOyunIslemi(yukariIlk - 1, yukariIkinci);
                    }

                    //Eğer Fonksiyonda Döndürülen y Ekseni Değeri Matrisin Sağ Kenarında Değil İse ve Bir Sonraki Değeri X Değil İse;
                    if (yukariIkinci != 9 && !Objects.equals(dizi[yukariIlk][yukariIkinci + 1], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                        assagiOyunIslemi(yukariIlk, yukariIkinci + 1);
                    }

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[yukariIlk][yukariIkinci] = "X";

                    //Durumu Sonlandırır.
                    break;

                //Eğer Döndürülen Değer Belirtilen Değerlerden Farklı İse;
                default:

                    //Bir Sonraki Değeri X Değil İse;
                    if (!Objects.equals(dizi[yukariIlk + 1][yukariIkinci], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Sağa Doğru İşlem Yapan Fonksiyonu Çağırır.
                        sagaOyunIslemi(yukariIlk + 1, yukariIkinci);
                    }

                    //Eğer Fonksiyonda Döndürülen y Ekseni Değeri Matrisin Sağ Kenarında Değil İse ve Bir Sonraki Değeri X Değil İse;
                    if (yukariIkinci != 9 && !Objects.equals(dizi[yukariIlk][yukariIkinci + 1], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                        assagiOyunIslemi(yukariIlk, yukariIkinci + 1);
                    }

                    //Bir Sonraki Değeri X Değil İse;
                    if (!Objects.equals(dizi[yukariIlk - 1][yukariIkinci], "X")) {

                        //Fonksiyonda Döndürülen Değer ile Sola Doğru İşlem Yapan Fonksiyonu Çağırır.
                        solaOyunIslemi(yukariIlk - 1, yukariIkinci);
                    }

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[yukariIlk][yukariIkinci] = "X";

            }


        }


    }//Fonksiyon

    // Bu fonksiyon, 2 boyutlu dizinin sağ kısmındaki eşleşen değerleri bulur ve "X" ile değiştirir.
    // Bu Fonksiyon; Yukarıya ve Aşşağıya Da İşlem Yapmak İçin Gerekli Fonksiyonları Çağırır.
    // Bu fonksiyon, Kendi Kendini Çağırma Yeteneğine Sahiptir.
    public static void sagaOyunIslemi(int sagaIlk, int sagaIkinci) {

        //Kullanıcıdan Alınan Değer ile Fonksiyona Döndürülen Değer Eşit İse;
        if (Objects.equals(dizi[ikinciDeger][birinciDeger], dizi[sagaIlk][sagaIkinci])) {

            //Eğer Fonksiyonda Döndürülen x Ekseni Değeri Matrisin Sağ Kenarında Değil İse;
            if (sagaIlk != 9) {

                dizi [sagaIlk] [sagaIkinci] = "X";
                //Fonksiyonda Döndürülen Değer ile Sağa Doğru İşlem Yapan Fonksiyonu Geri Çağırır.
                sagaOyunIslemi(sagaIlk + 1, sagaIkinci);
            }

            //Fonksiyonda Döndürülen y Eksenindeki Değerlerini Değerlendirir.
            yEkseniKontrol(sagaIlk, sagaIkinci);


        }

    }//Fonksiyon

    // Bu fonksiyon, 2 boyutlu dizinin aşşağı kısmındaki eşleşen değerleri bulur ve "X" ile değiştirir.
    // Bu Fonksiyon; Sağa ve Sola Da İşlem Yapmak İçin Gerekli Fonksiyonları Çağırır.
    // Bu fonksiyon, Kendi Kendini Çağırma Yeteneğine Sahiptir.
    public static void assagiOyunIslemi(int assagiIlk, int assagiIkinci) {

        //Kullanıcıdan Alınan Değer ile Fonksiyona Döndürülen Değer Eşit İse;
        if (Objects.equals(dizi[ikinciDeger][birinciDeger], dizi[assagiIlk][assagiIkinci])) {

            //Eğer Fonksiyonda Döndürülen y Ekseni Değeri Matrisin En Alt Kenarında Değil İse;
            if (assagiIkinci != 9 && !Objects.equals(dizi[assagiIlk][assagiIkinci + 1], "X")) {

                //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Geri Çağırır.
                assagiOyunIslemi(assagiIlk, assagiIkinci + 1);

            }

            //Fonksiyonda Döndürülen x Eksenindeki Değerlerini Değerlendirir.
            switch (assagiIlk) {

                //Fonksiyonda Döndürülen Değer En Sol Kenarında İse;
                case 0:

                    //Fonksiyonda Döndürülen Değer ile Sağa Doğru İşlem Yapan Fonksiyonu Çağırır.
                    sagaOyunIslemi(assagiIlk + 1, assagiIkinci);

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[assagiIlk][assagiIkinci] = "X";

                    //Durumu Sonlandırır.
                    break;

                //Fonksiyonda Döndürülen Değer En Sağ Kenarında İse;
                case 9:

                    //Fonksiyonda Döndürülen Değer ile Sola Doğru İşlem Yapan Fonksiyonu Çağırır.
                    solaOyunIslemi(assagiIlk - 1, assagiIkinci);

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[assagiIlk][assagiIkinci] = "X";

                    //Durumu Sonlandırır.
                    break;

                //Eğer Döndürülen Değer Belirtilen Değerlerden Farklı İse;
                default:

                    //Fonksiyonda Döndürülen Değer ile Sağa Doğru İşlem Yapan Fonksiyonu Çağırır.
                    sagaOyunIslemi(assagiIlk + 1, assagiIkinci);

                    //Fonksiyonda Döndürülen Değer ile Sola Doğru İşlem Yapan Fonksiyonu Çağırır.
                    solaOyunIslemi(assagiIlk - 1, assagiIkinci);

                    //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                    dizi[assagiIlk][assagiIkinci] = "X";


            }


        }

    }//Fonksiyon


    // Bu fonksiyon, 2 boyutlu dizinin sol kısmındaki eşleşen değerleri bulur ve "X" ile değiştirir.
    // Bu Fonksiyon; Yukarıya ve Aşşağıya Da İşlem Yapmak İçin Gerekli Fonksiyonları Çağırır.
    // Bu fonksiyon, Kendi Kendini Çağırma Yeteneğine Sahiptir.
    public static void solaOyunIslemi(int solaIlk, int solaIkinci) {

        //Kullanıcıdan Alınan Değer ile Fonksiyona Döndürülen Değer Eşit İse;
        if (Objects.equals(dizi[ikinciDeger][birinciDeger], dizi[solaIlk][solaIkinci])) {

            //Eğer Fonksiyonda Döndürülen x Ekseni Değeri Matrisin Sol Kenarında Değil İse;
            if (solaIlk != 0 && !Objects.equals(dizi[solaIlk - 1][solaIkinci], "X")) {

                //Fonksiyonda Döndürülen Değer ile Sola Doğru İşlem Yapan Fonksiyonu Geri Çağırır.
                solaOyunIslemi(solaIlk - 1, solaIkinci);

                //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                dizi[solaIlk][solaIkinci] = "X";
            }

            //Fonksiyonda Döndürülen y Eksenindeki Değerlerini Değerlendiren Fonksiyonu Çağırır.
            yEkseniKontrol(solaIlk, solaIkinci);

        }

    }//Fonksiyon


    //Fonksiyonda Döndürülen y Eksenindeki Değerleri Değerlendirir
    public static void yEkseniKontrol(int Ilk, int Ikinci) {
        switch (Ikinci) {

            //Eğer Döndürülen Değer En Üst Kenarında İse;
            case 0:

                //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                assagiOyunIslemi(Ilk, Ikinci + 1);

                //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                dizi[Ilk][Ikinci] = "X";

                //Durumu Sonlandırır.
                break;

            //Eğer Döndürülen Değer En Alt Kenarında İse;
            case 9:

                //Fonksiyonda Döndürülen Değer ile Yukarıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                yukariOyunIslemi(Ilk, Ikinci - 1);

                //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                dizi[Ilk][Ikinci] = "X";

                //Durumu Sonlandırır.
                break;

            //Eğer Döndürülen Değer Belirtilen Değerlerden Farklı İse;
            default:

                //Fonksiyonda Döndürülen Değer ile Yukarıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                yukariOyunIslemi(Ilk, Ikinci - 1);

                //Fonksiyonda Döndürülen Değer ile Aşşağıya Doğru İşlem Yapan Fonksiyonu Çağırır.
                assagiOyunIslemi(Ilk, Ikinci + 1);

                //Fonksiyonda Döndürülen Ana Dizideki Değeri X olarak değiştirir.
                dizi[Ilk][Ikinci] = "X";

        }
    }

}//Sınıf

