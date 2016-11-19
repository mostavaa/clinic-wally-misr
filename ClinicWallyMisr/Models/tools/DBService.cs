using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    public abstract class DBService<T>
    {
        public abstract T add(T obj);
        public abstract T delete(T obj);
        public abstract T edit(T obj);
        public abstract T get(Guid? id);
        public abstract System.Linq.IQueryable<T> getAll();
        public abstract T getByName(string name);
    }
}