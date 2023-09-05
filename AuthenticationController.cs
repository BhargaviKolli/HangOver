using HangOver1.DTO;
using HangOver1.Interface;
using HangOver1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("[Controller]")]
[ApiController]
public class AuthrnticationController : ControllerBase
{
	private readonly IAuthentication _authenticationService;
	private readonly HangOver1Context _dbContext;


	public AuthrnticationController(IAuthentication authenticationService, HangOver1Context dbContext)
	{
		_authenticationService = authenticationService;
		_dbContext = dbContext;
	}

	/// <summary>
	///  Give the Valid Registration Details to Generate a Token
	/// </summary>
	/// <param name="requestDto">User object</param>
	/// <returns>Returns string response</returns>
	[HttpPost]
	[AllowAnonymous]
	public IActionResult Register(UserRegistrationResultDto requestDto)
	{
		var result = _authenticationService.Register(requestDto);

		if (result.Result)
		{
			return Ok(result);
		}
		else
		{
			return BadRequest();
		}
	}
	/// <summary>
	/// Login user
	/// </summary>
	/// <param name="logindto"></param>
	/// <returns></returns>
	[HttpPost("Login")]
	public  IActionResult Login(UserRegistrationResultDto logindto)
	{
		var result =  _authenticationService.Login(logindto);

		if (result.Result)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}



}
