using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RangeClientRepository : Repository<RangeClient>, IRangeClientRepository
    {
        private readonly ETwinContext _db;

        public RangeClientRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(RangeClient rangeClient)
        {
            var objFromDb = this._db.RangeClients.FirstOrDefault(s => s.IdRangeClient == rangeClient.IdRangeClient);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(rangeClient);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
