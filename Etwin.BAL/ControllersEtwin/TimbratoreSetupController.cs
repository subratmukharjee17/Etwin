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
    
    public class TimbratoreSetupController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<TimbratoreSetupController> _logger;
        private readonly BlTimbratoreSetup blTimbratoreSetup = null;

        #endregion

        public TimbratoreSetupController(ILogger<TimbratoreSetupController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blTimbratoreSetup = new BlTimbratoreSetup(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddTimbratoreSetup/{TimbratoreSetup}")]
        public async Task<bool> AddTimbratoreSetup(TimbratoreSetup TimbratoreSetup)
        {
            bool result = true;
            try
            {
                result = this.blTimbratoreSetup.AddTimbratoreSetup(TimbratoreSetup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetTimbratoreSetups/")]
        public async Task<IList<TimbratoreSetup>> GetTimbratoreSetup()
        {
            IList<TimbratoreSetup> lstTimbratoreSetup = new List<TimbratoreSetup>();
            try
            {
                lstTimbratoreSetup = this.blTimbratoreSetup.GetTimbratoreSetup();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstTimbratoreSetup;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChildLevel/{idparent}")]
        public async Task<TimbratoreSetup> GetChildLevel(int idparent)
        {
            TimbratoreSetup timbratoreSetup = new TimbratoreSetup();
            try
            {
                timbratoreSetup = this.blTimbratoreSetup.GetChildLevel(idparent);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return timbratoreSetup;
        }


        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetTimbratoreSetup/{idTimbratoreSetup}")]
        public async Task<TimbratoreSetup> GetTimbratoreSetup(int idTimbratoreSetup)
        {
            TimbratoreSetup timbratoreSetup = new TimbratoreSetup();
            try
            {
                timbratoreSetup = this.blTimbratoreSetup.GetTimbratoreSetup(idTimbratoreSetup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return timbratoreSetup;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateTimbratoreSetup/{TimbratoreSetup}")]
        public async Task<bool> UpdateTimbratoreSetup(TimbratoreSetup TimbratoreSetup)
        {
            bool result = true;
            try
            {
                result = this.blTimbratoreSetup.UpdateTimbratoreSetup(TimbratoreSetup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpPut]
        [AcceptVerbs("GET")]
        [Route("api/GetLevelByName/{name}")]
        public async Task<TimbratoreSetup> GetLevelByName(string name)
        {
            TimbratoreSetup result = null;
            try
            {
                result = this.blTimbratoreSetup.GetLevelByName(name);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteTimbratoreSetup/{TimbratoreSetup}")]
        public async Task<bool> DeleteTimbratoreSetup(TimbratoreSetup TimbratoreSetup)
        {
            bool result = true;
            try
            {
                result = this.blTimbratoreSetup.DeleteTimbratoreSetup(TimbratoreSetup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}