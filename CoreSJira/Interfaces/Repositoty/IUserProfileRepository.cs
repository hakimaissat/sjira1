using System;
using System.Collections.Generic;
using System.Linq;
using DomainClasses.Models;
using System.Data;
using Microsoft.AspNet.Identity.EntityFramework;
namespace SJiraCore.Interfaces
{

    public interface IApplicationUserRepository : IEntityRepository<ApplicationUser>
    {
         List<ApplicationUser> AllApplicationUsers();
       
    }
}
