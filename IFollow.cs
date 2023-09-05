using HangOver1.DTO;
using HangOver1.Models;

namespace HangOver1.Repositories
{
	public interface IFollow
	{
		List<Follow> GetAllFollowList();
		FollowDTO GeFollowingByFollowerId(int FollowerId);

		int GetFollowingCount(int followerId);
		FollowDTO Create(FollowDTO followdto);

	}
}
