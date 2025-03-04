using Microsoft.EntityFrameworkCore;
using ODataTest.API.Models;

namespace ODataTest.API.DAO;

public interface IAddressDAO
{
    Task<Address> Create(CreateAddressRequest request);

    Task<List<Address>> Get();

    Task<Address?> Get(long id);
}

public class AddressDAO(DataContext context) : IAddressDAO
{
    public async Task<Address> Create(CreateAddressRequest request)
    {
        Address address = new Address()
        {
            Street = request.Street,
            City = request.City,
            State = request.State,
            PostalCode = request.PostalCode,
        };

        await context.Addresses.AddAsync(address);
        await context.SaveChangesAsync();

        return address;
    }

    public async Task<List<Address>> Get()
    {
        return await context.Addresses.ToListAsync();
    }

    public async Task<Address?> Get(long id)
    {
        return await context.Addresses.FindAsync(id);
    }
}