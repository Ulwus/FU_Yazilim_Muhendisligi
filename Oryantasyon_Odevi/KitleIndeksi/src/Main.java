import java.util.*;
public class Main {
    public static void main(String[] args) {

        //Erkeklerde 25, Kadınlarda 23

        Scanner input = new Scanner(System.in);

        double boy = input.nextDouble() / 100;
        double kilo = input.nextDouble();
        double indeks = kilo / (boy * boy);

        int islem = input.nextInt();

        switch (islem){
            case 0:
                if (indeks >= 25){
                    System.out.println("Kilolusunuz!");
                }else {
                    System.out.println("Sağlıklısınız!");
                }
                break;

            case 1:
                if (indeks >= 23){
                    System.out.println("Kilolusunuz!");
                }else {
                    System.out.println("Sağlıklısınız!");
                }
                break;

            default:
                System.out.println("Hatalı Giriş!");

        }
    }
}