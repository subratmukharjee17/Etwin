using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class ProposalTypeRepository : Repository<ProposalType>, IProposalTypeRepository
    {
        private readonly GlobalDbContext _db;

        public ProposalTypeRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProposalType proposalType)
        {
            var objFromDb = _db.ProposalTypes.FirstOrDefault(s => s.Id == proposalType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(proposalType);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
