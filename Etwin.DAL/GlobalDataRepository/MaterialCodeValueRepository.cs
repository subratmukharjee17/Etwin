using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialCodeValueRepository : Repository<MaterialCodeValue>, IMaterialCodeValueRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialCodeValueRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialCodeValue materialCodeValue)
        {
            var objFromDb = this._db.MaterialCodeValues.FirstOrDefault(s => s.Id == materialCodeValue.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialCodeValue);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
