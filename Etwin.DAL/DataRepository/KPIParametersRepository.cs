using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KpiParametersRepository : Repository<KpiParameter>, IKpiParametersRepository
    {
        private readonly ETwinContext _db;

        public KpiParametersRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(KpiParameter kpiparameter)
        {
            var objFromDb = this._db.KpiParameters.FirstOrDefault(s => s.Id == kpiparameter.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kpiparameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
