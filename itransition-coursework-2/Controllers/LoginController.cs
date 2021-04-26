using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itransition_coursework_2.Login
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private IMediator _mediator;
        //protected IMediator Mediator;

        public LoginController(IMediator m)
        {
            _mediator = m;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginModel>> LoginAsync(LoginQuery query)
        {
            return await _mediator.Send(query);
        }

        //[HttpPost("registration")]
        //public async Task<ActionResult<UserLoginModel>> RegistrationAsync(RegistrationCommand command)
        //{
        //    return await Mediator.Send(command);
        //}
    }
}
