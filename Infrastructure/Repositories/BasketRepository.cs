using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class BasketRepository : IBasketRepository
{
    public Task<bool> DeleteBasketAsync(string basketId)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerBasket> GetBasketAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        throw new NotImplementedException();
    }
}
