using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMovementTypesRepository : IRepository<MovementType>
    {
        void Update(MovementType movementType);
    }
}
