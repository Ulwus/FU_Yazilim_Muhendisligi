import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Lütfen Sayı Giriniz!: ");
        long sayi = input.nextLong();

        int kontrol = 0, carpim = 1, F1 = 0, F2 = 1, F3 = F1 + F2;

        for (int i = 2; i < sayi / 2; i++) {
            if (sayi % i == 0) {
                kontrol = 1;
                break;
            }
        }


        if (sayi % 2 == 0) {
            System.out.println("Sayı Çift: " + sayi);


        } else if (kontrol == 0) {
            for (int j = 1; j <= sayi; j++) {
                carpim = carpim * j;
            }
            System.out.println("Faktöriyel Değeri: " + carpim);

        } else {
            System.out.print("Fibonacci Değeri: 0" );
            for (int k = 1; k < sayi; k++) {
                F3 = F1 + F2;
                F1 = F2;
                F2 = F3;
                System.out.print(", " + F3);
            }


        }
    }
}
