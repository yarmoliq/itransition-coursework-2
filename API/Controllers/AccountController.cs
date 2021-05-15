using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Models;
using API.Authentication.Login;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
    {
        private IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserAuthenticationModel>> LoginAsync(LoginQuery query)
        {
            return await mediator.Send(query);
        }

        //[HttpPost("registration")]
        //public async Task<ActionResult<UserLoginModel>> RegistrationAsync(RegistrationCommand command)
        //{
        //    return await Mediator.Send(command);
        //}
    }
}