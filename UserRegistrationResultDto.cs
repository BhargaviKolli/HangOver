using System.ComponentModel.DataAnnotations;

namespace HangOver1.DTO
{
	public class UserRegistrationResultDto
	{

		[Required]
		public string FirstName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}