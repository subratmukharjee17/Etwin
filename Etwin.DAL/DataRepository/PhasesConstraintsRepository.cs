using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class PhasesConstraintsRepository : Repository<PhasesConstraint>, IPhasesConstraintsRepository
    {
        private readonly ETwinContext _db;

        public PhasesConstraintsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhasesConstraint phasesConstraint)
        {
            var objFromDb = this._db.PhasesConstraints.FirstOrDefault(s => s.IdPhaseConstraint == phasesConstraint.IdPhaseConstraint);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phasesConstraint);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
