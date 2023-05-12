using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository : IRepository <int, Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
