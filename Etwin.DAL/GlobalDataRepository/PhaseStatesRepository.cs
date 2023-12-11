using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhaseStatesRepository : Repository<PhaseState>, IPhaseStatesRepository
    {
        private readonly GlobalDbContext _db;

        public PhaseStatesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhaseState phaseState)
        {
            var objFromDb = _db.PhaseStates.FirstOrDefault(s => s.IdPhaseStates == phaseState.IdPhaseStates);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(phaseState);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
