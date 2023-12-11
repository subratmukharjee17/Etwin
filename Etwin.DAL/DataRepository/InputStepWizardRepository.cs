﻿using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class InputStepWizardRepository : Repository<InputStepWizard>, IInputStepWizardRepository
    {
        private readonly ETwinContext _db;

        public InputStepWizardRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(InputStepWizard inputStepWizard)
        {
            var objFromDb = this._db.InputStepWizards.FirstOrDefault(s => s.Id == inputStepWizard.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(inputStepWizard);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
