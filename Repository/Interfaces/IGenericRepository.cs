using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        TEntity GetById(int id);
        List<TEntity> GetAll();

    }
}
