using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class PhasesListRepository : Repository<PhasesList>, IPhasesListRepository
    {
        private readonly ETwinContext _db;

        public PhasesListRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhasesList phasesList)
        {
            var objFromDb = this._db.PhasesLists.FirstOrDefault(s => s.IdPhaseList == phasesList.IdPhaseList);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phasesList);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
