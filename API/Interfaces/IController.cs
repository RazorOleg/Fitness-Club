using System.Collections.Generic;

namespace API
{
    public interface IController<TModel> where TModel : class
    {
        void Add(TModel model);
        void Update(TModel model);
        void Remove(int id);
        TModel GetById(int id);
        List<TModel> GetAll();
        bool Save();
    }
}
