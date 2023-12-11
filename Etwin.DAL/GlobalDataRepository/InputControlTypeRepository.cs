using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class InputControlTypeRepository : Repository<InputControlType>, IInputControlTypeRepository
    {
        private readonly GlobalDbContext _db;

        public InputControlTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(InputControlType inputControlType)
        {
            var objFromDb = this._db.InputControlTypes.FirstOrDefault(s => s.Id == inputControlType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(inputControlType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
