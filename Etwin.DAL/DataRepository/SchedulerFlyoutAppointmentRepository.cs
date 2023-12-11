using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SchedulerFlyoutAppointmentRepository : Repository<SchedulerFlyoutAppointment>, ISchedulerFlyoutAppointmentRepository
    {
        private readonly ETwinContext _db;

        public SchedulerFlyoutAppointmentRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(SchedulerFlyoutAppointment schedulerFlyoutAppointment)
        {
            var objFromDb = this._db.SchedulerFlyoutAppointments.FirstOrDefault(s => s.Id == schedulerFlyoutAppointment.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(schedulerFlyoutAppointment);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
