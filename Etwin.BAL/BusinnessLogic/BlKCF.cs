using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using LogDll;
using System;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlKCF : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlKCF(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public bool IsExecuteToday()
        {
            bool Today = false;
            KcfPlanner kcf = new KcfPlanner();
            try
            {
                kcf = this.unitOfWork.Kcf.GetFirstOrDefault();
                if(kcf.CreationDate.Date == DateTime.Today.Date)
                {
                    Today = true;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return Today;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
