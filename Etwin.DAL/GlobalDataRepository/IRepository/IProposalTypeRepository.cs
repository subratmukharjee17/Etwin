using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IProposalTypeRepository : IRepository<ProposalType>
    {
        void Update(ProposalType proposalType);
    }
}
