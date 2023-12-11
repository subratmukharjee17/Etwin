using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IProcessesListRepository : IRepository<ProcessesList>
    {
        void Update(ProcessesList processesList);
    }
}
