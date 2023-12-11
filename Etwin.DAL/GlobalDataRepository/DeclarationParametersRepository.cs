using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class DeclarationParametersRepository : Repository<DeclarationParameter>, IDeclarationParametersRepository
    {
        private readonly GlobalDbContext _db;

        public DeclarationParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DeclarationParameter declarationParameters)
        {
            var objFromDb = this._db.AnalysisDrawings.FirstOrDefault(s => s.Id == declarationParameters.IdDeclarationParameter);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(declarationParameters);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
