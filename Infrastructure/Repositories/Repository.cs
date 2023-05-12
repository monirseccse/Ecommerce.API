using Domain.Common;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<Tkey, TEntity> : IRepository<Tkey, TEntity>
        where TEntity : BaseEntity<Tkey>
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Tkey id)
        {
           return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
