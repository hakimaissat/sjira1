using System;
using System.Data.Entity;
using System.Linq;
using SJiraCore.Models;

namespace DataLayer.Interfaces
{

    public interface IUnitOfWork<TContext>  where TContext : DbContext
    {
        int Save();
        TContext Context { get; }

    }
}
