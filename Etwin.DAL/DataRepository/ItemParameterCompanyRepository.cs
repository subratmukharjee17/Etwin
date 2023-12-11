using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ItemParameterCompanyRepository : Repository<ItemParametersCompany>, IItemParameterCompanyRepository
    {
        private readonly ETwinContext _db;

        public ItemParameterCompanyRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemParametersCompany itemParametersCompany)
        {
            var objFromDb = this._db.ItemParametersCompanies.FirstOrDefault(s => s.IdItemParameterCompany == itemParametersCompany.IdItemParameterCompany);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemParametersCompany);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
