using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASC.Online.AuctionApp.MockDataSeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockDataController : ControllerBase
    {
       

        private readonly ILogger<MockDataController> _logger;

        public MockDataController(ILogger<MockDataController> logger)
        { 
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Initial ACSAuctionDB database has been created in your local VS solution. Check Sql Server Object Explorer and verify in your local server.");
        }
    }
}
