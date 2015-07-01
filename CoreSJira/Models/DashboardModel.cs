using System;
using System.Collections.Generic;

namespace SJiraCore.Models
{
    public partial class DashboardModel
    {

        public int DashboardId { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }
        public string Owner { get; set; }
        public int OwnerId { get; set; }
        public string SharedWith { get; set; }
        public int SharedWithId { get; set; }
        public int Popularity { get; set; }

       
    }
}
