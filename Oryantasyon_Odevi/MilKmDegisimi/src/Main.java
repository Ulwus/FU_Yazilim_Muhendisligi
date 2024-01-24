import java.util.*;
public class Main {
    public static void main(String[] args) {
        double katsayi = 1.609344;

        Scanner input = new Scanner(System.in);
        double mil = input.nextInt();
        double km = mil * katsayi;
        System.out.println(km);
    }
}