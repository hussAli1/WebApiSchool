using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly AppDbContext _dbContext;

        public async Task<List<Post>> SearchAsync(string search, int page, int pageSize)
        {
            return await _dbContext.Posts
            .AsNoTracking()
            .Include(p => p.Author)
            .Where(p => string.IsNullOrEmpty(search) || p.Title.Contains(search) || p.Content.Contains(search))
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(p=>p.CreatedAt)
            .ToListAsync();
        }
        public async Task<Post?> SelectByCondition(Expression<Func<Post, bool>> expression, bool trackChanges) =>
             !trackChanges ? await _dbContext.Posts.Where(expression).AsNoTracking()
                                                  .Include(p => p.Author).FirstOrDefaultAsync()
                           : await _dbContext.Posts.Where(expression)
                                                  .Include(p => p.Author).FirstOrDefaultAsync();

    }
}
