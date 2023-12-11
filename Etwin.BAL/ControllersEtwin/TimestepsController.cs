using Etwin.BAL.BusinnessLogic;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class TimestepsController : ControllerBase
    {
        #region VARS

        private readonly IConfiguration _config;
        private readonly ILogger<TimestepsController> _logger;
        private readonly BlTimesteps blTimesteps;

        #endregion

        public TimestepsController(ILogger<TimestepsController> logger, IConfiguration config)
        {
            this._logger = logger;
            this._config = config;
            this.blTimesteps = new BlTimesteps();
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetTimestep/{idTimestep}")]
        public async Task<BindingList<Timestep>> GetTimestep(int idTimestep)
        {
            BindingList<Timestep> lstValoriCommessa = new BindingList<Timestep>();
            try
            {
                lstValoriCommessa = this.blTimesteps.GetTimestep(idTimestep);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            
            return lstValoriCommessa;
        }
    }
}