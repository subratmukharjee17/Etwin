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
    public class BlSchedulerAppointment : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlSchedulerAppointment(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public IList<SchedulerAppointmentMapping> GetSchedulerAppointment(int idScheduler)
        {
            //clsLog.Info(">>> GetSchedulerAppointment - INIZIO");

            IList<SchedulerAppointmentMapping> lstSchedulersAppointment = new List<SchedulerAppointmentMapping>();

            try
            {
                Expression<Func<SchedulerAppointmentMapping, bool>> expr = e => e.IdScheduler == idScheduler;
                lstSchedulersAppointment = this.unitOfWork.SchedulerAppointments.GetAll(expr, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstSchedulersAppointment.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerAppointment - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerAppointment - FINE");
            }

            return lstSchedulersAppointment;
        }

        public SchedulerAppointmentMapping GetSchedulerAppointments(int idSchedulerAppointment)
        {
            //clsLog.Info(">>> GetSchedulerAppointment - INIZIO");

            SchedulerAppointmentMapping appointment = new SchedulerAppointmentMapping();

            try
            {
                //appointment = this.unitOfWork.SchedulerAppointments.Get(idSchedulerAppointment);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetSchedulerAppointment - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GetSchedulerAppointment - FINE");
            }

            return appointment;
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
