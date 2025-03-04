using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTest.API.Models;
using ODataTest.API.Services;

namespace ODataTest.API.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(IOrderService orderService) : ODataController
{
    [HttpPost]
    public async Task<ActionResult<Order>> Create([FromBody] Order request)
    {
        Order customer = await orderService.Create(request);
        return StatusCode(StatusCodes.Status201Created, customer);
    }

    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<List<Order>>> Get()
    {
        List<Order> addresses = await orderService.Get();
        return StatusCode(StatusCodes.Status200OK, addresses);
    }

    [EnableQuery]
    [HttpGet("{id:long}")]
    public async Task<ActionResult<List<Order>>> Get([FromRoute] long id)
    {
        Order? address = await orderService.Get(id);
        if (address == null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        return StatusCode(StatusCodes.Status200OK, address);
    }
}