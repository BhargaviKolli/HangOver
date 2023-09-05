using HangOver1.Models;
using System.Text.Json.Serialization;

namespace HangOver1.DTO
{

	public class UserDTO
	{
		public int UserId { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string? Mobile { get; set; }



	}
}
