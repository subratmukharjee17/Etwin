using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class InputWizardRepository : Repository<InputWizard>, IInputWizardRepository
    {
        private readonly ETwinContext _db;

        public InputWizardRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(InputWizard inputWizard)
        {
            var objFromDb = this._db.InputWizards.FirstOrDefault(s => s.Id == inputWizard.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(inputWizard);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
