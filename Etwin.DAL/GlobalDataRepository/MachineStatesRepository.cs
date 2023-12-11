using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MachineStatesRepository : Repository<MachineState>, IMachineStatesRepository
    {
        private readonly GlobalDbContext _db;

        public MachineStatesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MachineState machineState)
        {
            var objFromDb = this._db.MachineStates.FirstOrDefault(s => s.IdMachineState == machineState.IdMachineState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(machineState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
