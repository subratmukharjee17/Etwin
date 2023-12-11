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
    
    public class SchedulerDependencyController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<SchedulerDependencyController> _logger;
        private readonly BlSchedulerDependency blSchedulerDependency = null;

        #endregion

        public SchedulerDependencyController(ILogger<SchedulerDependencyController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blSchedulerDependency = new BlSchedulerDependency(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerDependency")]
        public async Task<IList<SchedulerDependencyMapping>> GetSchedulerDependency()
        {
            IList<SchedulerDependencyMapping> lstSchedulerDependencyMapping = new List<SchedulerDependencyMapping>();
            try
            {
                lstSchedulerDependencyMapping = this.blSchedulerDependency.GetSchedulerDependency();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstSchedulerDependencyMapping;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerDependencys/{idSchedulerDependency}")]
        public async Task<SchedulerDependencyMapping> GetSchedulerDependencys(int idSchedulerDependency)
        {
            SchedulerDependencyMapping appointment = new SchedulerDependencyMapping();
            try
            {
                appointment = this.blSchedulerDependency.GetSchedulerDependency(idSchedulerDependency);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return appointment;
        }
    }
}