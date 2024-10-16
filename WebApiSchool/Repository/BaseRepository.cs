﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _table;
        public BaseRepository(AppDbContext dbContext)
        {
            _table = dbContext.Set<TEntity>();
        }

        public async Task<int> Count()
        {
            return await _table.AsNoTracking().CountAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task CreateAsync(List<TEntity> entity)
        {
            await _table.AddRangeAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entity)
        {
             _table.RemoveRange(entity);
        }

        public async Task<List<TEntity>> GetPagedAsync(int page, int pageSize)
        {
            return await _table.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public IQueryable<TEntity> Select()
        {
            return _table.AsQueryable();
        }

        public async Task<List<TEntity>> SelectAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> SelectById(object id) => await _table.FindAsync(id);
        

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entity)
        {
            _table.UpdateRange(entity);
        }
    }
}
