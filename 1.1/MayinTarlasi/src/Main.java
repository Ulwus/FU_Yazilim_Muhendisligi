import java.util.Random;
import java.util.Scanner;


public class Main {

    static boolean hile = false;

    static int sayac = 0;
    static int ilk = -31;
    static int ikinci = -31;

    static int kareBoyutu = 31;

    static Scanner input = new Scanner(System.in);

    static int[][] dizi = null;
    static String[][] gercekDizi = null;

    static String[][] sonDizi = null;

    static int bombaSayisi = 0;


    public static void main(String[] args) {

        System.out.print("Lütfen Oyun Alanı Karesinin Bir Kenarını Giriniz: ");
        kareBoyutu = input.nextInt();

        if (kareBoyutu == 0) {
            System.out.println("Hatalı Giriş!");
            System.exit(1);

        } else if (kareBoyutu < 0) {
            hile = true;
            System.out.println("Hile Açıldı!");
            kareBoyutu = Math.abs(kareBoyutu);
        }


        gercekOyunDizisi();
        diziOlustur(kareBoyutu);


        while (true) {

            diziGoster();
            System.out.print("Koordinat Yeri Giriniz: ");
            ilk = input.nextInt() - 1;
            ikinci = input.nextInt() - 1;

            //Oyun Sınırları Dışında Bir Koordinat Girildiğinde Oyun Sonlandırılır..
            if (ilk < 0 || ikinci < 0 || ilk >= kareBoyutu || ikinci >= kareBoyutu) {
                System.out.println("Oyun Bitmiştir, Hatalı Giriş!");
                System.exit(3);
            }

            System.out.print("İşlem Seçiniz(Bayrak Atmak İçin - b, Mayın Tarlasında Gezinmek İçin - g): ");
            String islem = input.next();
            islem = islem.toLowerCase();


            //Kullanıcının Seçtiği İşlemi Yapar. Gerekli Fonksiyonları Çağırır
            switch (islem) {
                case "b":
                    bayrakIslemi(ilk, ikinci);
                    break;
                case "g":
                    oyunIslemi(ilk, ikinci);
                    break;
                default:
                    System.out.println("Hatalı Giriş!");
            }
        }

    }

    //Kullanıcıya Gösterilmen Fakat Oyunun Temel Oyun Dizisini Oluşturma Fonksiyonu
    public static void diziOlustur(int sayi) {

        //Diziyi Oluşturur.
        dizi = new int[sayi][sayi];

        for (int i = 0; i < sayi; i++) {
            for (int j = 0; j < sayi; j++) {
                dizi[i][j] = 0;
            }
        }


        //Bombaları Rastgele Yerlere Sayının Maksimum 2 Katı Sayıda Yerleştirir.
        Random random = new Random();


        for (int i = 0; i < sayi * 2; i++) {
            int ilkDeger = random.nextInt(sayi);
            int ikinciDeger = random.nextInt(sayi);
            if (dizi[ilkDeger][ikinciDeger] != 9) {
                dizi[ilkDeger][ikinciDeger] = 9;
                bombaSayisi++;
            } else if (kareBoyutu > 6 && dizi[ilkDeger][ikinciDeger] == 9) {
                i--;
            } else {
                i += 2;
            }

        }


        //Sayıları Düzenler
        for (int i = 0; i < sayi; i++) {
            for (int j = 0; j < sayi; j++) {
                diziKontrol(i, j);
            }
        }

        System.out.println("Bomba Sayısı: " + bombaSayisi);

        System.out.println("Oyun Haritası Oluşturuldu!");
    }


    //Dizi Haritasını Gösterir.
    public static void diziGoster() {

        diziGosterme(gercekDizi);


        sonDizi = new String[dizi.length][dizi.length];

        for (int i = 0; i < dizi.length; i++) {

            for (int j = 0; j < dizi.length; j++) {

                if (dizi[i][j] == 9) {
                    sonDizi[i][j] = "💣";
                } else {
                    sonDizi[i][j] = "🧱";
                }
            }
        }

        //Oyun Haritasını Yazdıran Kod
        if (hile) {
            System.out.println("Oyun Haritası!");
            diziGosterme(sonDizi);
        }

    }

