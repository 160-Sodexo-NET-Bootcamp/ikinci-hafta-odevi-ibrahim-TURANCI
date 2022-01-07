using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.GenericRepo
{
    public interface IGenericRepo<T> where T : class // T class olmalı 
    {
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        void Delete(long Id);

        T Get(long Id);
        void Detach(T entity);

    }
}
