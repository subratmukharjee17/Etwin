using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IProposalStateRepository : IRepository<ProposalState>
    {
        void Update(ProposalState proposalState);
    }
}
