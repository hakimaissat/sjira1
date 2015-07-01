using System;
using System.Linq;
using System.Linq.Expressions;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using DataLayer.UnitOfWork;
namespace DataLayer.Repositories

{
    public class EntityRepository<T> : IEntityRepository<T>
    {


        IQueryable<T> IEntityRepository<T>.All
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<T> IEntityRepository<T>.AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        T IEntityRepository<T>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        public T Find(string Name)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<T>.InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public void Save()
        {
            throw new NotImplementedException();
        }


        public void InsertGraph(T entity)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> List()
        {
            throw new NotImplementedException();
        }
    }
}