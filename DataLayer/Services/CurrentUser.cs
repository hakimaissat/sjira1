using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DataLayer.Context;
using Microsoft.AspNet.Identity;
using DomainClasses.Models;
using SJiraCore.Models;
using SJiraCore.Interfaces;

namespace DataLayer.Service
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly SJiraContext _context;

        private ApplicationUser _user;

        public CurrentUser(IIdentity identity, SJiraContext context)
        {
            _identity = identity;
            _context = context;
        }

        public ApplicationUser User
        {
            get { 
                _user = _context.Users.Find(_identity.GetUserId());
                if (_user == null)
                {
                    return _context.Users.Where(p => p.UserName == "Aissat").FirstOrDefault();
                }
                else
                {
                    return _user;
                }
            }
        }
    }
}