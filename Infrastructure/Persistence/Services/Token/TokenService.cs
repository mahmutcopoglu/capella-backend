﻿using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Token;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Application.Services;

namespace Persistence.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IRoleService _roleService;

        public TokenService(IConfiguration configuration, IUserReadRepository userReadRepository)
        {
            _configuration = configuration;
            _userReadRepository = userReadRepository;
        }
        public async Task<JWTToken> generateToken(User user)
        {
            JWTToken jwtToken = new();

            var claims = new List<Claim>();
            claims.Add(new Claim("firstname", user.Firstname));
            claims.Add(new Claim("lastname", user.Lastname));
            claims.Add(new Claim("dateofbirth", user.BirthDate.ToString()));
            claims.Add(new Claim("email", user.Email));

            foreach(var item in user.Roles)
            {
                claims.Add(new Claim("role", item.Id.ToString()));
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

        public bool isTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {

                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true,


                ValidAudience = _configuration["Token:Auidience"],
                ValidIssuer = _configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]))
            };
        }

        //private List<string> getRolePermission(int id, string token)
        //{
        //    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
        //    List<Role> role = jwt.Claims.First(c => c.Type == "role").Value.;

        //}
    }
}
