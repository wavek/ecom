using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IRepository<T>//type
    {
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}