using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class OrdersValueRepository : Repository<OrderValue>, IOrderValueRepository
    {
        private readonly ETwinContext _db;

        public OrdersValueRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OrderValue order)
        {
            var objFromDb = this._db.OrderValues.FirstOrDefault(s => s.IdOrderValues == order.IdOrderValues);

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
