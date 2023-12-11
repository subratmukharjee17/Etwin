using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IProposalOrderRepository : IRepository<ProposalOrder>
    {
        void Update(ProposalOrder proposal);
    }
}
