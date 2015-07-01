using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class SprintUnitOfWork : IUnitOfWork<SprintContext>
    {
        private readonly SprintContext _context;


        public SprintUnitOfWork()
        {
            _context = new SprintContext();
        }

        public SprintUnitOfWork(SprintContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public SprintContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
