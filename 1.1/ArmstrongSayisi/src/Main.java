import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        System.out.print("Lütfen Maksimum 4 Basamaklı Sayı Giriniz!: ");
        int sayi = input.nextInt();

        int onbinlerKontrolu = sayi % 10000;
        int binlerKontrolu = sayi % 1000;
        int yuzlerKontrolu = sayi % 100;
        int onlarKontrolu = sayi % 10;

        int birlerBasamagi = (onlarKontrolu);
        int onlarBasamagi = (yuzlerKontrolu - onlarKontrolu) / 10;
        int yuzlerBasamagi = (binlerKontrolu - yuzlerKontrolu) / 100;
        int binlerBasamagi = (onbinlerKontrolu - binlerKontrolu) / 1000;

        double sonuc;
        int basamak;

        if (sayi != onbinlerKontrolu) {
            System.out.println("Yanlış Sayı Seçimi!");


        } else if (sayi == onlarKontrolu) {
            System.out.println("Tek Basamaklı 0 Harici Her Sayı Armstrong Sayıdır!");


        } else if (sayi == yuzlerKontrolu) {
            System.out.println("İki Basamaklı Hiçbir Sayı Armstrong Sayı Değildir!");


        } else if (sayi == binlerKontrolu) {
            basamak = 3;
            sonuc = Math.pow(birlerBasamagi, basamak) + Math.pow(onlarBasamagi, basamak) + Math.pow(yuzlerBasamagi, basamak);
            if (sayi == (int) sonuc) {
                System.out.println(sayi + " Sayısı Armstrong Sayıdır!");
            } else {
                System.out.println(sayi + " Sayısı Armstrong Sayı Değildir!");
            }


        } else {
            basamak = 4;
            sonuc = Math.pow(birlerBasamagi, basamak) + Math.pow(onlarBasamagi, basamak) + Math.pow(yuzlerBasamagi, basamak) + Math.pow(binlerBasamagi, basamak);
            if (sayi == (int) sonuc) {
                System.out.println(sayi + " Sayısı Armstrong Sayıdır!");
            } else {
                System.out.println(sayi + " Sayısı Armstrong Sayı Değildir!");
            }
        }

    }


}
