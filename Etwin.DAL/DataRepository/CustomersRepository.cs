using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        private readonly ETwinContext _db;

        public CustomersRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Customer customer)
        {
            var objFromDb = this._db.Customers.FirstOrDefault(s => s.IdCustomer == customer.IdCustomer);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(customer);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
