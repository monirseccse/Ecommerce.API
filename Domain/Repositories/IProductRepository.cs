using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
