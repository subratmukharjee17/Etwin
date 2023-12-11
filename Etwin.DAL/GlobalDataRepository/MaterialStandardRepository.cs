using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialStandardRepository : Repository<MaterialStandard>, IMaterialStandardRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialStandardRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialStandard materialStandard)
        {
            var objFromDb = this._db.MaterialStandards.FirstOrDefault(s => s.Id == materialStandard.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialStandard);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
