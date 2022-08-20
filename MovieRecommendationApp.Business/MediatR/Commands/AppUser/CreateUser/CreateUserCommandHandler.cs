using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRecommendationApp.Domain.Entities;
using MovieRecommendationApp.Business.Exceptions;

namespace MovieRecommendationApp.Business.MediatR.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           IdentityResult result = await _userManager.CreateAsync(new()
            {
               Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                Email = request.Email,
                NameSurname = request.NameSurname,

            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = " Succeeded..! ";
            else
                throw new UserCreateFailedException();

            return response;





            //else
            //{
            //    response.Succeeded = false;
            //    response.Message = "Faile..!";
            //}

                //foreach (var error in result.Errors)
                //    response.Message += $"{error.Code} - {error.Description}";



        }  
    }
}
