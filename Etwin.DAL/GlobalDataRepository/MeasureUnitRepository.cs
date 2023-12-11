using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MeasureUnitRepository : Repository<MeasureUnit>, IMeasureUnitRepository
    {
        private readonly GlobalDbContext _db;

        public MeasureUnitRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MeasureUnit measureUnit)
        {
            var objFromDb = this._db.MeasureUnits.FirstOrDefault(s => s.IdMeasureUnit == measureUnit.IdMeasureUnit);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(measureUnit);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
