using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        private readonly GlobalDbContext _db;

        public DocumentTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DocumentType documentType)
        {
            var objFromDb = this._db.DocumentTypes.FirstOrDefault(s => s.Id == documentType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(documentType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
