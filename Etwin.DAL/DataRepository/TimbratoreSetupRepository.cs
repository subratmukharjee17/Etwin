using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class TimbratoreSetupRepository : Repository<TimbratoreSetup>, ITimbratoreSetupRepository
    {
        private readonly ETwinContext _db;

        public TimbratoreSetupRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(TimbratoreSetup timbratoreSetup)
        {
            var objFromDb = this._db.TimbratoreSetups.FirstOrDefault(s => s.IdTimbratoreSetup == timbratoreSetup.IdTimbratoreSetup);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(timbratoreSetup);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
