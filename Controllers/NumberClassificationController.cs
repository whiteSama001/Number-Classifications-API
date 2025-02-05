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
       

            var response = new NumberClassificationResponse
            {
                Number = num,
                IsPrime = _numberService.IsPrime(num),
                IsPerfect = _numberService.IsPerfect(num),
                Properties = _numberService.GetProperties(num),
                DigitSum = _numberService.GetDigitSum(num),
                FunFact = await _numberService.GetFunFact(num)
            };

            return Ok(response);
        }
    }
}
