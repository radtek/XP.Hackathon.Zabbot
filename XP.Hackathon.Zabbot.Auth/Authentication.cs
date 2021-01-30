using XP.Hackathon.Zabbot.Interface;
using XP.Hackathon.Zabbot.Model.Configuration;
using XP.Hackathon.Zabbot.Model.Response;
using XP.Hackathon.Zabbot.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace XP.Hackathon.Zabbot.Auth.Auth
{
    public class Authentication : IAuthentication
    {
        public TokenResponseMessage SetClaims(User user)
        {
            DateTime created = DateTime.Now;
            DateTime expired = created + TimeSpan.FromSeconds(AppSettings.TokenConfiguration.Seconds);


            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.TokenConfiguration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);


            var tokenResponse = new TokenResponseMessage()
            {
                access_token = token,
                token_type = "Bearer",
                created = created,
                expires_in = expired
            };

            return tokenResponse;
        }
    }
}
