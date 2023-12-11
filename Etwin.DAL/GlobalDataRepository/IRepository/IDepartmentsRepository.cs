using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IDepartmentsRepository : IRepository<Department>
    {
        void Update(Department department);
    }
}
