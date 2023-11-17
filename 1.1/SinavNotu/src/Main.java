import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Vize Notunuz:");
        double vizeNotu = input.nextDouble();
        System.out.println("Final Notunuz:");
        double finalNotu = input.nextDouble();

        double Sonuc = vizeNotu * 0.4 + finalNotu * 0.6;

        if (finalNotu >= 50) {
            if (Sonuc >= 50) {
                System.out.println("Sınavdan Geçti:");
            } else {
                System.out.println("Sınavdan Kaldı:");
            }
        } else {
            System.out.println("Sınavdan Kaldı:");
        }
    }
}