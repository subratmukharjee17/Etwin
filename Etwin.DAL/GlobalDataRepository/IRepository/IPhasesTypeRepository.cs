using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhasesTypeRepository : IRepository<PhasesType>
    {
        void Update(PhasesType phasesType);
    }
}
