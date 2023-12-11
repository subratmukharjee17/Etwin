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
    
    public class ChartAnimationsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartAnimationsController> _logger;
        private readonly BlChartAnimations blChartAnimations = null;

        #endregion

        public ChartAnimationsController(ILogger<ChartAnimationsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartAnimations = new BlChartAnimations(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartAnimations/{chartAnimation}")]
        public async Task<bool> AddChartAnimations(ChartAnimation chartAnimation)
        {
            bool result = true;
            try
            {
                result = this.blChartAnimations.AddChartAnimations(chartAnimation);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAnimations/")]
        public async Task<IList<ChartAnimation>> GetChartAnimations()
        {
            IList<ChartAnimation> lstChartAnimations = new List<ChartAnimation>();
            try
            {
                lstChartAnimations = this.blChartAnimations.GetChartAnimations();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartAnimations;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAnimations/{IdChartAnimations}")]
        public async Task<ChartAnimation> GetChartAnimations(int IdChartAnimations)
        {
            ChartAnimation chartAnimation = new ChartAnimation();
            try
            {
                chartAnimation = this.blChartAnimations.GetChartAnimations(IdChartAnimations);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartAnimation;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartAnimations/{chartAnimation}")]
        public async Task<bool> UpdateChartAnimations(ChartAnimation chartAnimation)
        {
            bool result = true;
            try
            {
                result = this.blChartAnimations.UpdateChartAnimations(chartAnimation);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartAnimations/{chartAnimation}")]
        public async Task<bool> DeleteChartAnimations(ChartAnimation chartAnimation)
        {
            bool result = true;
            try
            {
                result = this.blChartAnimations.DeleteChartAnimations(chartAnimation);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}