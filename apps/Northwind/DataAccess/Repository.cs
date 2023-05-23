using Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class Repository<T> where T : class
    {
        private NorthwindContext context;
        protected DbSet<T> dbSet;

        public Repository(NorthwindContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
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