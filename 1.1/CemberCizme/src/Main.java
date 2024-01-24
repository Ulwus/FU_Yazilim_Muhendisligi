import java.util.Scanner;

public class Main {

    public static void main(String[] args) {


        System.out.print("Lütfen Yarıçapı Giriniz!: ");
        Scanner input = new Scanner(System.in);


        int yaricap = input.nextInt() - 1;

        for (int yEkseni = -yaricap; yEkseni <= yaricap; yEkseni++) {

            for (int xEkseni = -yaricap; xEkseni <= yaricap; xEkseni++) {

                double cemberKontrol = Math.sqrt(xEkseni * xEkseni + yEkseni * yEkseni);

                if (cemberKontrol <= yaricap) {

                    System.out.print("* ");
                } else {
                    System.out.print("  ");
                }
            }
            System.out.println();
        }

    }
}