using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTest.API.Models;
using ODataTest.API.Services;

namespace ODataTest.API.Controllers;

[ApiController]
[Route("addresses")]
public class AddressController(IAddressService addressService) : ODataController
{
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] CreateAddressRequest request)
    {
        Address address = await addressService.Create(request);
        return StatusCode(StatusCodes.Status201Created, address);
    }


    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<List<Address>>> Get()
    {
        List<Address> addresses = await addressService.Get();
        return StatusCode(StatusCodes.Status200OK, addresses);
    }

    [EnableQuery]
    [HttpGet("{id:long}")]
    public async Task<ActionResult<List<Address>>> Get([FromRoute] long id)
    {
        Address? address = await addressService.Get(id);
        if (address == null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        return StatusCode(StatusCodes.Status200OK, address);
    }
}