using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DataLayer;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using DataLayer.UnitOfWork;
using DataLayer.Context;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
         ApplicationUserContext _context;
        private readonly DbSet<ApplicationUser> _dbSet;
        //public ApplicationUserRepository()
        //{
        //    var uow = new ApplicationUserUnitOfWork();
        //    _context = uow.Context;
        //    this._dbSet = _context.Set<ApplicationUser>();
        //}
        IUnitOfWork<ApplicationUserContext> _uow;
        public ApplicationUserRepository(IUnitOfWork<ApplicationUserContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<ApplicationUser>();
            _uow = uow;
        }
        //public ApplicationUserRepository(ApplicationUserContext context)
        //{
        //    this._context = context;
        //    this._dbSet = context.Set<ApplicationUser>();
        //}
        public IQueryable<ApplicationUser> All
        {
            get { return _context.Users; }
        }
       
        public IQueryable<ApplicationUser> AllIncluding(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _context.Users;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public ApplicationUser Find(int? id)
        {
            return _context.Users.Find(id);
        }
        public void InsertOrUpdate(ApplicationUser ApplicationUser)
        {
            if (ApplicationUser.Id == default(string)) // New entity
            {

                //context.Users.Add(ApplicationUser);
                _context.Entry(ApplicationUser).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(ApplicationUser).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var ApplicationUser = _context.Users.Find(id);
            _context.Users.Remove(ApplicationUser);
        }
        public void Save()
        {
            _uow.Save();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public ApplicationUser Find(string Name)
        {
            throw new NotImplementedException();
        }

        List<ApplicationUser> IApplicationUserRepository.AllApplicationUsers()
        {
            return _context.Users.ToList(); 
        }


        public void InsertGraph(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> List()
        {
            return _dbSet.ToList();
        }
    }


}