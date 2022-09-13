using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhiteMercuryGoose.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatusController : ControllerBase
	{
		// GET api/<StatusController>/5
		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			return Ok();
		}
	}
}
