using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SchedulerRepository : Repository<Scheduler>, ISchedulerRepository
    {
        private readonly ETwinContext _db;

        public SchedulerRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Scheduler scheduler)
        {
            var objFromDb = this._db.Schedulers.FirstOrDefault(s => s.Id == scheduler.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(scheduler);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
