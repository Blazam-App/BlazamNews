using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazamNews.Pages.API
{
    [Route("api/newsitems")]
    [ApiController]
    public class NewsItemsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return NotFound();
        }
    }

}
