using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SchedulerResourceRepository : Repository<SchedulerResourceMapping>, ISchedulerResourceRepository
    {
        private readonly ETwinContext _db;

        public SchedulerResourceRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(SchedulerResourceMapping schedulerResourceMapping)
        {
            var objFromDb = this._db.SchedulerResourceMappings.FirstOrDefault(s => s.IdResourceMapping == schedulerResourceMapping.IdResourceMapping);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(schedulerResourceMapping);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
