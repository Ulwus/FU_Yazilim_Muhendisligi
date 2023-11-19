import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        double sonuc;

        System.out.print("İlk Sayıyı Giriniz: ");
        double ilkSayi = input.nextDouble();

        System.out.print("İkinci Sayıyı Giriniz: ");
        double ikinciSayi = input.nextDouble();

        System.out.print("İşlemi Giriniz (-, +, /, *): ");
        String islem = input.next();

        switch (islem) {
            case "*":
                sonuc = ilkSayi * ikinciSayi;
                System.out.println("İşleminin Sonucu: " + sonuc);
                break;

            case "+":
                sonuc = ilkSayi + ikinciSayi;
                System.out.println("İşleminin Sonucu: " + sonuc);
                break;

            case "-":
                sonuc = ilkSayi - ikinciSayi;
                System.out.println("İşleminin Sonucu: " + sonuc);
                break;

            case "/":
                sonuc = (ilkSayi / ikinciSayi);
                System.out.println("İşleminin Sonucu: " + sonuc);
                break;

            default:
                System.out.println("Hatalı İşlem Tekrar Deneyin!");
                break;

        }
    }
}