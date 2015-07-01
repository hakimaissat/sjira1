using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;

namespace SJiraCore.Interfaces
{
    public interface IMenuItemRepository : IEntityRepository<MenuItem>
    {
     
        List<MenuItem> GetMenuItems(string menuIem);
        List<MenuItem> GetMainMenuItems(string menuIem);
        List<MenuItem> GetMenuItemsofDashboards();
        List<MenuItem> GetMenuItemsofIssues();
        List<MenuItem> GetMenuItemsofProjects();
        List<MenuItem> GetMenuItemsofAgile();
    
       
    }
}
