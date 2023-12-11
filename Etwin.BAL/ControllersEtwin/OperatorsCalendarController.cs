using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class OperatorsCalendarController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<OperatorsCalendarController> _logger;
        private readonly BlOperatorsCalendars blOperatorsCalendar = null;

        #endregion

        public OperatorsCalendarController(ILogger<OperatorsCalendarController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blOperatorsCalendar = new BlOperatorsCalendars(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetOperatorsCalendar/{idOperatorsCalendar}")]
        public async Task<BindingList<OperatorsCalendar>> GetOperatorsCalendar(int idOperatorsCalendar)
        {
            BindingList<OperatorsCalendar> bindingListOperatorsCalendar = new BindingList<OperatorsCalendar>();
            try
            {
                bindingListOperatorsCalendar = this.blOperatorsCalendar.GetOperatorsCalendar(idOperatorsCalendar);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListOperatorsCalendar;
        }
    }
}