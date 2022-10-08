using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhiteMercuryGoose.Entities;
using WhiteMercuryGoose.Helpers;
using WhiteMercuryGoose.Models.Account;

namespace WhiteMercuryGoose.Services
{
	public interface IUserService
	{
		AuthenticateResponse Authenticate(AuthenticateRequest model);
	}
	public class UserService : IUserService
	{
		private List<User> _users = new List<User>
		{
			new User { Id = 1, Username = "test", Password = "test" }
		};

		private JwtSettings _jwtSettings;

		public UserService(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}

		public AuthenticateResponse Authenticate(AuthenticateRequest model)
		{
			var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

			// return null if user not found
			if (user == null) return null;

			// authentication successful so generate jwt token
			var token = GenerateJwtToken(user);

			return new AuthenticateResponse(user, token);
		}

		private string GenerateJwtToken(User user)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
