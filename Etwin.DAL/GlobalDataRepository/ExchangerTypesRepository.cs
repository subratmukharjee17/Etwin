using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ExchangerTypesRepository : Repository<ExchangerType>, IExchangerTypesRepository
    {
        private readonly GlobalDbContext _db;

        public ExchangerTypesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ExchangerType exchangerType)
        {
            var objFromDb = this._db.ExchangerTypes.FirstOrDefault(s => s.IdExchangerTypes == exchangerType.IdExchangerTypes);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(exchangerType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
