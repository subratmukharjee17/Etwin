using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IInputControlTypeRepository : IRepository<InputControlType>
    {
        void Update(InputControlType inputControlType);
    }
}
