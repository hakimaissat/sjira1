using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcSJira.Infrastructure.Tasks
{
    public interface IRunAfterEachRequest
    {
        void Execute();
    }
}
