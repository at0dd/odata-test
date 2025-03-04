using Microsoft.EntityFrameworkCore;
using ODataTest.API.Models;

namespace ODataTest.API.DAO;

public interface IOrderDAO
{
    Task<Order> Create(Order request);

    Task<List<Order>> Get();

    Task<Order?> Get(long id);
}

public class OrderDAO(DataContext context) : IOrderDAO
{
    public async Task<Order> Create(Order request)
    {
        await context.Orders.AddAsync(request);
        await context.SaveChangesAsync();

        return request;
    }

    public async Task<List<Order>> Get()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task<Order?> Get(long id)
    {
        return await context.Orders.FindAsync(id);
    }
}