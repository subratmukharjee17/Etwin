using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OrderTypeRepository : Repository<OrderType>, IOrderTypeRepository
    {
        private readonly GlobalDbContext _db;

        public OrderTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OrderType orderType)
        {
            var objFromDb = this._db.OrderTypes.FirstOrDefault(s => s.IdOrderType == orderType.IdOrderType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(orderType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
