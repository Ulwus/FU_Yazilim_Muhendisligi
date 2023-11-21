import java.util.Scanner;
import java.util.Random;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        Random random = new Random();
        int randomDeger = random.nextInt(3);

        System.out.print("Taş(0) mı, Kağıt(1) mı, Makas(2) mı?: ");
        int deger = input.nextInt();


        switch (deger) {
            case 0:
                if (randomDeger == 1) {
                    System.out.println("Maalesef Kaybettin! Seniç Seçtiğin: Taş, Bilgisayar: Kağıt");
                } else if (randomDeger == 2) {
                    System.out.println("Tebrikler Kazandın! Seniç Seçtiğin: Taş, Bilgisayar: Makas");
                } else {
                    System.out.println("Berabere! Seniç Seçtiğin: Taş, Bilgisayar: Taş");
                }
                break;
            case 1:
                if (randomDeger == 2) {
                    System.out.println("Maalesef Kaybettin! Seniç Seçtiğin: Kağıt, Bilgisayar: Makas");
                } else if (randomDeger == 0) {
                    System.out.println("Tebrikler Kazandın! Seniç Seçtiğin: Kağıt, Bilgisayar: Taş");
                } else {
                    System.out.println("Berabere! Seniç Seçtiğin: Kağıt, Bilgisayar: Kağıt");
                }
                break;
            case 2:
                if (randomDeger == 0) {
                    System.out.println("Maalesef Kaybettin! Seniç Seçtiğin: Makas, Bilgisayar: Taş");
                } else if (randomDeger == 1) {
                    System.out.println("Tebrikler Kazandın! Seniç Seçtiğin: Makas, Bilgisayar: Kağıt");
                } else {
                    System.out.println("Berabere! Seniç Seçtiğin: Makas, Bilgisayar: Makas");
                }
                break;
            default:
                System.out.println("Yanlış Değer Girişi Tekrar Deneyin!");
        }


    }
}
