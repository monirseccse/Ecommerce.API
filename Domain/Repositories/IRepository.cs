using Domain.Common;
using Domain.Specification;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdwithSpecAsync(ISpecification<TEntity>spec);
        Task<IReadOnlyList<TEntity>> GetAllSpecAsync(ISpecification<TEntity>spec);
        Task<int>CountAsync(ISpecification<TEntity> spec);
    }
}
