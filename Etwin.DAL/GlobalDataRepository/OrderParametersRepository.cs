using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OrderParametersRepository : Repository<OrderParameter>, IOrderParametersRepository
    {
        private readonly GlobalDbContext _db;

        public OrderParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OrderParameter orderParameter)
        {
            var objFromDb = this._db.OrderParameters.FirstOrDefault(s => s.IdOrderParameter == orderParameter.IdOrderParameter);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(orderParameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
