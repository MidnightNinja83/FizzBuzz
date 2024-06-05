using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;

        public FizzBuzzController(ILogger<FizzBuzzController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFizzy")]
        public string Get(string? input)
        {
            if (int.TryParse(input, out var number))
            {
                var div3 = number % 3 == 0;
                var div5 = number % 5 == 0;

                if (div3 && div5) return "FizzBuzz";
                if (div3) return "Fizz";
                if (div5) return "Buzz";

                return $"Divided {number} by 3\r\nDivided {number} by 5";
            }

            return "Invalid Item";
        }
    }
}
