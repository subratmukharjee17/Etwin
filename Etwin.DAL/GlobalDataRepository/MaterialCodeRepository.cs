using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialCodeRepository : Repository<MaterialCode>, IMaterialCodeRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialCodeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialCode materialCode)
        {
            var objFromDb = this._db.MaterialCodes.FirstOrDefault(s => s.Id == materialCode.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialCode);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
