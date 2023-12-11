using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OperatorRolesRepository : Repository<OperatorRole>, IOperatorRolesRepository
    {
        private readonly GlobalDbContext _db;

        public OperatorRolesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorRole operatorRole)
        {
            var objFromDb = this._db.OperatorRoles.FirstOrDefault(s => s.IdOperatorRole == operatorRole.IdOperatorRole);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorRole);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
