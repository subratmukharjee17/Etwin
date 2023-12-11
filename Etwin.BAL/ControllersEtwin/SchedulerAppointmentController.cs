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
    
    public class SchedulerAppointmentController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<SchedulerAppointmentController> _logger;
        private readonly BlSchedulerAppointment blSchedulerAppointment = null;

        #endregion

        public SchedulerAppointmentController(ILogger<SchedulerAppointmentController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blSchedulerAppointment = new BlSchedulerAppointment(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerAppointment/{idScheduler}")]
        public async Task<IList<SchedulerAppointmentMapping>> GetSchedulerAppointment(int idScheduler)
        {
            IList<SchedulerAppointmentMapping> lstSchedulerAppointmentMapping = new List<SchedulerAppointmentMapping>();
            try
            {
                lstSchedulerAppointmentMapping = this.blSchedulerAppointment.GetSchedulerAppointment(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstSchedulerAppointmentMapping;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerAppointments/{idSchedulerAppointment}")]
        public async Task<SchedulerAppointmentMapping> GetSchedulerAppointments(int idSchedulerAppointment)
        {
            SchedulerAppointmentMapping appointment = new SchedulerAppointmentMapping();
            try
            {
                appointment = this.blSchedulerAppointment.GetSchedulerAppointments(idSchedulerAppointment);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return appointment;
        }
    }
}