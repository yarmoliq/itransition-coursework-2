using DataAccess.Models;
using API.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Authentication.Login
{
	public class LoginHandler : IRequestHandler<LoginQuery, UserAuthenticationModel>
	{
		private readonly UserManager<AppUser> userManager;

		private readonly SignInManager<AppUser> signInManager;

		private readonly IJwtGenerator jwtGenerator;

		public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.jwtGenerator = jwtGenerator;
		}

		public async Task<UserAuthenticationModel> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new Exception("Couldnt login: email not found");
			}

			var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (!result.Succeeded)
			{
				throw new Exception("Couldnt login: wrong password");
			}

			return new UserAuthenticationModel
			{
				FirstName = user.FirstName,
				Token = jwtGenerator.CreateToken(user),
				UserName = user.UserName
			};
		}
	}
}
