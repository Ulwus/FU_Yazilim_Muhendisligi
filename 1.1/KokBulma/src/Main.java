import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        System.out.println("ax² + bx + c denklemi için");

        System.out.print("a= ");
        int a = input.nextInt();

        System.out.print("b= ");
        int b = input.nextInt();

        System.out.print("c= ");
        int c = input.nextInt();

        double diskriminant = b * b - 4 * a * c;

        double x1 = (-b + Math.sqrt(diskriminant)) / (2 * a);
        double x2 = (-b - Math.sqrt(diskriminant)) / (2 * a);

        if (diskriminant > 0) {
            System.out.println("Denklemin iki tane farklı kökü mevcut. Diskriminant= " + diskriminant + " x1= " + x1 + " x2= " + x2);
        } else if (diskriminant == 0) {
            System.out.println("Denklemin iki tane aynı kökü mevcut. Diskriminant= " + diskriminant + " x1= " + x1 + " x2= " + x2);
        } else {
            System.out.println("Denklemin kökü yoktur. Diskriminant= " + diskriminant);
        }


    }
}