using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Entities;
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
            var query = _dbContext.Posts
                           .AsNoTracking() 
                           .Include(p => p.Author) 
                           .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Title.Contains(search) || p.Content.Contains(search));
            }

            return await query.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }

        public async Task<int> SearchCountAsync(string search)
        {
            var query = _dbContext.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Title.Contains(search) || p.Content.Contains(search));
            }

            return await query.CountAsync();
        }
    }
}
