using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OperatorAccessRepository : Repository<OperatorAccess>, IOperatorAccessRepository
    {
        private readonly GlobalDbContext _db;

        public OperatorAccessRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorAccess operatorAccess)
        {
            var objFromDb = this._db.OperatorAccesses.FirstOrDefault(s => s.IdOperatorAccess == operatorAccess.IdOperatorAccess);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorAccess);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
