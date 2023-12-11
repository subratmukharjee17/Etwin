using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMachineStatesRepository : IRepository<MachineState>
    {
        void Update(MachineState machineState);
    }
}
