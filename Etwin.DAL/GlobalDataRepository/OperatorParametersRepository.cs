using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OperatorParametersRepository : Repository<OperatorParameter>, IOperatorParametersRepository
    {
        private readonly GlobalDbContext _db;

        public OperatorParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorParameter operatorParameter)
        {
            var objFromDb = this._db.OperatorParameters.FirstOrDefault(s => s.IdOperatorParameter == operatorParameter.IdOperatorParameter);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorParameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
