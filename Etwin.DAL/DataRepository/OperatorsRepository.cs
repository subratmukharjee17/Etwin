using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class OperatorsRepository : Repository<Operator>, IOperatorsRepository
    {
        private readonly ETwinContext _db;

        public OperatorsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Operator operators)
        {
            var objFromDb = this._db.Operators.FirstOrDefault(s => s.OperatorCode == operators.OperatorCode);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operators);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
