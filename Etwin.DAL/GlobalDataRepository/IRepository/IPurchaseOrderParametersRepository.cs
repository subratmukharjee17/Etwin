using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPurchaseOrderParametersRepository : IRepository<PurchaseOrderParameter>
    {
        void Update(PurchaseOrderParameter purchaseOrderParameter);
    }
}
