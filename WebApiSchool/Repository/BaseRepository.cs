using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiSchool.DataAccess;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public Task<TEntity> CreateAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity dbRecord)
        {
            throw new NotImplementedException();
        }
    }
}
