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
    public class BlSchedulerFlyoutAppointment : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlSchedulerFlyoutAppointment(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public IList<SchedulerFlyoutAppointment> GetSchedulerFlyoutAppointments(int idScheduler)
        {

            IList<SchedulerFlyoutAppointment> lstSchedulerFlyoutAppointment = new List<SchedulerFlyoutAppointment>();

            try
            {
                Expression<Func<SchedulerFlyoutAppointment, bool>> expr = e => e.IdScheduler == idScheduler;
                lstSchedulerFlyoutAppointment = this.unitOfWork.SchedulerFlyoutAppointment.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerFlyoutAppointments - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETBANDS - FINE");
            }

            return lstSchedulerFlyoutAppointment;
        }

        public SchedulerFlyoutAppointment GetSchedulerFlyoutAppointment(int idScheduler)
        {

            SchedulerFlyoutAppointment flyout = new SchedulerFlyoutAppointment();

            try
            {
                Expression<Func<SchedulerFlyoutAppointment, bool>> expr = e => e.IdScheduler == idScheduler;
                flyout = this.unitOfWork.SchedulerFlyoutAppointment.Get(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerFlyoutAppointment - Error: " + ex.ToString());
            }


            return flyout;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
