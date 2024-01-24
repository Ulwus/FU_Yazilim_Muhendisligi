import java.util.*;
public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int faktoriyel = input.nextInt();
        int deger = faktoriyel(faktoriyel);
        System.out.println(deger);



    }

    public static int faktoriyel(int sayi){
        if (sayi == 1){
            return sayi;
        }

        return sayi * faktoriyel(sayi - 1);
    }

}