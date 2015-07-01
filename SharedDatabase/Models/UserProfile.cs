using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Projects = new List<Project>();
            this.Works = new List<Work>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
