using MovieRecommendationApp.Business.Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.MediatR.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public TokenDto TokenDto { get; set; }

    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }

    // O MESHUR SOLID PRENSİPLERİNİ UYGULADIM... Single Responsiblity...

}
