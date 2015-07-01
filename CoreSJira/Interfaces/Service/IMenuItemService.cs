using System;
using System.Collections.Generic;
using DomainClasses.Models;
namespace SJiraCore.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItem> GetMainMenuItems(string menuIem);
        List<MenuItem> GetSideBarMenuItems(string menuIem);
        List<MenuItem> MainList(string menuIem);
        List<MenuItem> SideBarList(string menuIem );

    }
}
