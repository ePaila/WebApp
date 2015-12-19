using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Data.Repo
{
    interface IEditableRepository<T> : IRepository<T>
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
