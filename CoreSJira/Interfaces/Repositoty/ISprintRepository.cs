using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;


namespace SJiraCore.Interfaces
{
    public interface ISprintRepository : IEntityRepository<Project>
    {
        Sprint GetSprintForDate(int companyId, DateTime date);
        void Update(Sprint sprint);
    }
}
