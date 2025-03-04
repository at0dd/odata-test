using ODataTest.API.Models;

namespace ODataTest.API.DAO;

public interface IAddressDAO
{
    Task<Address> Create(CreateAddressRequest request);
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
            CreatedAt = DateTime.Now,
        };

        await context.Addresses.AddAsync(address);
        await context.SaveChangesAsync();

        return address;
    }
}