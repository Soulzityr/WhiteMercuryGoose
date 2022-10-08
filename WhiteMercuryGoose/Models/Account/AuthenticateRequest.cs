using System.ComponentModel.DataAnnotations;

namespace WhiteMercuryGoose.Models.Account
{
	public class AuthenticateRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
