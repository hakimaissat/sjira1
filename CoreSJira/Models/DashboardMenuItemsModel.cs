using System;
using System.Collections.Generic;
using DomainClasses.Models;

namespace SJiraCore.Models
{
    public class DashboardMenuItemsModel
    {
        
        public int DashboardId { get; set; }
        public string Name { get; set; }
        public string DashboardType { get; set; }
        public string Layout { get; set; }
        public MenuItem MenuItem { get; set; }
        public Gadget Gadget { get; set; }
        //public Dashboard Dashboard { get; set; }
    }
}
