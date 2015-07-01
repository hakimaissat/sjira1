using System;
using System.Collections.Generic;

namespace SJiraCore.Models
{
    public partial class DashboardModels
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public virtual ICollection<DashboardModel> DashboardModelList { get; set; }
        

        
    }
}
