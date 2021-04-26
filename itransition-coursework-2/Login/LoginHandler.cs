using DataAccess.Models;
using itransition_coursework_2.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace itransition_coursework_2.Login
{
	public class LoginHandler : IRequestHandler<LoginQuery, UserLoginModel>
	{
		private readonly UserManager<AppUser> _userManager;

		private readonly SignInManager<AppUser> _signInManager;

		private readonly IJwtGenerator _jwtGenerator;

		public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserLoginModel> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new Exception("Couldnt login: email not found");
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				return new UserLoginModel
				{
					FirstName = user.FirstName,
					Token = _jwtGenerator.CreateToken(user),
					UserName = user.UserName
				};
			}

			throw new Exception("Couldnt login: wrong password");
		}
	}
}
