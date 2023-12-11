using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWorkingModesRepository : IRepository<WorkingMode>
    {
        void Update(WorkingMode workingMode);
    }
}
