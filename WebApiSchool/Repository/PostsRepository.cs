﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<int> SearchCountAsync(string search)
        {
            var query = _dbContext.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Title.Contains(search) || p.Content.Contains(search));
            }

            return await query.CountAsync();
        }
        public async Task<Post?> SelectById(object id)
        {
            return await _dbContext.Posts
                .AsNoTracking() 
                .Include(p => p.Author) 
                .FirstOrDefaultAsync(p => p.Id == (Guid)id); 
        }

    }
}
