using Etwin.Model;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using LogDll;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlSchedulers : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlSchedulers(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddScheduler(Scheduler scheduler)
        {
            //clsLog.Info(">>> ADDSCHEDULER - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Scheduler.Add(scheduler);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDSCHEDULER - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADDSCHEDULER - FINE");
            }

            return result;
        }


        public IList<Scheduler> GetSchedulers()
        {
            //clsLog.Info(">>> GETSCHEDULERS - INIZIO");

            IList<Scheduler> lstSchedulers = new List<Scheduler>();

            try
            {
                lstSchedulers = this.unitOfWork.Scheduler.GetAll(null, null, string.Empty).ToList();
                //clsLog.Info(">>> Record trovati: " + lstSchedulers.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETSCHEDULERS - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETSCHEDULERS - FINE");
            }

            return lstSchedulers;
        }


        public Scheduler GetScheduler(int idScheduler)
        {
            //clsLog.Info(">>> GETSCHEDULER - INIZIO");

            Scheduler scheduler = new Scheduler();

            try
            {
                scheduler = this.unitOfWork.Scheduler.Get(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETSCHEDULER - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETSCHEDULER - FINE");
            }

            return scheduler;
        }

        public Scheduler GetSchedulerByName(string caption)
        {
            Scheduler scheduler = null;
            try
            {
                Expression<Func<Scheduler, bool>> expr = e => e.SchedulerName == caption;

                scheduler = this.unitOfWork.Scheduler.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return scheduler;
        }

        public bool UpdateScheduler(Scheduler scheduler)
        {
            //clsLog.Info(">>> UPDATESCHEDULER - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Scheduler.Update(scheduler);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATESCHEDULER - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATESCHEDULER - FINE");
            }

            return result;
        }

        public bool DeleteScheduler(Scheduler scheduler)
        {
            //clsLog.Info(">>> DELETESCHEDULER - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Scheduler.Remove(scheduler);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETESCHEDULER - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETESCHEDULER - FINE");
            }

            return result;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
