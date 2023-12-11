using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class MaterialSubCategoriesValueRepository : Repository<MaterialSubCategoriesValue>, IMaterialSubCategoriesValueRepository
    {
        private readonly GlobalDbContext _db;

        public MaterialSubCategoriesValueRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MaterialSubCategoriesValue materialSubCategoriesValue)
        {
            var objFromDb = this._db.MaterialSubCategoriesValues.FirstOrDefault(s => s.Id == materialSubCategoriesValue.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(materialSubCategoriesValue);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
