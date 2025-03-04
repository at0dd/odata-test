using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface IAddressService
{
    Task<Address> Create(CreateAddressRequest request);

    Task<List<Address>> Get();

    Task<Address?> Get(long id);
}

public class AddressService(IAddressDAO addressDAO) : IAddressService
{
    public async Task<Address> Create(CreateAddressRequest request)
    {
        return await addressDAO.Create(request);
    }

    public async Task<List<Address>> Get()
    {
        return await addressDAO.Get();
    }

    public async Task<Address?> Get(long id)
    {
        return await addressDAO.Get(id);
    }
}