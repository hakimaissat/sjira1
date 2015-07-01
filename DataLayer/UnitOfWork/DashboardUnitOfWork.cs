using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;
//ICurrentUser _user;
//        public MenuItemRepository(IUnitOfWork<MenuItemContext> uow, ICurrentUser user)
//        {
//            _context = uow.Context;
//            this._dbSet = _context.Set<MenuItem>();
//            _uow = uow;
//            _user = user;
//        }
namespace DataLayer.UnitOfWork
{

    public class DashboardUnitOfWork : IUnitOfWork<DashboardContext>
    {
        private readonly DashboardContext _context;


        public DashboardUnitOfWork()
        {
            _context = new DashboardContext();
        }

        public DashboardUnitOfWork(DashboardContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public DashboardContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
