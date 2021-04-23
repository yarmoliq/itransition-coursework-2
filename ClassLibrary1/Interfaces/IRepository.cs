using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
    }
}