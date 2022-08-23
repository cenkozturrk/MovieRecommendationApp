using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApp.Business.MediatR.Commands.AppUser.CreateUser;
using MovieRecommendationApp.Business.MediatR.Commands.AppUser.LoginUser;

namespace MovieRecommendationApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        //Eger bir gün ön taraf ile bağlarsam action routingi ile bu controllerı kullanabilirim.İlgili endpoint ismi genellikle action!!
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        //{
        //    LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        //    return Ok(response);
        //}




    }
}
