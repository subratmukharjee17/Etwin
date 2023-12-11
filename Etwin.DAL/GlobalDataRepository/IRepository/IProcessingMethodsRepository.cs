using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IProcessingMethodsRepository : IRepository<ProcessingMethod>
    {
        void Update(ProcessingMethod processingMethod);
    }
}