    public static void diziGosterme(String[][] stringDizi) {
        System.out.println("----------------------------");

        for (String[] x : stringDizi) {

            for (int j = 0; j < dizi.length; j++) {

                System.out.print(x[j] + "\u2004");
            }
            System.out.println();
        }

        System.out.println("----------------------------");
    }

    //Çapraz Dahil Bütün Yönleri Kontrol Edip Etrafında Bomba Varsa Dizisindeki Değerini Bir Arttıran Fonksiyon
    public static void diziKontrol(int bir, int iki) {

        int max = dizi.length - 1;

        if (iki > 0 && dizi[bir][iki] != 9 && dizi[bir][iki - 1] == 9) {
            dizi[bir][iki]++;
        }

        if (bir < max && dizi[bir][iki] != 9 && dizi[bir + 1][iki] == 9) {
            dizi[bir][iki]++;
        }

        if (iki < max && dizi[bir][iki] != 9 && dizi[bir][iki + 1] == 9) {
            dizi[bir][iki]++;
        }

        if (bir > 0 && dizi[bir][iki] != 9 && dizi[bir - 1][iki] == 9) {
            dizi[bir][iki]++;
        }

        //Çapraz Kontrolleri

        if (bir < max && iki > 0 && dizi[bir][iki] != 9 && dizi[bir + 1][iki - 1] == 9) {
            dizi[bir][iki]++;
        }

        if (bir < max && iki < max && dizi[bir][iki] != 9 && dizi[bir + 1][iki + 1] == 9) {
            dizi[bir][iki]++;
        }

        if (bir > 0 && iki < max && dizi[bir][iki] != 9 && dizi[bir - 1][iki + 1] == 9) {
            dizi[bir][iki]++;
        }

        if (bir > 0 && iki > 0 && dizi[bir][iki] != 9 && dizi[bir - 1][iki - 1] == 9) {
            dizi[bir][iki]++;
        }

    }

    //Oyuncuya Gösterilecek Olan Dizinin Yapımı
    public static void gercekOyunDizisi() {
        gercekDizi = new String[kareBoyutu][kareBoyutu];
        for (int i = 0; i < kareBoyutu; i++) {
            for (int j = 0; j < kareBoyutu; j++) {
                gercekDizi[i][j] = "🧱";
            }
            System.out.println();
        }
    }

    //Oyunun Seçtiği Koordinatlarda Olan Mayının Varsa Oyunu Bittiğini Gösteren Fonksiyon.
    //Mayın Yoksa Oyuncuya Gösterilecek Değerini Gösteren Fonksiyon.
    public static void oyunIslemi(int bir, int iki) {

        switch (dizi[bir][iki]) {
            case 9:
                System.out.println("BOOOOOOOOOOOOOOOOOOOOOOOOOM!!!!!!!!!!!, Oyun Haritası");
                diziGosterme(sonDizi);
                System.exit(0);

            case 0:

            default:
                gercekDizi[bir][iki] = "\u2002" + dizi[bir][iki] + "\u2005";

        }

    }

    //Oyuncu Doğru Bir Şekilde Bayrak Yerleştirirse Oyunun Devam Ettiği ve Bütün Bayrakları Doğru
    //Şekilde Yerleştirirse Oyunu Kazanır.
    //Bayrakları Yanlış Yerleştirirse Oyunu Bittiğini Gösterir.
    public static void bayrakIslemi(int bir, int iki) {


        if (dizi[bir][iki] != 9) {
            System.out.println("Yanlış Kullanım Oyun Bitti!");
            diziGosterme(sonDizi);
            System.exit(1);
        } else {

            gercekDizi[bir][iki] = "🚩";

            sayac++;
            System.out.println("Bulunan Bomba Sayısı: " + sayac);
        }

        if (sayac == bombaSayisi) {
            System.out.println("Tebrikler Oyunu Kazandınız!");
            diziGoster();
            System.exit(31);
        }
    }


}