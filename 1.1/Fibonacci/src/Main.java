import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int sayi = input.nextInt();
        int i, F1 = 0, F2 = 1, F3 = F2 + F1;

        for (i = 1; i < sayi; i++) {
            F3 = F1 + F2;
            F1 = F2;
            F2 = F3;
        }
        System.out.println(F3);
    }

}