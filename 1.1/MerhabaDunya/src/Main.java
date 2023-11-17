import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int i;
        System.out.print("Lütfen Sayı Giriniz: ");
        int sayi = input.nextInt();
        for (i = 0; i < sayi; i++) {
            System.out.println("Merhaba Dünya");
        }
    }
}