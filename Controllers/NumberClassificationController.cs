using Microsoft.AspNetCore.Mvc;
using Number_Classification_API.Models.NumberClassificationAPI.Models;
using Number_Classification_API.Services;
using System.Threading.Tasks;

namespace NumberClassificationAPI.Controllers
{
    [ApiController]
    [Route("api/classify-number")]
    public class NumberClassificationController : ControllerBase
    {
        private readonly INumberClassificationService _numberService;

        public NumberClassificationController(INumberClassificationService numberService)
        {
            _numberService = numberService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string number)
        {
            if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int num))
            {
                return BadRequest(new
                {
                    number = "alphabet",
                    error = true
                });
            }

            // Perform synchronous computations (fast)
            bool isPrime = _numberService.IsPrime(num);
            bool isPerfect = _numberService.IsPerfect(num);
            int digitSum = _numberService.GetDigitSum(num);
            var properties = _numberService.GetProperties(num);

            // Fetch fun fact asynchronously (with timeout)
            string funFact = await _numberService.GetFunFact(num);

            var response = new NumberClassificationResponse
            {
                Number = num,
                IsPrime = isPrime,
                IsPerfect = isPerfect,
                Properties = properties,
                DigitSum = digitSum,
                FunFact = funFact
            };

            return Ok(response);
        }
    }
}
