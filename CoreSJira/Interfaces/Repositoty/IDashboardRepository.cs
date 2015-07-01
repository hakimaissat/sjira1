using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;
using SJiraCore.Models;


namespace SJiraCore.Interfaces
{
    public interface IDashboardRepository : IEntityRepository<Dashboard>
    {
        List<DashboardModel> GetFavoritesDashboards();
        List<DashboardModel> GetMyDashboards();
        List<DashboardModel> GetPopularDashboards();
        List<DashboardModel> GetSearchDashboards(string OwnerId , int SharedWithId , string Search );

    }
}
