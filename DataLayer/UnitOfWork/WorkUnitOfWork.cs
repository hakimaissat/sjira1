using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class WorkUnitOfWork : IUnitOfWork<WorkContext>
    {
        private readonly WorkContext _context;


        public WorkUnitOfWork()
        {
            _context = new WorkContext();
        }

        public WorkUnitOfWork(WorkContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public WorkContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
