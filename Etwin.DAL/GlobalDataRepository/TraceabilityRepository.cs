using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueType = Etwin.Model.GlobalModels.ValueType;

namespace  Etwin.DAL.GlobalDataRepository
{
    public class TraceabilityRepository : Repository<Traceability>, ITraceabilityRepository
    {
        private readonly GlobalDbContext _db;

        public TraceabilityRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Traceability traceability)
        {
            var objFromDb = _db.Traceabilities.FirstOrDefault(s => s.Id == traceability.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(traceability);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
