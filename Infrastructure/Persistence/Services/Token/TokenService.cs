using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Token;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserReadRepository _userReadRepository;

        public TokenService(IConfiguration configuration, IUserReadRepository userReadRepository)
        {
            _configuration = configuration;
            _userReadRepository = userReadRepository;
        }
        public async Task<JWTToken> generateToken(User user)
        {
            JWTToken jwtToken = new();
           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Firstname),
                new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.Lastname)
            };

            foreach(var item in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Id.ToString()));
            }

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new(
                claims: claims,
                audience: _configuration["Token:Auidience"],
                issuer: _configuration["Token:Issuer"],
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: signingCredentials

            );

            JwtSecurityTokenHandler tokenHandler = new();
            jwtToken.AccessToken = tokenHandler.WriteToken(securityToken);
            return jwtToken;
        }

    }
}
