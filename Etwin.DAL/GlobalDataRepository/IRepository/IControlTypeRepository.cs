using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IControlTypeRepository : IRepository<ControlType>
    {
        void Update(ControlType controlType);
    }
}
