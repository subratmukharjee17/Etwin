using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class DocumentArchiveParametersRepository : Repository<DocumentArchiveParameter>, IDocumentArchiveParametersRepository
    {
        private readonly GlobalDbContext _db;

        public DocumentArchiveParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DocumentArchiveParameter documentArchiveParameter)
        {
            var objFromDb = this._db.DocumentArchiveParameters.FirstOrDefault(s => s.Id == documentArchiveParameter.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(documentArchiveParameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
