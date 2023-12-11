using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace  Etwin.DAL.GlobalDataRepository
{
    public class TraceabilityParameterRepository : Repository<TraceabilityParameter>, ITraceabilityParameterRepository
    {
        private readonly GlobalDbContext _db;

        public TraceabilityParameterRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TraceabilityParameter traceabilityParameter)
        {
            var objFromDb = _db.TraceabilityParameters.FirstOrDefault(s => s.Id == traceabilityParameter.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(traceabilityParameter);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
