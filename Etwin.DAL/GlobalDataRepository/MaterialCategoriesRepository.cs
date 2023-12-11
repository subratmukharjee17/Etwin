using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialCategoriesRepository : Repository<MaterialCategory>, IMaterialCategoriesRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialCategoriesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialCategory materialCategory)
        {
            var objFromDb = this._db.MaterialCategories.FirstOrDefault(s => s.Id == materialCategory.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialCategory);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
