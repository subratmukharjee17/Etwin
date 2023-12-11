using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using LogDll;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlSchedulerDependency : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlSchedulerDependency(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public IList<SchedulerDependencyMapping> GetSchedulerDependency()
        {
            //clsLog.Info(">>> GetSchedulerDependency - INIZIO");

            IList<SchedulerDependencyMapping> lstSchedulersDependency = new List<SchedulerDependencyMapping>();

            try
            {
                lstSchedulersDependency = this.unitOfWork.SchedulerDependency.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstSchedulersDependency.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerDependency - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerDependency - FINE");
            }

            return lstSchedulersDependency;
        }

        public SchedulerDependencyMapping GetSchedulerDependency(int idSchedulerDependency)
        {
            //clsLog.Info(">>> GetSchedulerDependency - INIZIO");

            SchedulerDependencyMapping Dependency = new SchedulerDependencyMapping();

            try
            {
                Dependency = this.unitOfWork.SchedulerDependency.Get(idSchedulerDependency);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerDependency - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerDependency - FINE");
            }

            return Dependency;
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
