import java.util.Objects;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Boyunuz: ");
        double boy = input.nextDouble();
        boy = boy / 100;

        System.out.print("Kilonuz: ");
        double kilo = input.nextDouble();

        System.out.print("Cinsiyet: ");
        String cinsiyet = input.next();

        double indeks = kilo / (boy * boy);

        if (Objects.equals(cinsiyet, "E")) {
            if (indeks >= 25) {
                System.out.println("Kilolusunuz! İndeks: " + indeks);
            } else {
                System.out.println("Normalsiniz! İndeks: " + indeks);
            }
        } else if (Objects.equals(cinsiyet, "K")) {
            if (indeks >= 23) {
                System.out.println("Kilolusunuz! İndeks: " + indeks);
            } else {
                System.out.println("Normalsiniz! İndeks: " + indeks);
            }

        } else {
            System.out.println("Hatalı Giriş Cinsiyetleri İçin Erkek: E, Kadın: K");

        }


    }
}