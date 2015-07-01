using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Interfaces;

namespace SJiraCore.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> List();
        TEntity GetByName(string Name);
        TEntity GetById(int? id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
