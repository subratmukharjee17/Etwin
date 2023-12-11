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
    public class WarehouseMovementTypesRepository : Repository<WarehouseMovementType>, IWarehouseMovementTypesRepository
    {
        private readonly GlobalDbContext _db;

        public WarehouseMovementTypesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WarehouseMovementType warehouseMovementType)
        {
            var objFromDb = _db.WarehouseMovementTypes.FirstOrDefault(s => s.Id == warehouseMovementType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(warehouseMovementType);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
