using HangOver1.Models;

namespace HangOver1.DTO
{
	public class EmailDTO
	{

        public int UserId { get; set; }
		public string Email { get; set; }
        public int FollowingId { get; set; }
        public Object Follows  { get; set; }
		public Object Users { get; set; }
	}
}
