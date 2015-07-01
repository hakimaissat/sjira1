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

namespace DataLayer.Repositories
{
    public class MenuItemRepository1 : IMenuItemRepository
    {
        MenuItemContext _context;
        public MenuItemRepository1(MenuItemUnitOfWork uow)
        {
            _context = uow.Context;
        }
        public IQueryable<MenuItem> All
        {
            get { return _context.MenuItems; }
        }
        public List<MenuItem> AllMenuItems
        {
            get { return _context.MenuItems.ToList(); }
        }
        public IQueryable<MenuItem> AllIncluding(params Expression<Func<MenuItem, object>>[] includeProperties)
        {
            IQueryable<MenuItem> query = _context.MenuItems;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public MenuItem Find(int? id)
        {
            return _context.MenuItems.Find(id);
        }

        public void InsertOrUpdate(MenuItem MenuItem)
        {
            if (MenuItem.MenuId == default(int)) // New entity
            {

                //context.MenuItems.Add(MenuItem);
                _context.Entry(MenuItem).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(MenuItem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var MenuItem = _context.MenuItems.Find(id);
            _context.MenuItems.Remove(MenuItem);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public MenuItem Find(string Name)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItems(string menuIem)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMainMenuItems(string menuIem)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsofDashboards()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsofIssues()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsofProjects()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemsofAgile()
        {
            throw new NotImplementedException();
        }
    }


}