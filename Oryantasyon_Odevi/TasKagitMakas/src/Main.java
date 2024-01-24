import java.util.*;
public class Main {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        Random random = new Random();

        // 0 TAŞ, 1 KAĞIT, 2 MAKAS

        int kullaniciDegeri = input.nextInt();
        int robotDegeri = random.nextInt(3);
        System.out.println(robotDegeri);

        if ((kullaniciDegeri == 0 && robotDegeri == 2) || (kullaniciDegeri == 1 && robotDegeri == 0) || (kullaniciDegeri == 3 && robotDegeri == 1)){
            System.out.println("Oyunu Kazandın");
        }else{
            System.out.println("Oyunu Kaybettin");
        }
    }
}