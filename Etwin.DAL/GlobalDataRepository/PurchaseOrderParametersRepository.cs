using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class PurchaseOrderParametersRepository : Repository<PurchaseOrderParameter>, IPurchaseOrderParametersRepository
    {
        private readonly GlobalDbContext _db;

        public PurchaseOrderParametersRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PurchaseOrderParameter purchaseOrderParameter)
        {
            var objFromDb = _db.PurchaseOrderParameters.FirstOrDefault(s => s.Id == purchaseOrderParameter.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(purchaseOrderParameter);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
