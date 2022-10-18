using Application.DataTransferObject;
using Application.Services.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("/address")]
        public async Task<IActionResult> AddAddress([FromBody] AddressDto addressDto)
        {
            var result = await _addressService.save(addressDto);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }

        }
    }
}
