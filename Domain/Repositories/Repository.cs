using Domain.Common;

namespace Domain.Repositories
{
    public class Repository<Tkey, TEntity> : IRepository<Tkey, TEntity>
        where TEntity : BaseEntity<Tkey>
    {
        private readonly ApplicationDbContext _context;

        public Task<TEntity> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Tkey id)
        {
            throw new NotImplementedException();
        }
    }
}
