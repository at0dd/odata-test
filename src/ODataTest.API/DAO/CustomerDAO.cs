using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;
using ODataTest.API.Models;

namespace ODataTest.API.DAO;

public interface ICustomerDAO
{
    Task<Customer> Create(Customer request);

    Task<List<Customer>> Get();

    Task<Customer?> Get(long id);

    Task<Customer> Put(Customer customer, Customer request);

    Task<Customer> Patch(Customer customer, Delta<Customer> request);

    Task Delete(Customer customer);
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

    public async Task<Customer> Put(Customer customer, Customer request)
    {
        customer.Name = request.Name;
        customer.Age = request.Age;
        customer.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Patch(Customer customer, Delta<Customer> request)
    {
        request.Patch(customer);

        await context.SaveChangesAsync();
        return customer;
    }

    public async Task Delete(Customer customer)
    {
        context.Remove(customer);
        await context.SaveChangesAsync();
    }
}