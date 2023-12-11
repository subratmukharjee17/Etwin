using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialSubCategoriesRepository : Repository<MaterialSubCategory>, IMaterialSubCategoriesRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialSubCategoriesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialSubCategory materialSubCategory)
        {
            var objFromDb = this._db.MaterialSubCategories.FirstOrDefault(s => s.Id == materialSubCategory.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialSubCategory);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
