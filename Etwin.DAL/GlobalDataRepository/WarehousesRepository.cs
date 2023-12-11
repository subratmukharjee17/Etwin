using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace  Etwin.DAL.GlobalDataRepository
{
    public class WarehousesRepository : Repository<Warehouse>, IWarehousesRepository
    {
        private readonly GlobalDbContext _db;

        public WarehousesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Warehouse warehouse)
        {
            var objFromDb = _db.Warehouses.FirstOrDefault(s => s.Id == warehouse.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(warehouse);

                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
