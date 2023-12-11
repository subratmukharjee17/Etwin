using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class DocumentArchiveValueRepository : Repository<DocumentArchiveValue>, IDocumentArchiveValueRepository
    {
        private readonly ETwinContext _db;

        public DocumentArchiveValueRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DocumentArchiveValue documentArchiveValue)
        {
            var objFromDb = this._db.DocumentArchiveValues.FirstOrDefault(s => s.Id == documentArchiveValue.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(documentArchiveValue);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
