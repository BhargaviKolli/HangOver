using HangOver1.DTO;
using HangOver1.Models;
using HangOver1.Repositories;
using HangOver1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangOver1.Controllers
{
	
		[Route("[Controller]")]
		[ApiController]
	
		public class FollowController : ControllerBase
		{


		private readonly IFollow _followRepository;


		public FollowController(IFollow follow)
		{
			_followRepository = follow;
		}

		/// <summary>
		///  Retrieves  All the Follow Lists
		/// </summary>
		/// <returns>Returns string response</returns>
		[HttpGet]
		public ActionResult GetAllFollowList()
		{
		var followList = _followRepository.GetAllFollowList();
			return Ok(followList);
		}

		/// <summary>
		///  Retrieves All the Followings of a Follower 
		///  </summary>
		/// <param name="FollowerId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{FollowerId}")]
			public ActionResult<FollowDTO> GetFollowingByFollowerId(int FollowerId)
			{
			var follows = _followRepository.GeFollowingByFollowerId(FollowerId);
				if (follows == null)
				{
					return NotFound();
				}
				return Ok(follows);
			}




		/// <summary>
		/// Retrieves Number of Followings are there to a User
		/// </summary>
		/// <param name="FollowerId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpGet]
		[Route("count/{FollowerId}")]
		public ActionResult GetFollowingCount(int FollowerId)
		{
			try
			{
				int follwerCount = _followRepository.GetFollowingCount(FollowerId);

				return Ok(follwerCount);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}

		/// <summary>
		/// Follow a User
		/// </summary>
		/// <param name="followdto">User object</param>
		/// <returns>Returns string response</returns>
		[HttpPost]
			public ActionResult Create(FollowDTO followdto)
		    { 
			    _followRepository.Create(followdto); 
				return Ok("follower is added");
			}
		}
}
