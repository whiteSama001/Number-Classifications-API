using Newtonsoft.Json;

namespace Number_Classification_API.Services
{
    public class NumberClassificationService : INumberClassificationService
    {
        private readonly HttpClient _httpClient;

        public NumberClassificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool IsPrime(int num)
{
    if (num < 2) return false;
    if (num % 2 == 0 && num != 2) return false;

    for (int i = 3; i <= Math.Sqrt(num); i += 2) 
    {
        if (num % i == 0)
            return false;
    }
    return true;
}


        public bool IsPerfect(int num)
        {
            int sum = 1;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (i != num / i) sum += num / i;
                }
            }
            return num > 1 && sum == num;
        }

        public bool IsArmstrong(int num)
        {
            int sum = 0, temp = num, digits = num.ToString().Length;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }
            return sum == num;
        }

        public int GetDigitSum(int number)
        {
            int sum = 0;
            int sign = number < 0 ? -1 : 1;
            number = Math.Abs(number);

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum * sign;
        }


        public List<string> GetProperties(int num)
        {
            var properties = new List<string>();
            if (IsArmstrong(num)) properties.Add("armstrong");
            properties.Add(num % 2 == 0 ? "even" : "odd");
            return properties;
        }

        public async Task<string> GetFunFact(int num)
        {
            using HttpClient client = new();
            client.Timeout = TimeSpan.FromMilliseconds(300); // Set timeout to avoid long delays

            try
            {
                string url = $"http://numbersapi.com/{num}?json";
                var response = await client.GetStringAsync(url);
                return response;
            }
            catch
            {
                return "Fun fact not available due to timeout.";
            }
        }

    }
}

