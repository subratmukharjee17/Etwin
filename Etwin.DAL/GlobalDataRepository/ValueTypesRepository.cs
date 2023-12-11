using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using System.Linq;
using ValueType = Etwin.Model.GlobalModels.ValueType;

namespace  Etwin.DAL.GlobalDataRepository
{
    public class ValueTypesRepository : Repository<ValueType>, IValueTypesRepository
    {
        private readonly GlobalDbContext _db;

        public ValueTypesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ValueType valueType)
        {
            var objFromDb = _db.ValueTypes.FirstOrDefault(s => s.Id == valueType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(valueType);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
