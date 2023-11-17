import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        System.out.print("Lütfen İlk Sayıyı Giriniz: ");
        int birinciSayi = input.nextInt();

        System.out.print("Lütfen İkinci Sayıyı Giriniz: ");
        int ikinciSayi = input.nextInt();

        if (birinciSayi > ikinciSayi){
            System.out.println("Birinci Sayı İkinci Sayıya Göre Büyük!");
        } else if (ikinciSayi > birinciSayi) {
            System.out.println("İkinci Sayı Birinci Sayıya Göre Büyük!");
        } else{
            System.out.println("Sayılar Eşit!");

        }

    }
}