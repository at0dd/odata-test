using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
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
        return Created(customer);
    }


    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> Get()
    {
        List<Customer> customers = await customerService.Get();
        return Ok(customers);
    }

    [EnableQuery]
    [HttpGet("{id:long}")]
    public async Task<ActionResult<List<Customer>>> Get([FromRoute] long id)
    {
        Customer? customer = await customerService.Get(id);
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Customer>> Put([FromRoute] long id, [FromBody] Customer request)
    {
        Customer? customer = await customerService.Put(id, request);
        if (customer == null)
        {
            return NotFound();
        }

        return Updated(customer);
    }

    [HttpPatch("{id:long}")]
    public async Task<ActionResult<Customer>> Patch([FromRoute] long id, [FromBody] Delta<Customer> request)
    {
        Customer? customer = await customerService.Patch(id, request);
        if (customer == null)
        {
            return NotFound();
        }

        return Updated(customer);
    }

    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        await customerService.Delete(id);
        return NoContent();
    }
}