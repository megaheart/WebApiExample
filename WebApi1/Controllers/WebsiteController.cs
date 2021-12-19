using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApi1
{
    [Route("")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Download()
        {
            Stream stream = System.IO.File.Open("Contents/index.html", FileMode.Open);

            if (stream == null)
                return NotFound(); // returns a NotFoundResult with Status404NotFound response.

            return File(stream, "text/html"); // returns a FileStreamResult
        }
    }
}
