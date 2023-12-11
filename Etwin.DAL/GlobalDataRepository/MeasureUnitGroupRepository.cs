using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MeasureUnitGroupRepository : Repository<MeasureUnitGroup>, IMeasureUnitGroupRepository
    {
        private readonly GlobalDbContext _db;

        public MeasureUnitGroupRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MeasureUnitGroup measureUnitGroup)
        {
            var objFromDb = this._db.MeasureUnitGroups.FirstOrDefault(s => s.IdMeasureUnitGroup == measureUnitGroup.IdMeasureUnitGroup);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(measureUnitGroup);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
