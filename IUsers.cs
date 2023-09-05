using HangOver1.Models;
using HangOver1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HangOver1.Repositories
{

	public interface IUsers
	{
		IEnumerable<User> GetAllUsers();

		UserFollowingPostsDTO GetUserByUserId(int userId);

		User CreateUser(User user);
		void UpdateUser(int UserId, User updatedUser);
		User DeleteUser(int UserId);

		UserFollowingPostsDTO GetUserAndFollowingPosts(int userId);


	}
}

