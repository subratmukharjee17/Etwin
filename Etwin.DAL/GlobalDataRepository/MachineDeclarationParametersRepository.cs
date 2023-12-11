using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MachineDeclarationParametersRepository : Repository<MachineDeclarationParameter>, IMachineDeclarationParametersRepository
    {
        private readonly GlobalDbContext _db;

        public MachineDeclarationParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MachineDeclarationParameter machineDeclarationParameter)
        {
            var objFromDb = this._db.MachineDeclarationParameters.FirstOrDefault(s => s.IdMachineDeclarationParameter == machineDeclarationParameter.IdMachineDeclarationParameter);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(machineDeclarationParameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
