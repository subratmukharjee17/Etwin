using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class MacroProcessesRepository : Repository<MacroProcess>, IMacroProcessesRepository
    {
        private readonly ETwinContext _db;

        public MacroProcessesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MacroProcess macroProcess)
        {
            var objFromDb = this._db.MacroProcesses.FirstOrDefault(s => s.IdMacroProcess == macroProcess.IdMacroProcess);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(macroProcess);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
