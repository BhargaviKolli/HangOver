using HangOver1.Models;
using System.Text.Json.Serialization;

namespace HangOver1.DTO
{
	public class FollowDTO
	{

		public int? FollowerId { get; set; }

		public int? FollowingId { get; set; }

		public object Followings { get; set; }
		internal object Posts { get; set; }
	}
}
