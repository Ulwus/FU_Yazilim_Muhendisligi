//Döngüde 5 yok!!!!

public class Main {
    public static void main(String[] args) {
        int i;
        for (i = 1; i < 11; i++) {
            if (i == 5) {
                i++;
            } else {
                double sonuc = i / (Math.pow(i, 2) + 2);
                System.out.println("Nokta: " + i + " Sonuç: " + sonuc);
            }
        }
    }
}