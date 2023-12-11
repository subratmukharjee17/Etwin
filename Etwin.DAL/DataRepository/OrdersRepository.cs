using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        private readonly ETwinContext _db;

        public OrdersRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Order order)
        {
            var objFromDb = this._db.Orders.FirstOrDefault(s => s.Id == order.Id);

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
