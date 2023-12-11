using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialStandardRepository : IRepository<MaterialStandard>
    {
        void Update(MaterialStandard materialStandard);
    }
}
