using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SchedulerDependencyRepository : Repository<SchedulerDependencyMapping>, ISchedulerDependencyRepository
    {
        private readonly ETwinContext _db;

        public SchedulerDependencyRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(SchedulerDependencyMapping schedulerDependencyMapping)
        {
            var objFromDb = this._db.SchedulerDependencyMappings.FirstOrDefault(s => s.IdDependecyMapping == schedulerDependencyMapping.IdDependecyMapping);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(schedulerDependencyMapping);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
