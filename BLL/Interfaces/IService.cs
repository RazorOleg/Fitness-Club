using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        TEntity GetById(int id);
        List<TEntity> GetAll();
        bool Save();
    }
}
