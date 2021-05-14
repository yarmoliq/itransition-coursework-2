using MediatR;
using DataAccess.Models;

namespace API.Authentication.Login
{
	public class LoginQuery : IRequest<UserAuthenticationModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
