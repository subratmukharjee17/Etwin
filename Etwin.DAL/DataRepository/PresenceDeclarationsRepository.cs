using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class PresenceDeclarationsRepository : Repository<PresenceDeclaration>, IPresenceDeclarationsRepository
    {
        private readonly ETwinContext _db;

        public PresenceDeclarationsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(PresenceDeclaration presenceDeclaration)
        {
            var objFromDb = this._db.PresenceDeclarations.FirstOrDefault(s => s.IdPresenceDeclaration == presenceDeclaration.IdPresenceDeclaration);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(presenceDeclaration.IdPresenceDeclaration);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
