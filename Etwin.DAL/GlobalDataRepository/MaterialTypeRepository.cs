using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialType materialType)
        {
            var objFromDb = this._db.MaterialTypes.FirstOrDefault(s => s.IdMaterialType == materialType.IdMaterialType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
