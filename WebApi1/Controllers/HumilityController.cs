using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1
{
    [Route("api/humidity")]
    [ApiController]
    public class HumilityController : ControllerBase
    {
        private readonly MyContext _context;
        public HumilityController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool realtime)
        {
            if (realtime)
            {
                List<HumidityLog> logs = new List<HumidityLog>();
                var log = _context.HumidityLogs.OrderBy(e => e.Time).LastOrDefault();
                if(log == null) { return NotFound(); }
                logs.Add(log);
                return Ok(logs);
            }
            else
            {
                var o = _context.HumidityLogs.ToList();
                return Ok(o);
            }
        }
        [HttpPost("post")]
        public async Task<IActionResult> Post(HumidityLog log)
        {
            _context.HumidityLogs.Add(log);
            _context.SaveChanges();
            return Ok(log);
        }
    }
}
