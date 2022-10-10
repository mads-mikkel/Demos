using Entities;

using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Repository<T> where T : class
    {
        private NorthwindContext context;
        private DbSet<T> dbSet;

        public Repository(NorthwindContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Insert(T t)
        {

        }

        public virtual void Update(T t)
        {

        }

        public void Delete(T t)
        {

        }
    }
}