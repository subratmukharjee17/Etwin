using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialCodeRepository : IRepository<MaterialCode>
    {
        void Update(MaterialCode materialCode);
    }
}
