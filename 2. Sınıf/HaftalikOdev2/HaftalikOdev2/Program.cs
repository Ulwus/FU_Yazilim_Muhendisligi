using System;
class Program
{
    public static void Main()
    {
        System.Console.WriteLine("Soru numarasini giriniz: ");
            int soruNo = Convert.ToInt32(Console.ReadLine());

        switch (soruNo)
        {
            case 1:

                //Bitti.
                Soru1.Run();
                break;
            case 2:
                //Bitti.
                Soru2.Run();
                break;
            case 3:
                Soru3.Run();
                break;
            case 4:
                Soru4.Run();
                break;
            case 5:
                Soru5.Run();
                break;
            case 6:
                Soru6.Run();
                break;
            case 7:
                Soru7.Run();
                break;
            case 8:
                Soru8.Run();
                break;
            case 9:
                Soru9.Run();
                break;
            case 10:
                Soru10.Run();
                break;
            default:
                Console.WriteLine("Boyle bir soru yok.");
                break;


        }
    }
}