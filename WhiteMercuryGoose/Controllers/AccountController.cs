using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhiteMercuryGoose.Entities;
using WhiteMercuryGoose.Helpers;

namespace WhiteMercuryGoose.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
		private JwtSettings _jwtSettings;

		public AccountController(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}

		[HttpPost("authenticate")]
		public IActionResult Authenticate(User user)
		{
			if (user.Username == "jason" && user.Password == "shih")
			{
				var issuer = "https://localhost:7282";
				var audience = "https://localhost:7282";
				var key = Encoding.ASCII.GetBytes("WhiteMercuryGooseProjectKey");
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new[]
					{
						new Claim("Id", Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Sub, user.Username),
						new Claim(JwtRegisteredClaimNames.Email, user.Username),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
					 }),
					Expires = DateTime.UtcNow.AddMinutes(360),
					Issuer = issuer,
					Audience = audience,
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
				};
				var tokenHandler = new JwtSecurityTokenHandler();
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var jwtToken = tokenHandler.WriteToken(token);
				return Ok(jwtToken);
			}
			return Unauthorized();
		}
	}
}
