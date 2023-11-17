import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Sayı Giriniz: ");
        int sayi = input.nextInt(), i, Toplam = 0;

        for (i = 0; i <= sayi; i++) {
            if (i % 2 == 0) {
                Toplam = Toplam + i;
            }
        }

        System.out.println(Toplam);
    }
}