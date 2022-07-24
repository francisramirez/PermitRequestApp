using Microsoft.EntityFrameworkCore;
using PermitRequestApp.Api.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermitRequestApp.Api.Infrastructure.Data.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly PermitDbContext _context;

        private DbSet<TEntity> _entities;
        public RepositoryBase(PermitDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public async virtual Task Add(TEntity entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }
        public async virtual Task<List<TEntity>> Get()
        {
            return await _entities.ToListAsync();
        }
        public async Task<TEntity> GetByEntity(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.FirstOrDefaultAsync(filter);
        }
        public virtual async Task<TEntity> GetById(int entityId)
        {
            return await _entities.FindAsync(entityId);
        }
        public async virtual Task Remove(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
