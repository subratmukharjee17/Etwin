using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System.Collections.Generic;
using System;
using Etwin.DAL.DataRepository;
using System.Linq;
using System.Threading.Tasks;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlGeneralSettingActive : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlGeneralSettingActive(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public GeneralSettingActive GetGeneralSettingActive(int id)
        {
            GeneralSettingActive detail = new GeneralSettingActive();
            try
            {
                Expression<Func<GeneralSettingActive, bool>> expr = e => e.IdGeneralSetting == id;
                detail = this.unitOfWork.GeneralSettingActive.GetFirstOrDefault(expr);
               
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return detail;
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
