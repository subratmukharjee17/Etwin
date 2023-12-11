using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMachineDeclarationParametersRepository : IRepository<MachineDeclarationParameter>
    {
        void Update(MachineDeclarationParameter machineDeclarationParameter);
    }
}
