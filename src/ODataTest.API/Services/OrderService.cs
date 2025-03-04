using ODataTest.API.DAO;
using ODataTest.API.Models;

namespace ODataTest.API.Services;

public interface IOrderService
{
    Task<Order> Create(Order request);

    Task<List<Order>> Get();

    Task<Order?> Get(long id);
}

public class OrderService(IOrderDAO orderDAO) : IOrderService
{
    public async Task<Order> Create(Order request)
    {
        return await orderDAO.Create(request);
    }

    public async Task<List<Order>> Get()
    {
        return await orderDAO.Get();
    }

    public async Task<Order?> Get(long id)
    {
        return await orderDAO.Get(id);
    }
}