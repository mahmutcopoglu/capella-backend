using Application.DataTransferObject;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Token
{
    public interface ITokenService
    {
        Task<JWTToken> generateToken(User user);

        bool isTokenValid(string token);

        TokenValidationParameters GetValidationParameters();

        Task<bool> getRolePermission(string token, string permission);
    }
}
