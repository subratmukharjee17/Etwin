using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhaseActivitiesRepository : Repository<PhaseActivity>, IPhaseActivitiesRepository
    {
        private readonly GlobalDbContext _db;

        public PhaseActivitiesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PhaseActivity phaseActivity)
        {
            var objFromDb = this._db.PhaseActivities.FirstOrDefault(s => s.IdPhaseActivity == phaseActivity.IdPhaseActivity);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(phaseActivity);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
