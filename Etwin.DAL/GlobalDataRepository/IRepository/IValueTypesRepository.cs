using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IValueTypesRepository : IRepository<ValueType>
    {
        void Update(ValueType valueType);
    }
}
