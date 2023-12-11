using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class OperatorsCalendarRepository : Repository<OperatorsCalendar>, IOperatorsCalendarRepository
    {
        private readonly ETwinContext _db;

        public OperatorsCalendarRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorsCalendar operatorsCalendar)
        {
            var objFromDb = this._db.OperatorsCalendars.FirstOrDefault(s => s.IdOperatorCalendar == operatorsCalendar.IdOperatorCalendar);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorsCalendar);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
