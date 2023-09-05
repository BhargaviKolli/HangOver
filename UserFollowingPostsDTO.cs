using System.Collections.Generic;
using Microsoft.VisualBasic;

public class UserFollowingPostsDTO
{
	public int UserId { get; set; }
	public string FirstName { get; set; }
	public object Posts { get; set; }
	public object Follows { get; set; }

}
