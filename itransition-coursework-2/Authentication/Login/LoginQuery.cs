using MediatR;
using DataAccess.Models;

namespace itransition_coursework_2.Authentication.Login
{
	public class LoginQuery : IRequest<UserAuthenticationModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
