using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ETwinContext _db;

        public EventRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Event eventDescription)
        {
            var objFromDb = this._db.Events.FirstOrDefault(s => s.Id == eventDescription.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(eventDescription);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
