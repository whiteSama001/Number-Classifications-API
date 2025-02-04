namespace Number_Classification_API.Services
{
    public interface INumberClassificationService
    {
        bool IsPrime(int num);
        bool IsPerfect(int num);
        bool IsArmstrong(int num);
        int GetDigitSum(int num);
        List<string> GetProperties(int num);
        Task<string> GetFunFact(int num);
    }

}
