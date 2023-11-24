import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Birinci Sayıyı Giriniz!: ");
        int ilkSayi = input.nextInt();

        System.out.print("Birinci Sayıyı Giriniz!: ");
        int ikinciSayi = input.nextInt();

        int max = ilkSayi * ikinciSayi, min;

        min = Math.min(ikinciSayi, ilkSayi);

        System.out.print("Lütfen İşlem Seçiniz EBOB(1), EKOK(2)!: ");
        int islem = input.nextInt();

        switch (islem) {

            case 1:
                int ebob = 1;

                for (int i = 1; i <= min; i++) {
                    if (ilkSayi % i == 0 && ikinciSayi % i == 0) {
                        ebob = i;
                    }
                }

                System.out.println("Ebob: " + ebob);
                break;

            case 2:
                int ekok = ilkSayi * ikinciSayi;
                for (int i = max; i > 0; i--) {
                    if (i % ilkSayi == 0 && i % ikinciSayi == 0) {
                        ekok = i;

                    }
                }
                System.out.println("Ekok: " + ekok);
                break;

        }


    }
}