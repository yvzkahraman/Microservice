using Microsoft.AspNetCore.Mvc;

namespace MarketModule.MarketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok();
        }
    }

}