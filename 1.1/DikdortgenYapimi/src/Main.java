import java.util.Scanner;

public class Main {

    public static void main(String[] args){

        Scanner input = new Scanner(System.in);

        int x = input.nextInt(), i, j, y = input.nextInt();

        for (i = 0; i < x; i++){
            for (j = 0; j < y; j++){
                System.out.print("*  ");
            }
        System.out.println("");
        }
    }
}

