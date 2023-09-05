using HangOver1.DTO;
using HangOver1.Models;
using HangOver1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HangOver1.Controllers
{

	[Route("[Controller]")]
	[ApiController]

	public class LikeController : ControllerBase
	{
		
		private readonly LikeService likeService;


		public LikeController(LikeService likeservice)
		{
			likeService = likeservice;
		}

		/// <summary>
		/// Retrieves All the Likes
		/// </summary>
		/// <returns>Returns string response</returns>
		[HttpGet]
		public ActionResult GetLikes()
		{
			var likes = likeService.GetLikes();
			if (likes == null)
			{
				return NotFound();
			}
			return Ok(likes);
		}
		/// <summary>
		/// Like a Post
		/// </summary>
		/// <param name="likedto">likedto object</param>
		/// <returns>Returns string response</returns>
		[HttpPost]
		public ActionResult Create(LikeDTO likedto)
		{
		
			return Ok("like is saved");
		}
		/// <summary>
		/// Retrieves All the Likes to a post by PostId
		/// </summary>
		/// <param name="PostId">Post object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{PostId}")]
		public ActionResult GetByPostId(int PostId) {
			var likes = likeService.GetByPostId(PostId);
			return Ok(likes);
		}

		/// <summary>
		/// Retrieves Number of Comments got for a Post by PostId
		/// </summary>
		/// <param name="PostId">Post object</param>
		/// <returns>Returns string response</returns>
		[HttpGet]
		[Route("count/{postId}")]
		public ActionResult GetLikesCount(int postId)
		{
			try
			{
				int likesCount = likeService.GetLikesCount(postId);

				return Ok(likesCount);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
		/// <summary>
		/// Delete Like of a Post By UserId
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpDelete("{UserId}")]
		public ActionResult DeleteByUserId(int UserId)
		{

			likeService.DeleteByUserId(UserId);
			return NoContent();
		}

	}
}
