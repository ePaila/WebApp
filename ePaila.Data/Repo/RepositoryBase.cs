using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Data.Repo
{
    class RepositoryBase<T> : IRepository<T> where T : class
    {
        ePailaEntities ePailaDB;

        public RepositoryBase( ePailaEntities db)
        {
            ePailaDB = db;
        }

        public IQueryable<T> Get()
        {
            return ePailaDB.Set<T>();
        }

        public T Get(int id)
        {
            return ePailaDB.Set<T>().Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return ePailaDB.Set<T>().Where(predicate);  
        }
    }
}
