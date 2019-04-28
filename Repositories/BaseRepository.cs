
using System;
using licensemanager.DataContext;

namespace licensemanager.Repositories
{
    public abstract class BaseRepository<T> where T:class
    {
        protected LicenseManagerDataContext context = null;

        public BaseRepository()
        {
            context = new LicenseManagerDataContext();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Save(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public T Find(object id)
        {
            return context.Set<T>().Find(id);
        }

    }
}