using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class BandSetupController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<BandSetupController> _logger;
        private readonly BlBands blBand = null;

        #endregion

        public BandSetupController(ILogger<BandSetupController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blBand = new BlBands(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddBand/")]
        public async Task<bool> AddBand(GridBand band)
        {
            bool result = true;

            clsLog.Info("AddBand INIZIO");
            try
            {
                result = this.blBand.AddBand(band);
                clsLog.Info("AddBand result: " + result.ToString());
            }
            catch (Exception ex)
            {
                clsLog.Error("AddBand Error: " + ex.ToString());
            }
            finally
            {
                clsLog.Info("AddBand FINE");
            }

            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetBands/")]
        public async Task<IList<GridBand>> GetBands()
        {
            IList<GridBand> lstBands = this.blBand.GetBands();
            return lstBands;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetBands/{idGrid}")]
        public async Task<BindingList<GridBand>> GetBands(int idGrid)
        {
            BindingList<GridBand> lstBands = this.blBand.GetBands(idGrid);
            return lstBands;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetBand/{idBand}")]
        public async Task<GridBand> GetBand(int idBand)
        {
            GridBand band = this.blBand.GetBand(idBand);
            return band;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateBand/")]
        public async Task<bool> UpdateBand(GridBand band)
        {
            bool result = this.blBand.UpdateBand(band);
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetMaxOrdineBand/{idGrid}")]
        public async Task<int> GetMaxOrdineBand(int idGrid)
        {
            int ordine = this.blBand.GetMaxOrdineBand(idGrid);
            return ordine;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteBand/{idBand}")]
        public async Task<bool> DeleteBand(int idBand)
        {
            GridBand band = this.blBand.GetBand(idBand);
            bool result = this.blBand.DeleteBand(band);
            return result;
        }
    }
}