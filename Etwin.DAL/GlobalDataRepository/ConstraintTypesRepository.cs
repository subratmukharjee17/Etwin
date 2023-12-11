using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ConstraintTypesRepository : Repository<ConstraintType>, IConstraintTypesRepository
    {
        private readonly GlobalDbContext _db;

        public ConstraintTypesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ConstraintType constraintTypes)
        {
            var objFromDb = this._db.AnalysisDrawings.FirstOrDefault(s => s.Id == constraintTypes.IdConstraintType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(constraintTypes);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
