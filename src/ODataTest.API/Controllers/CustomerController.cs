using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTest.API.Models;
using ODataTest.API.Services;

namespace ODataTest.API.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(ICustomerService customerService) : ODataController
{
    [HttpPost]
    public async Task<ActionResult<Customer>> Create([FromBody] Customer request)
    {
        Customer customer = await customerService.Create(request);
        return StatusCode(StatusCodes.Status201Created, customer);
    }


    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> Get()
    {
        List<Customer> addresses = await customerService.Get();
        return StatusCode(StatusCodes.Status200OK, addresses);
    }

    [EnableQuery]
    [HttpGet("{id:long}")]
    public async Task<ActionResult<List<Customer>>> Get([FromRoute] long id)
    {
        Customer? address = await customerService.Get(id);
        if (address == null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        return StatusCode(StatusCodes.Status200OK, address);
    }
}