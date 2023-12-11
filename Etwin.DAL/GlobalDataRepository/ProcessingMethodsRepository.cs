using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class ProcessingMethodsRepository : Repository<ProcessingMethod>, IProcessingMethodsRepository
    {
        private readonly GlobalDbContext _db;

        public ProcessingMethodsRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProcessingMethod processingMethod)
        {
            var objFromDb = _db.ProcessingMethods.FirstOrDefault(s => s.IdProcessingMethodology == processingMethod.IdProcessingMethodology);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(processingMethod);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
