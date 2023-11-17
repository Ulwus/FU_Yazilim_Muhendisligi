import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Bürüt Maaşınızı Giriniz: ");
        int burutMaas = input.nextInt();
        double netMaas;
        if (burutMaas < 5000) {
            netMaas = burutMaas * 0.85;
        } else if (burutMaas >= 10000) {
            netMaas = burutMaas * 0.75;
        }else{
            netMaas = burutMaas * 0.80;
        }

        System.out.println("Net Maaşınız: " + netMaas);
    }
}