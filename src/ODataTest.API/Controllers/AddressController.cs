using Microsoft.AspNetCore.Mvc;
using ODataTest.API.Models;
using ODataTest.API.Services;

namespace ODataTest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] CreateAddressRequest request)
    {
        Address address = await addressService.Create(request);
        return StatusCode(StatusCodes.Status201Created, address);
    }
}