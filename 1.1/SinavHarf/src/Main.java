import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Sınav Notunuz: ");
        int sinavNotu = input.nextInt();

        if (sinavNotu >= 80) {
            System.out.println("Sınav Notunuz: A");
        } else if (sinavNotu >= 70) {
            System.out.println("Sınav Notunuz: B");
        } else if (sinavNotu >= 60) {
            System.out.println("Sınav Notunuz: C");
        } else if (sinavNotu >= 50) {
            System.out.println("Sınav Notunuz: D");
        } else {
            System.out.println("Sınavdan Kaldınız");
        }

    }
}