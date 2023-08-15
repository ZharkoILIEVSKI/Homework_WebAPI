using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_No_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var staticDb = new List<string> { "Zharko", "Gorjan", "Angela" };
            return Ok(staticDb);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var staticDb = new List<string> { "Zharko", "Gorjan", "Angela" };
            return Ok(staticDb[id-1]);
        }
    }
}
