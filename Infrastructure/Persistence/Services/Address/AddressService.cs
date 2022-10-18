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
        private readonly IMapper _mapper;

        public AddressService(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
        }
    

        public async Task<bool> save(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            var result = await _addressWriteRepository.AddAsync(address);   
            return result;  
        }
    }
}
