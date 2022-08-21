using MovieRecommendationApp.Business.Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.Jwt.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int hours);
    }
}
