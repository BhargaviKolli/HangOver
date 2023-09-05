using HangOver1.Models;

namespace HangOver1.Interface
{
	public interface IMailService
	{
		public Task SendEmailAsync(string email);


		public Task SendEmailAsync1(string to, string subject, string body);

	}
}
