using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DomainClasses.Models;
using DataLayer.Context;

namespace MvcSJira.Models
{ 
    public class MenuItemRepository1 : IMenuItemRepository1
    {
        MenuItemContext context = new MenuItemContext();

        public IQueryable<MenuItem> All
        {
            get { return context.MenuItems; }
        }

        public IQueryable<MenuItem> AllIncluding(params Expression<Func<MenuItem, object>>[] includeProperties)
        {
            IQueryable<MenuItem> query = context.MenuItems;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public MenuItem Find(int id)
        {
            return context.MenuItems.Find(id);
        }

        public void InsertOrUpdate(MenuItem menuitem)
        {
            if (menuitem.MenuItemId == default(int)) {
                // New entity
                context.MenuItems.Add(menuitem);
            } else {
                // Existing entity
                context.Entry(menuitem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var menuitem = context.MenuItems.Find(id);
            context.MenuItems.Remove(menuitem);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        //public void Dispose() 
        //{
        //    context.Dispose();
        //}
    }

    public interface IMenuItemRepository1 : IDisposable
    {
        IQueryable<MenuItem> All { get; }
        IQueryable<MenuItem> AllIncluding(params Expression<Func<MenuItem, object>>[] includeProperties);
        MenuItem Find(int id);
        void InsertOrUpdate(MenuItem menuitem);
        void Delete(int id);
        void Save();
    }
}