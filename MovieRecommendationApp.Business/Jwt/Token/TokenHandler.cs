using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendationApp.Business.Dto;
using MovieRecommendationApp.Business.Dto.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.Jwt.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int hours)
        {
            TokenDto token = new TokenDto();

            // Security Key simetrigini al.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluştur.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak token ayarlarını ver.
            token.Expiration = DateTime.UtcNow.AddHours(hours);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials : signingCredentials
                );

            // Token olusturucu sınıfından bir örnek almak.
            JwtSecurityTokenHandler tokenHandler = new();
            // Yukarı da ki Yapılan tüm işlemi AccessTokena gönder
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
