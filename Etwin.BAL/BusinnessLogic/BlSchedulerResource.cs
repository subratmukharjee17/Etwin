using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlSchedulerResource : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlSchedulerResource(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public IList<SchedulerResourceMapping> GetSchedulerResource()
        {
            //clsLog.Info(">>> GetSchedulerResource - INIZIO");

            IList<SchedulerResourceMapping> lstSchedulersResource = new List<SchedulerResourceMapping>();

            try
            {
                lstSchedulersResource = this.unitOfWork.SchedulerResource.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstSchedulersResource.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerResource - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerResource - FINE");
            }

            return lstSchedulersResource;
        }

        public SchedulerResourceMapping GetSchedulerResource(int idSchedulerResource)
        {
            //clsLog.Info(">>> GetSchedulerResource - INIZIO");

            SchedulerResourceMapping Resource = new SchedulerResourceMapping();

            try
            {
                Resource = this.unitOfWork.SchedulerResource.Get(idSchedulerResource);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerResource - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerResource - FINE");
            }

            return Resource;
        }

        public IList<SchedulerResourceMapping> GetSchedulerResources(int idScheduler)
        {
            //clsLog.Info(">>> GetSchedulerResources - INIZIO");

            IList<SchedulerResourceMapping> lstSchedulersResource = new List<SchedulerResourceMapping>();

            try
            {
                Expression<Func<SchedulerResourceMapping, bool>> expr = e => e.IdScheduler == idScheduler;
                lstSchedulersResource = this.unitOfWork.SchedulerResource.GetAll(expr, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstSchedulersResource.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerResources - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerResources - FINE");
            }

            return lstSchedulersResource;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
