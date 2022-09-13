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
