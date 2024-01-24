import java.util.*;
public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int xKenar = input.nextInt();
        int yKenar = input.nextInt();

        for (int i = 0; i < yKenar; i++){
            for (int j = 0; j < xKenar; j++){
                System.out.print("* ");
            }
            System.out.println();
        }
    }
}