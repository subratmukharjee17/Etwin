using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class ProposalStateRepository : Repository<ProposalState>, IProposalStateRepository
    {
        private readonly GlobalDbContext _db;

        public ProposalStateRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProposalState proposalState)
        {
            var objFromDb = _db.ProposalStates.FirstOrDefault(s => s.Id == proposalState.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(proposalState);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
