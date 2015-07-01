using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using SJiraCore.Models;
namespace SJiraCore.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _DashboardRepository;
        public DashboardService(IDashboardRepository DashboardRepository)
        {
            _DashboardRepository = DashboardRepository;
        }
        public DashboardService()
        {

        }
        public DashboardModels Manage(string Name)
        {
            DashboardModels dashboardModels=null;
            List<DashboardModel> _dashboardModels = null;
         
            if (Name == "Favorites" || Name == "Index")
            {
                _dashboardModels = _DashboardRepository.GetFavoritesDashboards();

                dashboardModels = new Models.DashboardModels
                {
                    Title = "Favorite Dashboards",
                    SubTitle = "This page allows you to manage all your favorite dashboards",
                    DashboardModelList = _dashboardModels
                };


            }
            else if (Name == "My")
            {
                _dashboardModels = _DashboardRepository.GetMyDashboards();
                dashboardModels = new Models.DashboardModels
                {
                    Title = "My Dashboards",
                    SubTitle = "This page allows you to manage all my  dashboards",
                    DashboardModelList = _dashboardModels
                };
            }
            else if (Name == "Popular")
            {
                _dashboardModels = _DashboardRepository.GetPopularDashboards();

                dashboardModels = new Models.DashboardModels
                {
                    Title = "Popular Dashboards",
                    SubTitle = "This page allows you to manage all Popular dashboards",
                    DashboardModelList = _dashboardModels
                };
            }
            return dashboardModels;
        }
        public List<DashboardModel> Search(string OwnerId , int SharedWithId = 0, string Search = null)
        {
            List<DashboardModel> _dashboardModels = null;
            _dashboardModels = _DashboardRepository.GetSearchDashboards(OwnerId, SharedWithId, Search);
            return _dashboardModels;
        }
    }
}
