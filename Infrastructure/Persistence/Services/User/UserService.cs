using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.User;
using AutoMapper;
using Domain.Entities;
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
        private readonly IMapper _mapper;

        public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }

        public async Task<bool> save(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userWriteRepository.AddAsync(user);
            return result;   
        }
    }
}
