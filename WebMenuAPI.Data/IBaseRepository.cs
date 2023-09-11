using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebMenuAPI.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity> Get(int id);

        //public TEntity Get(Expression<Func<TEntity, bool>> expression);

        public Task<TEntity> Add(TEntity entity);

        public Task Update(TEntity entity);

        public Task Delete(int id);
    }
}
