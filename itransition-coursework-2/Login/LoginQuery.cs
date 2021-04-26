using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itransition_coursework_2.Login
{
	public class LoginQuery : IRequest<UserLoginModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
