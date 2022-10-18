using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Address;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IAddressWriteRepository _addressWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public AddressService(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IUserReadRepository userReadRepository)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _userReadRepository = userReadRepository;
        }
        public async Task<bool> save(AddressDto addressDto)
        {
            Address address = new();
            address.Name = addressDto.Name;
            address.Firstname = addressDto.Firstname;
            address.Lastname = addressDto.Lastname;
            address.PhoneNumber = addressDto.PhoneNumber;
            address.City = addressDto.City;
            address.District = addressDto.District;
            address.Neighbourhood = addressDto.Neighbourhood;
            address.FullAddress = addressDto.FullAddress;
            address.User = _userReadRepository.GetWhere(u=> u.Username == addressDto.UserDto.Username).FirstOrDefault();
            var result = await _addressWriteRepository.AddAsync(address);   
            return result;  
        }
    }
}
