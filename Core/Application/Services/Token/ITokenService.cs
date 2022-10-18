using Application.DataTransferObject;
using Domain.Entities;
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
    }
}
