using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface ITraceabilityParameterRepository : IRepository<TraceabilityParameter>
    {
        void Update(TraceabilityParameter traceabilityParameter);
    }
}
