using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PhasesItemParametersRepository : Repository<PhasesItemParameter>, IPhasesItemParametersRepository
    {
        private readonly GlobalDbContext _db;

        public PhasesItemParametersRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhasesItemParameter phasesItemParameter)
        {
            var objFromDb = _db.PhasesItemParameters.FirstOrDefault(s => s.Id == phasesItemParameter.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(phasesItemParameter);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
