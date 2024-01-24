import java.util.*;
public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int islem = input.nextInt();

        int ilkSayi = input.nextInt();
        int ikinciSayi = input.nextInt();

        switch (islem){
            case 1:
                System.out.println(ilkSayi + ikinciSayi);
                break;

            case 2:
                System.out.println(ilkSayi - ikinciSayi);
                break;

            case 3:
                System.out.println(ilkSayi*ikinciSayi);
                break;

            case 4:
                System.out.println(ilkSayi/ikinciSayi);
                break;

            default:
                System.out.println("Hatalı Giriş");
        }

    }
}