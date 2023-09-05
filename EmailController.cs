using HangOver1.Interface;
using HangOver1.Models;
using Microsoft.AspNetCore.Mvc;


namespace HangOver1.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmailController : Controller
	{

		private readonly IMailService mailService;
		private readonly HangOver1Context _dbContext;
		public EmailController(IMailService mailService, HangOver1Context context)
		{
			this.mailService = mailService;

           _dbContext = context;
		}

		[HttpPost("Send")]
		public async Task<IActionResult> Send(string email)
		{
			try
			{
				await mailService.SendEmailAsync(email);
				return Ok();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
		

			[HttpPost]
			public IActionResult SendEmail( MailRequest model)
			{
				try
				{
					List<string> userEmails = _dbContext.Users
						.Where(user => model.UserIds.Contains(user.UserId))
						.Select(user => user.Email)
						.ToList();

					foreach (var email in userEmails)
					{
					mailService.SendEmailAsync1(email, model.Subject, model.Body);
					}

					return Ok("Emails sent successfully.");
				}
				catch (Exception ex)
				{
					return BadRequest($"Error: {ex.Message}");
				}
			}
		}



	}
