using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface ICustomerService
{
    Task<Customer> Create(Customer request);

    Task<List<Customer>> Get();

    Task<Customer?> Get(long id);
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
}