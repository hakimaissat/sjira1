using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainClasses.Models;


namespace MvcSJira.Infrastructure
{
    public interface ICurrentUser
	{
		ApplicationUser User { get; } 
	}
}
