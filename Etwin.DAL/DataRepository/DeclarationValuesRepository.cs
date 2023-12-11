using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class DeclarationValuesRepository : Repository<DeclarationValue>, IDeclarationValuesRepository
    {
        private readonly ETwinContext _db;

        public DeclarationValuesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DeclarationValue declarationValue)
        {
            var objFromDb = this._db.DeclarationValues.FirstOrDefault(s => s.IdDeclarationValues == declarationValue.IdDeclarationValues);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(declarationValue);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
