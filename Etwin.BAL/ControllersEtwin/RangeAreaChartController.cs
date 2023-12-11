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
    
    public class RangeAreaChartController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RangeAreaChartController> _logger;
        private readonly BlRangeAreaChart blRangeAreaChart = null;

        #endregion

        public RangeAreaChartController(ILogger<RangeAreaChartController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRangeAreaChart = new BlRangeAreaChart(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRangeAreaChart/{rangeAreaChart}")]
        public async Task<bool> AddRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            bool result = true;
            try
            {
                result = this.blRangeAreaChart.AddRangeAreaChart(rangeAreaChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRangeAreaChart/")]
        public async Task<IList<RangeAreaChart>> GetRangeAreaChart()
        {
            IList<RangeAreaChart> lstRangeAreaChart = new List<RangeAreaChart>();
            try
            {
                lstRangeAreaChart = this.blRangeAreaChart.GetRangeAreaChart();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRangeAreaChart;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRangeAreaChart/{idRangeAreaChart}")]
        public async Task<RangeAreaChart> GetRangeAreaChart(int idRangeAreaChart)
        {
            RangeAreaChart rangeAreaChart = new RangeAreaChart();
            try
            {
                rangeAreaChart = this.blRangeAreaChart.GetRangeAreaChart(idRangeAreaChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return rangeAreaChart;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRangeAreaChart/{RangeAreaChart}")]
        public async Task<bool> UpdateRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            bool result = true;
            try
            {
                result = this.blRangeAreaChart.UpdateRangeAreaChart(rangeAreaChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRangeAreaChart/{rangeAreaChart}")]
        public async Task<bool> DeleteRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            bool result = true;
            try
            {
                result = this.blRangeAreaChart.DeleteRangeAreaChart(rangeAreaChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}