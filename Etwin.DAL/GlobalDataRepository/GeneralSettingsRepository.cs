using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class GeneralSettingsRepository : Repository<GeneralSetting>, IGeneralSettingsRepository
    {
        private readonly GlobalDbContext _db;

        public GeneralSettingsRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GeneralSetting generalSetting)
        {
            var objFromDb = this._db.GeneralSettings.FirstOrDefault(s => s.Id == generalSetting.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(generalSetting);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
