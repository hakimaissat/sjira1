using System;
using System.Collections.Generic;
using SJiraCore.Models;

namespace SJiraCore.Interfaces
{
    public interface IDashboardService
    {
        DashboardModels Manage(string Name);
        List<DashboardModel> Search(string OwnerId, int SharedWithId = 0, string Search = null);

    }
}
