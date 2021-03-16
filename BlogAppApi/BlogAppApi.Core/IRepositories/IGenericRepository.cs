using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task Remove(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
