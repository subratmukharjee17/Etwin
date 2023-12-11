using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class BomRepository : Repository<Bom>, IBomRepository
    {
        private readonly ETwinContext _db;

        public BomRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Bom bom)
        {
            var objFromDb = this._db.Boms.FirstOrDefault(s => s.Id == bom.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(bom);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
