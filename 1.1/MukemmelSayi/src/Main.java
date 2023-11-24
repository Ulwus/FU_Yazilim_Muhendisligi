import java.util.Scanner;

public class Main {

    public static void main(String[] args){

        Scanner input = new Scanner(System.in);

        int sayi = input.nextInt(),toplam = 0;

        for (int i = 1; i < sayi; i++){
            if (sayi % i == 0){
                toplam = toplam + i;
            }
        }
        if (toplam == sayi){
            System.out.println("Sayı Mükemmel Sayıdır!");
        }else {
            System.out.println("Sayı Mükemmel Sayı Değildir!");
        }

    }
}