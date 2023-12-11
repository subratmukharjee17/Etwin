using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class GeneralSettingActiveRepository : Repository<GeneralSettingActive>, IGeneralSettingActiveRepository
    {
        private readonly ETwinContext _db;

        public GeneralSettingActiveRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GeneralSettingActive generalSettingActive)
        {
            var objFromDb = this._db.GeneralSettingActives.FirstOrDefault(s => s.Id == generalSettingActive.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(generalSettingActive);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
