using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Models;
using itransition_coursework_2.Authentication.Login;

namespace itransition_coursework_2.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAuthenticationModel>> LoginAsync(LoginQuery query)
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