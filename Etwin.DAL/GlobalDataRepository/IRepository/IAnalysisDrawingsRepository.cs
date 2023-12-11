using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IAnalysisDrawingsRepository : IRepository<AnalysisDrawing>
    {
        void Update(AnalysisDrawing analysisDrawing);
    }
}
