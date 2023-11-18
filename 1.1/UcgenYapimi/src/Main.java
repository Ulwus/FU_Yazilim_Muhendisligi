import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        System.out.print("Satır Sayısını Seçiniz: ");
        int yEkseni = input.nextInt(), i, j, a = 1;

        System.out.print("Artış Miktarını Seçiniz: ");
        int artis = input.nextInt();

        for (i = 0; i < yEkseni; i++) {
            for (j = 0; j < a; j++) {
                System.out.print("*  ");
            }
            System.out.println();
            a = a + artis;

        }
    }
}

