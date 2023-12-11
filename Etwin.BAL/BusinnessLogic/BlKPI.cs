using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlKPI : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlKPI(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public Kpi GetKpiById(int id)
        {
            Kpi kpi = new Kpi();
            try
            {
                Expression<Func<Kpi, bool>> expr = e => e.Id == id;
                kpi = this.unitOfWork.Kpi.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return kpi;
        }

        public IList<KpiParameter> GetKpiParametersList(int id)
        {
            IList<KpiParameter> kpi = new List<KpiParameter>();
            try
            {
                Expression<Func<KpiParameter, bool>> expr = e => e.IdKpi == id;
                kpi = this.unitOfWork.KpiParameters.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return kpi;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
