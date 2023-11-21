import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        System.out.print("Kaç Tane Üçgensel Sayı Yazdırmak İstiyorsunuz?: ");
        int i = 1, sayi = input.nextInt(), sonsayi = 0;


        for (; i <= sayi; i++) {
            int son = i + sonsayi;
            sonsayi = son;
            System.out.print(son + "  ");
        }

    }
}