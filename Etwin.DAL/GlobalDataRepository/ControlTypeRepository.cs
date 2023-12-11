using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ControlTypeRepository : Repository<ControlType>, IControlTypeRepository
    {
        private readonly GlobalDbContext _db;

        public ControlTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ControlType controlType)
        {
            var objFromDb = this._db.ControlTypes.FirstOrDefault(s => s.IdType == controlType.IdType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(controlType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
