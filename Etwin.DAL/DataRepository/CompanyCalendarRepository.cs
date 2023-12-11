using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class CompanyCalendarRepository : Repository<CompanyCalendar>, ICompanyCalendarRepository
    {
        private readonly ETwinContext _db;

        public CompanyCalendarRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(CompanyCalendar companyCalendar)
        {
            var objFromDb = this._db.CompanyCalendars.FirstOrDefault(s => companyCalendar.IdCompanyCalendar == companyCalendar.IdCompanyCalendar);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(companyCalendar);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
