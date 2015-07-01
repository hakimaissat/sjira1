using System;
using System.Collections.Generic;
using DomainClasses.Bases;
using SJiraShared;
namespace MvcSJira.Models
{
    public  class PDSAMenuItem1 
    {
       
            public int MenuId { get; set; }
            public string MenuTitle { get; set; }
            public int DisplayOrder { get; set; }
            public string MenuAction { get; set; }

            public override string ToString()
            {
                return MenuTitle;
            }
        
    }
}
