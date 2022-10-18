using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Address
{
    public interface IAddressService
    {
        Task<bool> save(AddressDto addressDto);
    }
}
