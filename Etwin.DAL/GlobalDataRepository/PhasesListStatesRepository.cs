using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhasesListStatesRepository : Repository<PhasesListState>, IPhasesListStatesRepository
    {
        private readonly GlobalDbContext _db;

        public PhasesListStatesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhasesListState phasesListState)
        {
            var objFromDb = _db.PhasesListStates.FirstOrDefault(s => s.IdPhaseListState == phasesListState.IdPhaseListState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(phasesListState);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
