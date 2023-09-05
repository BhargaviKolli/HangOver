using HangOver1.Models;

namespace HangOver1.DTO
{
	public class PostDTO
	{
		public int PostId { get; set; }

		public int? UserId { get; set; }
		public string? Caption { get; set; }
		public  string? ImageUrl { get; set; }


	}
}
