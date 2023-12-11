using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhasesTypeRepository : Repository<PhasesType>, IPhasesTypeRepository
    {
        private readonly GlobalDbContext _db;

        public PhasesTypeRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhasesType phasesType)
        {
            var objFromDb = _db.PhasesTypes.FirstOrDefault(s => s.IdPhaseType == phasesType.IdPhaseType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(phasesType);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
