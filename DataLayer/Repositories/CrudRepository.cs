using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainClasses.Interfaces;
using DataLayer;
using System.Data;
using SJiraCore.Interfaces;
using DataLayer.UnitOfWork;
using DataLayer.Context;
namespace DataLayer.Repositories
{
    //BoardType,DashboardType,GadgetType,IssuePriority,IssueResolution,IssueType,MenuItemType,ProjectCategory,ProjectType,SharedWith,Status,WorkType
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly SJiraContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public CrudRepository(SJiraContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> List()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception eRepository)
            {

                throw eRepository;
            }
           
        }

        public TEntity GetByName(string Name)
        {
            return _dbSet.Find(Name);
        }
        public TEntity GetById(int? id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
