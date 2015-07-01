using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class ApplicationUserUnitOfWork : IUnitOfWork<ApplicationUserContext>
    {
        private readonly ApplicationUserContext _context;


        public ApplicationUserUnitOfWork()
        {
            _context = new ApplicationUserContext();
        }

        public ApplicationUserUnitOfWork(ApplicationUserContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public ApplicationUserContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
