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
    
    public class SchedulerController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<SchedulerController> _logger;
        private readonly BlSchedulers blScheduler = null;

        #endregion

        public SchedulerController(ILogger<SchedulerController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blScheduler = new BlSchedulers(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddScheduler/{Scheduler}")]
        public async Task<bool> AddScheduler(Scheduler Scheduler)
        {
            bool result = true;
            try
            {
                result = this.blScheduler.AddScheduler(Scheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulers")]
        public async Task<IList<Scheduler>> GetSchedulers()
        {
            IList<Scheduler> lstScheduler = new List<Scheduler>();
            try
            {
                lstScheduler= this.blScheduler.GetSchedulers();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstScheduler;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetScheduler/{idScheduler}")]
        public async Task<Scheduler> GetScheduler(int idScheduler)
        {
            Scheduler lstScheduler = new Scheduler();
            try
            {
                lstScheduler = this.blScheduler.GetScheduler(idScheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstScheduler;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetSchedulerByName/{caption}")]
        public async Task<Scheduler> GetSchedulerByName(string caption)
        {
            Scheduler lstScheduler = new Scheduler();
            try
            {
                lstScheduler = this.blScheduler.GetSchedulerByName(caption);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstScheduler;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateScheduler/{scheduler}")]
        public async Task<bool> UpdateScheduler(Scheduler scheduler)
        {
            bool result = true;
            try
            {
                result = this.blScheduler.UpdateScheduler(scheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteScheduler/{scheduler}")]
        public async Task<bool> DeleteScheduler(Scheduler scheduler)
        {
            bool result = true;
            try
            {
                result = this.blScheduler.DeleteScheduler(scheduler);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}