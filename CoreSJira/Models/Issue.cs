//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SJiraCore.Models
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    using SJiraShared;

    public class Issue : Entity<int>
    {
        public int ProjectId { get; private set; }
        //public string Name { get; private set; }
        public string Code { get; private set; }
        
        public Issue(int id)
            : base(id)
        {
        }

        private Issue()
        {

        }
    }
}