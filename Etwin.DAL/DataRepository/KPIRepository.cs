using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KpiRepository : Repository<Kpi>, IKpiRepository
    {
        private readonly ETwinContext _db;

        public KpiRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Kpi kpi)
        {
            var objFromDb = this._db.Kpis.FirstOrDefault(s => s.Id == kpi.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kpi);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
