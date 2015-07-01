using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataLayer.Context;
using MvcSJira.Infrastructure.Tasks;

namespace MvcSJira.Infrastructure
{
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly SJiraContext _dbContext;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(SJiraContext dbContext,
            HttpContextBase httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items["_Transaction"] =
                _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_httpContext.Items["_Transaction"];

            if (_httpContext.Items["_Error"] != null)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}