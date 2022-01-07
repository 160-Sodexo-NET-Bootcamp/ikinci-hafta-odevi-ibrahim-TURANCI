using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected AppContext context;
        internal DbSet<T> dbSet;
        public GenericRepo(AppContext context)
        {
            this.context = context; // class ın içindeki değişkene ata

            dbSet = context.Set<T>();

        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);          
        }
        public void Delete(long Id)
        {
            dbSet.Remove(dbSet.Find(Id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            // get all
            return await dbSet.ToListAsync();
        }


        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(long Id)
        {
            return dbSet.Find(Id);

        } 
        public void  Detach(T entity)
        {
           context.Entry(entity).State = EntityState.Detached;

        }
    }
}
