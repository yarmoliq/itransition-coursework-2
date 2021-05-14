﻿using DataAccess.Models;
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
		private readonly UserManager<AppUser> _userManager;

		private readonly SignInManager<AppUser> _signInManager;

		private readonly IJwtGenerator _jwtGenerator;

		public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserAuthenticationModel> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new Exception("Couldnt login: email not found");
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				return new UserAuthenticationModel
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