using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface ITraceabilityRepository : IRepository<Traceability>
    {
        void Update(Traceability traceability);
    }
}
