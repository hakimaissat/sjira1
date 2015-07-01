using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class IssueUnitOfWork : IUnitOfWork<IssueContext>
    {
        private readonly IssueContext _context;


        public IssueUnitOfWork()
        {
            _context = new IssueContext();
        }

        public IssueUnitOfWork(IssueContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public IssueContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
