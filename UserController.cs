
using HangOver1.DTO;
using HangOver1.Models;
using HangOver1.Repositories;
using HangOver1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HangOver1.Controllers
{


	[Route("[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUsers _userRepository;
		private readonly ILogger<User> _logger;


		public UserController(ILogger<User> logger,IUsers users)
		{
			_userRepository = users;
			_logger = logger;
			_logger.LogInformation("user controller called ");
		}

				/// <summary>
		/// Retrieves All the User details
		/// </summary>
		[HttpGet]
		public ActionResult GetAllUers()
		{
			_logger.LogInformation("Users get method Starting.");

			var users = _userRepository.GetAllUsers();
			if (users == null)
			{
				return NotFound();
			}
			return Ok(users);

		}



		/*/// <summary>
		/// Retrieves a specific User by unique id
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{UserId}")]
		public ActionResult<User> GetUserByUserId(int UserId)
		{
			var user = _userRepository.GetUserByUserId(UserId);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}*/


		/// <summary>
		/// Upload new UserDetails 
		/// </summary>
		/// <param name="userdto">User object</param>
		/// <returns>Returns string response</returns>
		[HttpPost]
		public ActionResult CreateUser(UserDTO userdto)
		{
			var userdata = new User()
			{
				UserId = userdto.UserId,
				FirstName = userdto.FirstName,
				LastName = userdto.LastName,
				Email = userdto.Email,
				Password = userdto.Password,
				Mobile = userdto.Mobile
			};
			_userRepository.CreateUser(userdata);

			return Ok("User Created");
		}

		/// <summary>
		/// Update User By UserId
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpPut("{UserId}")]
		public IActionResult UpdateUser(int UserId, User updatedUser)
		{
			if (updatedUser == null)
			{
				return BadRequest();
			}
			

			try
			{
				_userRepository.UpdateUser(UserId, updatedUser);
				return Ok();
			}
			catch (ApplicationException ex)
			{
				return NotFound(ex.Message);
			}
		}

		/// <summary>
		/// Delete User By UserId
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpDelete("{userId}")]
		public IActionResult DeleteUser(int userId)
		{
			_logger.LogInformation("Users Delete method Starting.");

			var deletedUser = _userRepository.DeleteUser(userId);

			if (deletedUser == null)
			{
				return NotFound();
			}

			return Ok(deletedUser);
		}

		/// <summary>
		/// Retrieves a specific User by unique id
		/// </summary>
		/// <param name="UserId">User object</param>
		/// <returns>Returns string response</returns>
		[HttpGet("{UserId}")]
		public ActionResult<User> GetUserAndFollowingPosts(int UserId)
		{
			var user = _userRepository.GetUserAndFollowingPosts(UserId);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}



	}
}