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
    
    public class ChartStripsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartStripsController> _logger;
        private readonly BlChartStrips blChartStrips = null;

        #endregion

        public ChartStripsController(ILogger<ChartStripsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartStrips = new BlChartStrips(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartStrips/{chartStrip}")]
        public async Task<bool> AddChartStrips(ChartStrip chartStrip)
        {
            bool result = true;
            try
            {
                result = this.blChartStrips.AddChartStrips(chartStrip);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartStrip/")]
        public async Task<IList<ChartStrip>> GetChartStrip()
        {
            IList<ChartStrip> lstChartStrip = new List<ChartStrip>();
            try
            {
                lstChartStrip = this.blChartStrips.GetChartStrip();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartStrip;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartStrip/{idChartStrip}")]
        public async Task<ChartStrip> GetChartStrip(int idChartStrip)
        {
            ChartStrip chartStrips = new ChartStrip();
            try
            {
                chartStrips = this.blChartStrips.GetChartStrip(idChartStrip);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartStrips;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartStrip/{chartStrip}")]
        public async Task<bool> UpdateChartStrips(ChartStrip chartStrip)
        {
            bool result = true;
            try
            {
                result = this.blChartStrips.UpdateChartStrip(chartStrip);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartStrip/{chartStrip}")]
        public async Task<bool> DeleteChartStrips(ChartStrip chartStrip)
        {
            bool result = true;
            try
            {
                result = this.blChartStrips.DeleteChartStrip(chartStrip);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}