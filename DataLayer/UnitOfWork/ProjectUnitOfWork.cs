using System;
using System.Linq;
using DataLayer;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Models;

namespace DataLayer.UnitOfWork
{

    public class ProjectUnitOfWork : IUnitOfWork<ProjectContext>
    {
        private readonly ProjectContext _context;


        public ProjectUnitOfWork()
        {
            _context = new ProjectContext();
        }

        public ProjectUnitOfWork(ProjectContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public ProjectContext Context
        {
            get { return _context; }
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
