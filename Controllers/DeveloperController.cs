using MergeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MergeMe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        [Route("/developers")]
        [HttpPost]

        public async Task<ActionResult<Developer>> CreateDeveloper(Developer developer)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult GetDevelopers()
        {
            return Ok();
        }
    }
}
