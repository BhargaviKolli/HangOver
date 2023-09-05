using HangOver1.DTO;
using HangOver1.Models;
using HangOver1.Repositories;
using HangOver1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace HangOver1.Controllers
{
	[Route("[Controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly IPosts _postrepository;
		private readonly HangOver1Context _dbContext;
		private readonly IUsers _userRepository;


		public PostController(IPosts posts, HangOver1Context context,IUsers users)
		{
			_postrepository= posts;
			_dbContext = context;
			_userRepository= users;
		}

		/// <summary>
		/// Retrieves All the Users Posts
		/// </summary>
		/// <returns>Returns string response</returns>
		[HttpGet]
		public ActionResult GetAllPosts()
		{
			var posts = _postrepository.GetAllPosts();
			return Ok(posts);
		}

		/// <summary>
		/// Retrieves a specific Post by unique UserId
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{UserId}")]
		public ActionResult<PostDTO> GetPostByUserId(int UserId)
		{
			var post = _postrepository.GetPostByUserId(UserId);
			if (post == null)
			{
				return NotFound();
			}
			return Ok(post);
		}


	/// <summary>
	/// Retrieves a specific Post by unique id
	/// </summary>
	/// <param name="PostId">Post object</param>
	/// <returns>Returns string response</returns>
	[HttpGet("{PostId}")]
		public IActionResult GetPostsById(int PostId)
		{
			var post = _postrepository.GetPostById(PostId);
			if (post == null)
			{
				return NotFound();
			}
			return Ok(post);
		}




		/// <summary>
		/// Upload a Post 
		/// </summary>
		/// <param name="postdto">PostDTO Object</param>
		/// <returns>Returns string response</returns>

		[HttpPost("posts")]

		public IActionResult CreatePost(PostDTO postdto)
		{
			if (postdto == null)
			{
				return BadRequest();
			}
			var createdPost = _postrepository.CreatePost(postdto);
			return Ok();
		}



		/// <summary>
		/// Delete Post By PostId
		/// </summary>
		/// <param name="PostId">Post object</param>
		/// <returns>Returns string response</returns>
		[HttpDelete("{PostId}")]
		public ActionResult DeleteByPostId(int PostId)
		{

			_postrepository.DeleteByPostId(PostId);
			return NoContent();
		}


	}

}
