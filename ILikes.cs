using HangOver1.DTO;
using HangOver1.Models;

namespace HangOver1.Repositories
{
	public interface ILikes
	{

		List<Like> GetLikes();

		LikeDTO Create(LikeDTO likedto);
		 Like GetByPostId(int PostId);

		 int GetLikesCount(int PostId);
		public void DeleteByUserId(int UserId);
	}
}
