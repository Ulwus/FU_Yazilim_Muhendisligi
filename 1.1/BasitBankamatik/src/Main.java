import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);

        int sifreData = 2332;
        double paraData = 24112;

        System.out.println("""
                ****************************************
                             ULWUS BANKASI
                     Lütfen Banka Şifrenizi Girin!!!
                ****************************************
                """);
        int sifreUser = input.nextInt();

        System.out.println("""
                ****************************************
                             ULWUS BANKASI
                             1-Para Çekimi
                             2-Para Yatırma
                           3-Bakiye Sorgulama
                                4-Çıkış
                ****************************************
                """);
        int islem = input.nextInt();

        System.out.println("""
                ****************************************
                             ULWUS BANKASI
                         Makbuz İstiyorsanız 1
                      Makbuz İstemiyorsanız 2'yi
                              Tuşlayınız!
                ****************************************
                """);
        int makbuz = input.nextInt();

        if (sifreUser != sifreData) {
            islem = 99;
        }

        switch (islem) {
            case 99:
                System.out.println("""
                        ****************************************
                                     ULWUS BANKASI
                                   Şifreniz Yanlış!!!
                        ****************************************
                        """);
                break;

            case 1:
                System.out.println("""
                        ****************************************
                                     ULWUS BANKASI
                                Para Miktarını Belirtin
                        ****************************************
                        """);
                double cekimMiktari = input.nextDouble();

                if (paraData >= cekimMiktari) {
                    paraData = paraData - cekimMiktari;

                    System.out.printf("""
                            ****************************************
                                         ULWUS BANKASI
                            %f Çektiğiniz Para
                            %f Kalan Paranız
                            ****************************************
                            """, cekimMiktari, paraData);

                    if (makbuz == 1) {
                        System.out.println("""
                                             ULWUS BANKASI
                                          MAKBUZ VERİLMİŞTİR!
                                ****************************************
                                """);
                    }

                } else {
                    System.out.println("""
                            ****************************************
                                         ULWUS BANKASI
                               Yeterli Para Miktarı Bulunmamakta!
                            ****************************************
                            """);
                }
                break;

            case 2:
                System.out.println("""
                        ****************************************
                                     ULWUS BANKASI
                                Para Miktarını Belirtin
                        ****************************************
                        """);
                double yatirimMiktari = input.nextDouble();
                paraData = paraData + yatirimMiktari;

                System.out.printf("""
                        ****************************************
                                     ULWUS BANKASI
                        %f Yatırdığınız Para
                        %f Kalan Paranız
                        ****************************************
                        """, yatirimMiktari, paraData);

                if (makbuz == 1) {
                    System.out.println("""
                                         ULWUS BANKASI
                                      MAKBUZ VERİLMİŞTİR!
                            ****************************************
                            """);
                }

                break;

            case 3:
                System.out.println("""
                        ****************************************
                                     ULWUS BANKASI
                             Para Miktarınını Görüntülemek
                             İçin %5 Komisyon Kesilecektir.
                              Reddetmek İçin 1'i Tuşlayın
                         Onay İçin Herhangi Bir Sayıyı Tuşlayın!
                        ****************************************
                        """);
                int onay = input.nextInt();

                if (onay != 1) {
                    paraData = paraData * 95 / 100;
                    System.out.printf("""
                            ****************************************
                                         ULWUS BANKASI
                            Paranız %f
                            ****************************************
                                        """, paraData);

                    if (makbuz == 1) {
                        System.out.println("""
                                             ULWUS BANKASI
                                          MAKBUZ VERİLMİŞTİR!
                                ****************************************
                                """);
                    }

                }
                break;

        }


    }
}