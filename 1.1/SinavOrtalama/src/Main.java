import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Kişi Sayısı: ");
        int kisiSayisi = input.nextInt();
        int Toplam = 0;
        int i;
        for (i = 0; i < kisiSayisi; i++) {
            System.out.print("Alınan Not: ");
            int Not = input.nextInt();
            Toplam = Toplam + Not;
        }
        double Sonuc = Toplam / kisiSayisi;
        System.out.println(Sonuc);


    }
}