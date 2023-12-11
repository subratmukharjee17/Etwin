using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class PhasesCompanyRepository : Repository<PhasesCompany>, IPhasesCompanyRepository
    {
        private readonly ETwinContext _db;

        public PhasesCompanyRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhasesCompany phasesCompany)
        {
            var objFromDb = this._db.PhasesCompanies.FirstOrDefault(s => s.Id == phasesCompany.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phasesCompany);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
