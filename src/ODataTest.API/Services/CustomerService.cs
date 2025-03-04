using Microsoft.AspNetCore.OData.Deltas;
using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface ICustomerService
{
    Task<Customer> Create(Customer request);

    Task<List<Customer>> Get();

    Task<Customer?> Get(long id);

    Task<Customer?> Put(long id, Customer request);

    Task<Customer?> Patch(long id, Delta<Customer> request);

    Task Delete(long id);
}

public class CustomerService(ICustomerDAO customerDAO) : ICustomerService
{
    public async Task<Customer> Create(Customer request)
    {
        return await customerDAO.Create(request);
    }

    public async Task<List<Customer>> Get()
    {
        return await customerDAO.Get();
    }

    public async Task<Customer?> Get(long id)
    {
        return await customerDAO.Get(id);
    }

    public async Task<Customer?> Put(long id, Customer request)
    {
        Customer? customer = await customerDAO.Get(id);
        if (customer == null)
        {
            return null;
        }

        return await customerDAO.Put(customer, request);
    }

    public async Task<Customer?> Patch(long id, Delta<Customer> request)
    {
        Customer? customer = await customerDAO.Get(id);
        if (customer == null)
        {
            return null;
        }

        return await customerDAO.Patch(customer, request);
    }

    public async Task Delete(long id)
    {
        Customer? customer = await customerDAO.Get(id);
        if (customer != null)
        {
            await customerDAO.Delete(customer);
        }
    }
}