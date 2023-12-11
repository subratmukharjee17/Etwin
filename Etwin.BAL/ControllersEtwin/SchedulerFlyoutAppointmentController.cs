using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class SchedulerFlyoutAppointmentController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<SchedulerFlyoutAppointmentController> _logger;
        private readonly BlSchedulerFlyoutAppointment blSchedulerFlyoutAppointment = null;

        #endregion

        public SchedulerFlyoutAppointmentController(ILogger<SchedulerFlyoutAppointmentController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blSchedulerFlyoutAppointment = new BlSchedulerFlyoutAppointment(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerFlyoutAppointments/{idScheduler}")]
        public async Task<IList<SchedulerFlyoutAppointment>> GetSchedulerFlyoutAppointments(int idScheduler)
        {
            IList<SchedulerFlyoutAppointment> lstSchedulerFlyoutAppointment = new List<SchedulerFlyoutAppointment>();
            try
            {
                lstSchedulerFlyoutAppointment = this.blSchedulerFlyoutAppointment.GetSchedulerFlyoutAppointments(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstSchedulerFlyoutAppointment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerFlyoutAppointment/{idScheduler}")]
        public async Task<SchedulerFlyoutAppointment> GetSchedulerFlyoutAppointment(int idScheduler)
        {
            SchedulerFlyoutAppointment appointment = new SchedulerFlyoutAppointment();
            try
            {
                appointment = this.blSchedulerFlyoutAppointment.GetSchedulerFlyoutAppointment(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return appointment;
        }
    }
}