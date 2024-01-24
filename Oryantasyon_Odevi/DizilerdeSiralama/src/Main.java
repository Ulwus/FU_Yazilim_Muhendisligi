import java.util.*;
public class Main {
    public static void main(String[] args) {
        Random random = new Random();
        int[] dizi = new int[20];

        for (int i = 0; i < dizi.length; i++){
            dizi[i] = random.nextInt(100);
        }

        for (int i = 0; i < dizi.length; i++){
            for (int j = 0; j < dizi.length - 1; j++){
                if (dizi[j] > dizi[j+1]){
                    int temp = dizi[j];
                    dizi[j] = dizi[j + 1];
                    dizi[j + 1] = temp;
                }
            }
        }

        for (int sayi : dizi){
            System.out.print(sayi + " < ");
        }

    }
}
