using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildlifeBackend.Engine;

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
            return Ok(_engine.GetWorld());
        }
    }
}
