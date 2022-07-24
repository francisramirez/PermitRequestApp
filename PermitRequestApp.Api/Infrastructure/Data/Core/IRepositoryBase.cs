using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PermitRequestApp.Api.Infrastructure.Data.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(int entityId);
        Task<TEntity> GetByEntity(Expression<Func<TEntity, bool>> filter);

    }
}
