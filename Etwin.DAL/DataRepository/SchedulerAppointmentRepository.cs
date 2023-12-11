using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SchedulerAppointmentRepository : Repository<SchedulerAppointmentMapping>, ISchedulerAppointmentRepository
    {
        private readonly ETwinContext _db;

        public SchedulerAppointmentRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(SchedulerAppointmentMapping schedulerAppointmentMapping)
        {
            var objFromDb = this._db.SchedulerAppointmentMappings.FirstOrDefault(s => s.IdAppointmentMapping == schedulerAppointmentMapping.IdAppointmentMapping);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(schedulerAppointmentMapping);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
