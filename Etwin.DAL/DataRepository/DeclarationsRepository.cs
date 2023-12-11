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
    public class DeclarationsRepository : Repository<Declaration>, IDeclarationsRepository
    {
        private readonly ETwinContext _db;

        public DeclarationsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Declaration declaration)
        {
            var objFromDb = this._db.Declarations.FirstOrDefault(s => s.IdDeclaration == declaration.IdDeclaration);

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
