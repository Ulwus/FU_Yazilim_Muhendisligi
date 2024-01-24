import java.util.*;
public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int ilkSayi = input.nextInt();
        int ikinciSayi = input.nextInt();
        int max = ilkSayi * ikinciSayi;
        int ekok = 1;

        for (int i = 1; i < max; i++){
            if (i % ilkSayi == 0 && i % ikinciSayi == 0){
                ekok = i;
                break;
            }
        }
        System.out.println(ekok);
    }
}