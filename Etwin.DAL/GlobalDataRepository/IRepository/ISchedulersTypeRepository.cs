using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface ISchedulersTypeRepository : IRepository<SchedulersType>
    {
        void Update(SchedulersType schedulersType);
    }
}
