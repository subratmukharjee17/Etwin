using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PresenceStatesRepository : Repository<PresenceState>, IPresenceStatesRepository
    {
        private readonly GlobalDbContext _db;

        public PresenceStatesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PresenceState presenceState)
        {
            var objFromDb = _db.PresenceStates.FirstOrDefault(s => s.IdPresenceState == presenceState.IdPresenceState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(presenceState);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
