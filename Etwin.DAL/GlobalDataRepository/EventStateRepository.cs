using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class EventStateRepository : Repository<EventState>, IEventStateRepository
    {
        private readonly GlobalDbContext _db;

        public EventStateRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(EventState EventState)
        {
            var objFromDb = this._db.EventStates.FirstOrDefault(s => s.Id == EventState.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(EventState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
