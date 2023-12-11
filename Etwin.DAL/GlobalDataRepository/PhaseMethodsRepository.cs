using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhaseMethodsRepository : Repository<PhaseMethod>, IPhaseMethodsRepository
    {
        private readonly GlobalDbContext _db;

        public PhaseMethodsRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhaseMethod phaseMethod)
        {
            var objFromDb = this._db.PhaseMethods.FirstOrDefault(s => s.Id == phaseMethod.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phaseMethod);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
