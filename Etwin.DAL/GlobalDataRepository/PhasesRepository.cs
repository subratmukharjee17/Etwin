using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhasesRepository : Repository<Phase>, IPhasesRepository
    {
        private readonly GlobalDbContext _db;

        public PhasesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Phase phase)
        {
            var objFromDb = this._db.Phases.FirstOrDefault(s => s.IdPhase == phase.IdPhase);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phase);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
