using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class DocumentArchiveRepository : Repository<DocumentArchive>, IDocumentArchiveRepository
    {
        private readonly ETwinContext _db;

        public DocumentArchiveRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DocumentArchive documentArchive)
        {
            var objFromDb = this._db.DocumentArchives.FirstOrDefault(s => s.Id == documentArchive.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(documentArchive);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
