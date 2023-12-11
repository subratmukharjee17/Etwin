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
    
    public class GanttsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<GanttsController> _logger;
        private readonly BlGantts blGantts = null;

        #endregion

        public GanttsController(ILogger<GanttsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blGantts = new BlGantts(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddGantts/{Gantts}")]
        public async Task<bool> AddGantts(Gantt Gantts)
        {
            bool result = true;
            try
            {
                result = this.blGantts.AddGantts(Gantts);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGanttByName/{caption}")]
        public async Task<Gantt> GetGanttByName(string caption)
        {
            Gantt gantt = new Gantt();
            try
            {
                gantt = this.blGantts.GetGanttByName(caption);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return gantt;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGantts/")]
        public async Task<IList<Gantt>> GetGantts()
        {
            IList<Gantt> lstGantts = new List<Gantt>();
            try
            {
                lstGantts = this.blGantts.GetGantts();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstGantts;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGantts/{IdGantts}")]
        public async Task<Gantt> GetGanttss(int IdGantts)
        {
            Gantt gantts = new Gantt();
            try
            {
                gantts = this.blGantts.GetGantts(IdGantts);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return gantts;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateGantts/{gantts}")]
        public async Task<bool> UpdateGantts(Gantt gantts)
        {
            bool result = true;
            try
            {
                result = this.blGantts.UpdateGantts(gantts);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteGantts/{gantts}")]
        public async Task<bool> DeleteGantts(Gantt gantts)
        {
            bool result = true;
            try
            {
                result = this.blGantts.DeleteGantts(gantts);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}