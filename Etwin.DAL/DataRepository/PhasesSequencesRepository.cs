using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class PhasesSequencesRepository : Repository<PhasesSequence>, IPhasesSequencesRepository
    {
        private readonly ETwinContext _db;

        public PhasesSequencesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhasesSequence phasesSequence)
        {
            var objFromDb = this._db.PhasesSequences.FirstOrDefault(s => s.IdPhaseSequence == phasesSequence.IdPhaseSequence);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phasesSequence);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
