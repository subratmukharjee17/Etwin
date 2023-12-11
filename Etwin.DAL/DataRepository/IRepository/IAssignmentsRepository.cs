using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IAssignmentsRepository : IRepository<Assignment>
    {
        void Update(Assignment assignment);
    }
}
