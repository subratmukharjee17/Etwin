using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class CompanyThemeRepository : Repository<CompanyTheme>, ICompanyThemeRepository
    {
        private readonly ETwinContext _db;

        public CompanyThemeRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(CompanyTheme companyTheme)
        {
            var objFromDb = this._db.CompanyThemes.FirstOrDefault(s => s.Id == companyTheme.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(companyTheme);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
