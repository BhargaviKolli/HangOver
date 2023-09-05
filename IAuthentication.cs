using HangOver1.DTO;
using HangOver1.Models;

namespace HangOver1.Interface
{
	public interface IAuthentication
	{

		public AuthResult Register(UserRegistrationResultDto requestDto);
		public AuthResult Login(UserRegistrationResultDto logindto);
	}
}
