using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private readonly GlobalDbContext _db;

        public CurrencyRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Currency currency)
        {
            var objFromDb = this._db.Currencies.FirstOrDefault(s => s.Id == currency.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(currency);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
