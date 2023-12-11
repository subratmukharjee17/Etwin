using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class TaxCodeRepository : Repository<TaxCode>, ITaxCodeRepository
    {
        private readonly GlobalDbContext _db;

        public TaxCodeRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TaxCode taxCode)
        {
            var objFromDb = _db.TaxCodes.FirstOrDefault(s => s.Id == taxCode.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(taxCode);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
