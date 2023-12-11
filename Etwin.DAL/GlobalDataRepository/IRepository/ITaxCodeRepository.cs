using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface ITaxCodeRepository : IRepository<TaxCode>
    {
        void Update(TaxCode taxCode);
    }
}
