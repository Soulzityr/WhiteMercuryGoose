using Microsoft.AspNetCore.Authorization;
using WhiteMercuryGoose.Entities;
using WhiteMercuryGoose.Models.Account;
using WhiteMercuryGoose.Services;

namespace WhiteMercuryGoose.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
		private IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("authenticate")]
		public IActionResult Authenticate(AuthenticateRequest model)
		{
			var response = _userService.Authenticate(model);

			if (response == null) return BadRequest(new { message = "Incorrect credentials" });

			return Ok(response);
		}
	}
}
