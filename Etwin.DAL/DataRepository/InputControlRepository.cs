using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class InputControlRepository : Repository<InputControl>, IInputControlRepository
    {
        private readonly ETwinContext _db;

        public InputControlRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(InputControl inputControl)
        {
            var objFromDb = this._db.InputControls.FirstOrDefault(s => s.Id == inputControl.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(inputControl);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
