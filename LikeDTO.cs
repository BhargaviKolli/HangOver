using HangOver1.Models;
using System.Text.Json.Serialization;

namespace HangOver1.DTO
{
	public class LikeDTO
	{

		public int LikeId { get; set; }

		public int UserId { get; set; }

		public int PostId { get; set; }

		
	}
}
