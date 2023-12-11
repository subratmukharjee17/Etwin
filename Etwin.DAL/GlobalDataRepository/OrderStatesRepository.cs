using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OrderStatesRepository : Repository<OrderState>, IOrderStatesRepository
    {
        private readonly GlobalDbContext _db;

        public OrderStatesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OrderState orderState)
        {
            var objFromDb = this._db.OrderStates.FirstOrDefault(s => s.IdOrderState == orderState.IdOrderState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(orderState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
