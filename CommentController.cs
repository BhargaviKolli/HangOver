
using HangOver1.DTO;
using HangOver1.Models;
using HangOver1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HangOver1.Controllers
{

	[Route("[Controller]")]
	[ApiController]
	[Authorize]
	
	public class CommentController : ControllerBase
	{
		private readonly CommentService commentService;


		public CommentController(CommentService service)
		{
			commentService = service;
		}


		/// <summary>
		/// Retrieves All The Comments 
		/// </summary>
		/// <returns>Returns string response</returns>
		[HttpGet]
		public ActionResult GetAllComments()
		{
			var comments =commentService.GetAllComments();
			return Ok(comments);
		}

		/// <summary>
		/// Retrieves All The Comments got for a Post by PostId 
		/// </summary>
		/// <param name="PostId">Post object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{PostId}")]
		public ActionResult GetByPostId(int PostId)
		{
			var comments = commentService.GetCommentsByPostId(PostId);
			return Ok(comments);
		}

		/// <summary>
		/// Post a Comment to a Post
		/// </summary>
		/// <param name="commentsdto">Fill the comment Details</param>
		/// <returns>Returns string response</returns>
		[HttpPost]
		public ActionResult PostComment(CommentsDTO commentsdto)
		{
			var comment=commentService.PostComment(commentsdto);
             return Ok(comment);
		}

		/// <summary>
		/// Delete Comment of a Post By PostId
		/// </summary>
	    /// <param name="PostId">Post object</param>
		/// <returns>Returns string response</returns>
		[HttpDelete("{PostId}")]
		public ActionResult DeleteByPostId(int PostId)
		{

			commentService.DeleteByPostId(PostId);
			return NoContent();
		}

	}
}
