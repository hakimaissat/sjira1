using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainClasses.Models;


namespace SJiraCore.Interfaces
{
    public interface ICurrentUser
	{
		ApplicationUser User { get; } 
	}
}
