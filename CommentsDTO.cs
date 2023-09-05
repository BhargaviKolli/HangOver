using HangOver1.Models;
using System.Text.Json.Serialization;

namespace HangOver1.DTO
{
	public class CommentsDTO
	{

		public int CommentId { get; set; }

		public int PostId { get; set; }

		public int UserId { get; set; }
        public string Content { get; set; }

    }
}
