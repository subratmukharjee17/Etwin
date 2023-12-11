using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System.Linq;
using Etwin.Model.Context;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Etwin.DAL.DataRepository
{
    public class EventLogRepository : Repository<EventLog> , IEventLogRepository
    {
        private ETwinContext _db;

        public EventLogRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(EventLog eventLog,string cs)
        {
            this._db = new ETwinContext(cs);
            var objFromDb = this._db.EventLogs.FirstOrDefault(s => s.Id == eventLog.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(eventLog);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }

        public async Task UpdateAsync(EventLog eventLog,string cs)
        {
            using (var db = new ETwinContext(cs))
            {
                var objFromDb = await db.EventLogs.FindAsync(eventLog.Id);

                if (objFromDb != null)
                {
                    // AGGIORNO I VALORI
                    this._db.Entry(objFromDb).CurrentValues.SetValues(eventLog);

                    // SALVO A DB
                    await db.SaveChangesAsync();
                }
            }
        }


    }
}
