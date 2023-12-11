using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class BomPhasesRepository : Repository<BomPhase>, IBomPhasesRepository
    {
        private readonly ETwinContext _db;

        public BomPhasesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(BomPhase bomPhase)
        {
            var objFromDb = this._db.BomPhases.FirstOrDefault(s => s.Id == bomPhase.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(bomPhase);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
