using Microsoft.AspNetCore.Authorization;
using WhiteMercuryGoose.Models.Account;

namespace WhiteMercuryGoose.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
		// GET: api/<AccountController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<AccountController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<AccountController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<AccountController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AccountController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		[HttpPost("createToken")]
		public void CreateToken(User user)
		{

		}
	}
}
