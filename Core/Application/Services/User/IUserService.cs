using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<bool> save(UserDto userDto);
        Task<List<User>> userList();
        Task<User> loadByUser(LoginDto loginDto);
    }
}
