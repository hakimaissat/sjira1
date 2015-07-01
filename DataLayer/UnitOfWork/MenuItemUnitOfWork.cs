using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class MenuItemUnitOfWork : IUnitOfWork<MenuItemContext>
    {
        private readonly MenuItemContext _context;


        public MenuItemUnitOfWork()
        {
            _context = new MenuItemContext();
        }

        public MenuItemUnitOfWork(MenuItemContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public MenuItemContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
