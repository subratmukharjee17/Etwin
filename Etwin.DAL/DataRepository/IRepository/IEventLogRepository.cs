using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IEventLogRepository : IRepository<EventLog>
    {
        void Update(EventLog eventLog,string cs);
        Task UpdateAsync(EventLog eventLog,string cs);
    }
}
