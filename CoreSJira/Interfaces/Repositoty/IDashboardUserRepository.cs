using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;
using SJiraCore.Models;


namespace SJiraCore.Interfaces
{
    public interface IDashboardUserRepository : IEntityRepository<DashboardUser>
    {
        void Add(int dashboardId , string userId);
        
    }
}
