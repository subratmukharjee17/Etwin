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
    public class WarehouseProvenancesRepository : Repository<WarehouseProvenance>, IWarehouseProvenancesRepository
    {
        private readonly GlobalDbContext _db;

        public WarehouseProvenancesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WarehouseProvenance warehouseProvenance)
        {
            var objFromDb = _db.WarehouseProvenances.FirstOrDefault(s => s.Id == warehouseProvenance.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(warehouseProvenance);

                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
