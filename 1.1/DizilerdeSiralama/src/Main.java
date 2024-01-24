import java.util.Random;

public class Main {
    public static void main(String[] args) {
        int temp = 0;
        Random random = new Random();
        int[] dizi = new int[20];
        for (int i = 0; i < 20; i++) {
            dizi[i] = random.nextInt(100);
            System.out.print(dizi[i] + ", ");
        }

        for (int a = 0; a < dizi.length; a++) {
            for (int i = 0; i < dizi.length - 1; i++) {

                if (dizi[i] > dizi[i + 1]) {
                    temp = dizi[i];
                    dizi[i] = dizi[i + 1];
                    dizi[i + 1] = temp;

                }

            }
        }
        System.out.println();
        for (int sayi : dizi) {
            System.out.print(sayi + " < ");
        }
    }
}