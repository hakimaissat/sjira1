using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJiraCore.Models
{
    public class Project1
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProjectCategory { get; set; }
        public string Lead { get; set; }
        public int? TimeOriginalIstimate { get; set; }

    }
}
