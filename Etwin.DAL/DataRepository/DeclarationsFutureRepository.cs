using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class DeclarationsFutureRepository : Repository<DeclarationsFuture>, IDeclarationsFutureRepository
    {
        private readonly ETwinContext _db;

        public DeclarationsFutureRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DeclarationsFuture declaration)
        {
            var objFromDb = this._db.DeclarationsFutures.FirstOrDefault(s => s.IdDeclaration == declaration.IdDeclaration);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(declaration);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
