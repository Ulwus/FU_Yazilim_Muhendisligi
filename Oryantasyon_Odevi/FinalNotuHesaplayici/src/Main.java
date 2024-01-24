import java.util.*;
public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        double vizeNotu = input.nextDouble();
        double finalNotu = input.nextDouble();

        double sonuc = vizeNotu * 0.4 + finalNotu * 0.6;
        System.out.println(sonuc);
    }
}