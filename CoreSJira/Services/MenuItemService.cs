using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using SJiraCore.Models;
namespace SJiraCore.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _MenuItemRepository;


        public MenuItemService(IMenuItemRepository MenuItemRepository)
        {
            _MenuItemRepository = MenuItemRepository;
        }


        public MenuItemService()
        {

        }
        public List<MenuItem> GetMainMenuItems(string menuIem)
        {
            try
            {
                return MainList(menuIem);
            }
            catch (Exception eGetMainMenuItems)
            {

                throw eGetMainMenuItems;
            }

        }
        public List<MenuItem> GetSideBarMenuItems(string menuIem)
        {
            try
            {
                return SideBarList(menuIem);
            }
            catch (Exception eGetSideBarMenuItems)
            {

                //throw eGetSideBarMenuItems;
                return null;
            }

        }
        public List<MenuItem> MainList(string menuIem)
        {
            try
            {
                List<MenuItem> mgr1 = _MenuItemRepository.GetMainMenuItems(menuIem);

                //List<MenuItem> mgr3=_MenuItemRepository.GetMenuItems(menuIem);

                //List<MenuItem> mgr2 = _MenuItemRepository.GetMenuItemsofDashboards();

                //foreach (var item in mgr2)
                //{
                //    mgr3.Add(item);

                //}

                //var mgr1 = mgr3.OrderBy(p => p.DisplayOrder)
                //    //.Include(p => p.Child).Include(p => p.Parent)
                // .Where(p => p.Parent.Title == menuIem)//.Union(mgr2)

                // .ToList();



                return mgr1;

                //return mgr1;
            }
            catch (Exception eMainList)
            {

                //throw eMainList;
                return null;
            }

        }
        public List<MenuItem> SideBarList(string menuIem)
        {
            try
            {
                //List<MenuItem> mgr1 = _MenuItemRepository.GetSideBarMenuItems(menuIem);

                List<MenuItem> mgr2 = null;


                if (menuIem == "Dashboards")
                {
                    mgr2 = _MenuItemRepository.GetMenuItemsofDashboards();
                }
                else if (menuIem == "Dashboards")
                {
                    mgr2 = _MenuItemRepository.GetMenuItemsofDashboards();
                }
                if (menuIem == "Manage Dashboards")
                {
                    mgr2 = _MenuItemRepository.GetMenuItems("Manage Dashboards");
                }


                return mgr2;

                //return mgr1;
            }
            catch (Exception eSideBarList)
            {

                //throw eSideBarList;
                return null;
            }


        }




    }
}
