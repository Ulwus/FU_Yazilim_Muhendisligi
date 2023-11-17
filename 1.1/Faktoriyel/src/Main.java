import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int carpim = 1;
        int sayi;

        for (sayi = input.nextInt(); sayi > 1; sayi = sayi - 1) {
            carpim = carpim * sayi;
        }
        System.out.println(carpim);
    }
}