namespace Number_Classification_API.Models
{
    namespace NumberClassificationAPI.Models
    {
        public class NumberClassificationResponse
        {
            public int Number { get; set; }
            public bool IsPrime { get; set; }
            public bool IsPerfect { get; set; }
            public List<string> Properties { get; set; }
            public int DigitSum { get; set; }
            public string FunFact { get; set; }
        }
    }

}
