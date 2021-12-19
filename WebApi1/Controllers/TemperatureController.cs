using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [Route("api/temperature")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly MyContext _context;
        public TemperatureController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool realtime)
        {
            if (realtime)
            {
                List<TemperatureLog> logs = new List<TemperatureLog>();
                var log = _context.TemperatureLogs.OrderBy(e => e.Time).LastOrDefault();
                if (log == null) { return Ok(logs); }
                logs.Add(log);
                return Ok(logs);
            }
            else
            {
                var o = _context.TemperatureLogs.ToList();
                return Ok(o);
            }
        }
        [HttpPost("post")]
        public async Task<IActionResult> Post(TemperatureLog log)
        {
            _context.TemperatureLogs.Add(log);
            _context.SaveChanges();
            return Ok(log);
        }
    }
}
