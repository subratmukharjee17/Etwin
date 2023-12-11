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
    public class WarehouseTypesRepository : Repository<WarehouseType>, IWarehouseTypesRepository
    {
        private readonly GlobalDbContext _db;

        public WarehouseTypesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WarehouseType warehouseType)
        {
            var objFromDb = _db.WarehouseTypes.FirstOrDefault(s => s.Id == warehouseType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(warehouseType);

                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
