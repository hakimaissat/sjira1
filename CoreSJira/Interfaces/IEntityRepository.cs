using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainClasses.Models;

namespace SJiraCore.Interfaces
{ 
  
    
    public interface IEntityRepository<T>
    {
        IEnumerable<T> List();
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int? id);
        T Find(string name);
        void InsertOrUpdate(T entity);
        void InsertGraph(T entity);
        void Delete(int id);
        void Save();
    }
    
}