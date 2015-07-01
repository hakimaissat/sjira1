using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Interfaces;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> List();
        TEntity GetById(string Name);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
