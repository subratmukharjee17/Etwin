using Etwin.Model;
namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IKcfPlannerRepository : IRepository<KcfPlanner>
    {
        void Update(KcfPlanner kcf);
    }
}
