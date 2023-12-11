using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class OrdersRowRepository : Repository<OrderRow>, IOrderRowRepository
    {
        private readonly ETwinContext _db;

        public OrdersRowRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OrderRow order)
        {
            var objFromDb = this._db.OrderRows.FirstOrDefault(s => s.IdOrderRow == order.IdOrderRow);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(order);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
