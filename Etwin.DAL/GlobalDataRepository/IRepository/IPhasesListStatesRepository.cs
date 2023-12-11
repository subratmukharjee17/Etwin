using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhasesListStatesRepository : IRepository<PhasesListState>
    {
        void Update(PhasesListState phasesListState);
    }
}
