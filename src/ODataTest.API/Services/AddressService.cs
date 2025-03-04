using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface IAddressService
{
    Task<Address> Create(CreateAddressRequest request);
}

public class AddressService(IAddressDAO addressDAO) : IAddressService
{
    public async Task<Address> Create(CreateAddressRequest request)
    {
        return await addressDAO.Create(request);
    }
}