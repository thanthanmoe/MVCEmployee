using MVCEmployee.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEmployee.Repository
{
    public class EmployeeRepo<T> : IEmployeeRepo<T> where T : class
    {
        private EmployeeContext db;
        private DbSet<T> dbSet;
        public EmployeeRepo()
        {
            db = new EmployeeContext();
            dbSet = db.Set<T>();
        }
        public void Delete(object Id)
        {
            T objById = dbSet.Find(Id);
            dbSet.Remove(objById);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T Object)
        {
            dbSet.Add(Object);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T Object)
        {
            db.Entry(Object).State=EntityState.Modified;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}