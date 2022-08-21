using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieRecommendationApp.Business.Dto.Token;
using MovieRecommendationApp.Business.Exceptions;
using MovieRecommendationApp.Business.Jwt.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager; //kullanıcının giriş işlemlerinden sorumlu bir service.
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,
            SignInManager<Domain.Entities.Identity.AppUser> signInManager,
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if(user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
             
            if (user == null)
                throw new NotFoundUserException();


            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
               TokenDto tokenDto =  _tokenHandler.CreateAccessToken(5);

                return new LoginUserSuccessCommandResponse()
                {
                    TokenDto = tokenDto,
                };
            }

            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = " The username or password is incorrect..! "
            //};

            throw new UserCreateFailedException();

        }
    }
}
