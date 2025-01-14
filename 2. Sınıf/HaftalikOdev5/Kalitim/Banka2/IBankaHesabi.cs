namespace HaftalikOdev5.Kalitim.Banka2
{
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }
}