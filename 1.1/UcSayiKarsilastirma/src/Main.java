import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);

        System.out.println("Lütfen Sayıları Sırayla Giriniz!");
        int birinciSayi = input.nextInt(), ikinciSayi = input.nextInt(), ucuncuSayi = input.nextInt();


        if (birinciSayi > ikinciSayi && birinciSayi > ucuncuSayi){
            if (ikinciSayi > ucuncuSayi){
                System.out.println(birinciSayi + " > " + ikinciSayi + " > "+ ucuncuSayi);
            }else{
                System.out.println(birinciSayi + " > " + ucuncuSayi + " > "+ ikinciSayi);
            }
        } else if (ikinciSayi > birinciSayi && ikinciSayi > ucuncuSayi) {
            if (birinciSayi > ucuncuSayi){
                System.out.println(ikinciSayi + " > " + birinciSayi + " > "+ ucuncuSayi);
            }else{
                System.out.println(ikinciSayi + " > " + ucuncuSayi + " > "+ birinciSayi);
            }
        }else{
            if (birinciSayi > ikinciSayi){
                System.out.println(ucuncuSayi + " > " + birinciSayi + " > "+ ikinciSayi);
            }else{
                System.out.println(ucuncuSayi + " > " + ikinciSayi + " > "+ birinciSayi);
            }
        }
    }
}