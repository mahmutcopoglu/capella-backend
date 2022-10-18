using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IRoleReadRepository _roleReadRepository;

        public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IRoleReadRepository roleReadRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _roleReadRepository = roleReadRepository;
        }

        public async Task<User> loadByUser(LoginDto loginDto)
        {
            var user =await  _userReadRepository.GetWhereWithInclude(x => x.Username == loginDto.Username && x.Password == loginDto.Password, true, x => x.Roles).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> save(UserDto userDto)
        {
            User user = new();
            user.Firstname = userDto.Firstname;
            user.Lastname = userDto.Lastname;
            user.Username = userDto.Username;
            user.Password = userDto.Lastname;
            user.BirthDate = (DateTime)userDto.BirthDate;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Email = userDto.Email;
            var roles = new HashSet<Role>();
            var role = _roleReadRepository.GetWhere(role => role.Code == "user").FirstOrDefault();
            roles.Add(role);
            user.Roles = roles;
            var result = await _userWriteRepository.AddAsync(user);
            return result;   
        }
    }
}
