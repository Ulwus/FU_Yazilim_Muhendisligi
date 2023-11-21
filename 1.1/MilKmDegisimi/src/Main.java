import java.util.Scanner;

public class Main{

    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        double katsayi = 1.609344, sonuc;


        System.out.print("Milden Kilometreye Geçiş İçin-> 1\nKilometreden Mile Geçiş İçin-> 2\nTuşuna Basın: ");
        int islem = input.nextInt();


        switch (islem){

            case 1:
                System.out.print("Mil Değerini Giriniz: ");
                int mil = input.nextInt();
                sonuc = mil * katsayi;
                System.out.println("Kilometre Değeriniz: " + sonuc);
                break;

            case 2:
                System.out.print("Kilometre Değerini Giriniz: ");
                int kilometre = input.nextInt();
                sonuc = kilometre / katsayi;
                System.out.println("Mil Değeriniz: " + sonuc);
                break;

            default:
                System.out.println("Hatalı Seçim Tekrar Dene!");
                break;

        }


    }
}