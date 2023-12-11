using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class BomTypeRepository : Repository<BomType>, IBomTypeRepository
    {
        private readonly GlobalDbContext _db;

        public BomTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(BomType bomType)
        {
            var objFromDb = this._db.BomTypes.FirstOrDefault(s => s.Id == bomType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(bomType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
