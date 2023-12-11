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
    
    public class SchedulerResourceController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<SchedulerResourceController> _logger;
        private readonly BlSchedulerResource blSchedulerResource = null;

        #endregion

        public SchedulerResourceController(ILogger<SchedulerResourceController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blSchedulerResource = new BlSchedulerResource(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerResource/")]
        public async Task<IList<SchedulerResourceMapping>> GetSchedulerResource()
        {
            IList<SchedulerResourceMapping> lstSchedulerResource = new List<SchedulerResourceMapping>();
            try
            {
                lstSchedulerResource = this.blSchedulerResource.GetSchedulerResource();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstSchedulerResource;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerResource/{idScheduler}")]
        public async Task<SchedulerResourceMapping> GetSchedulerResource(int idScheduler)
        {
            SchedulerResourceMapping appointment = new SchedulerResourceMapping();
            try
            {
                appointment = this.blSchedulerResource.GetSchedulerResource(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return appointment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerResources/{idScheduler}")]
        public async Task<IList<SchedulerResourceMapping>> GetSchedulerResources(int idScheduler)
        {
            IList<SchedulerResourceMapping> lstSchedulerResource = new List<SchedulerResourceMapping>();
            try
            {
                lstSchedulerResource = this.blSchedulerResource.GetSchedulerResources(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstSchedulerResource;
        }
    }
}