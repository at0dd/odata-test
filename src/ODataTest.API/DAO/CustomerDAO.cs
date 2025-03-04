using Microsoft.EntityFrameworkCore;
using ODataTest.API.Models;

namespace ODataTest.API.DAO;

public interface ICustomerDAO
{
    Task<Customer> Create(Customer request);

    Task<List<Customer>> Get();

    Task<Customer?> Get(long id);
}

public class CustomerDAO(DataContext context) : ICustomerDAO
{
    public async Task<Customer> Create(Customer request)
    {
        await context.Customers.AddAsync(request);
        await context.SaveChangesAsync();

        return request;
    }

    public async Task<List<Customer>> Get()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer?> Get(long id)
    {
        return await context.Customers.FindAsync(id);
    }
}