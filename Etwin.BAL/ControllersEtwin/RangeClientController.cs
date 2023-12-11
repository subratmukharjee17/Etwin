using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class RangeClientController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RangeClientController> _logger;
        private readonly BlRangeClient blRangeClient = null;

        #endregion

        public RangeClientController(ILogger<RangeClientController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRangeClient = new BlRangeClient(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRangeClient/{RangeClient}")]
        public async Task<bool> AddRangeClient(RangeClient rangeClient)
        {
            bool result = true;
            try
            {
                result = this.blRangeClient.AddRangeClient(rangeClient);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRangeClient/")]
        public async Task<IList<RangeClient>> GetRangeClient()
        {
            IList<RangeClient> lstRangeClient = new List<RangeClient>();
            try
            {
                lstRangeClient = this.blRangeClient.GetRangeClient();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRangeClient;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRangeClient/{idRangeClient}")]
        public async Task<RangeClient> GetRangeClient(int idRangeClient)
        {
            RangeClient rangeClient = new RangeClient();
            try
            {
                rangeClient = this.blRangeClient.GetRangeClient(idRangeClient);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return rangeClient;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRangeClient/{rangeClient}")]
        public async Task<bool> UpdateRangeClient(RangeClient rangeClient)
        {
            bool result = true;
            try
            {
                result = this.blRangeClient.UpdateRangeClient(rangeClient);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRangeClient/{rangeClient}")]
        public async Task<bool> DeleteRangeClient(RangeClient rangeClient)
        {
            bool result = true;
            try
            {
                result = this.blRangeClient.DeleteRangeClient(rangeClient);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}