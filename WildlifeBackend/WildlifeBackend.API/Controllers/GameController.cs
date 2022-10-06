using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIldlifeBackend.Engine;

namespace WildlifeBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly WildlifeEngine _engine;

        public GameController(WildlifeEngine engine)
        {
            _engine = engine;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
