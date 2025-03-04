using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface IAddressService
{
    Task<Address> Create(CreateAddressRequest request);

    Task<List<Address>> Get();
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
}