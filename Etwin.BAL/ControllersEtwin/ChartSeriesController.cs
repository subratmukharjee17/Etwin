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
    
    public class ChartSeriesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartSeriesController> _logger;
        private readonly BlChartSeries blChartSeries = null;

        #endregion

        public ChartSeriesController(ILogger<ChartSeriesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartSeries = new BlChartSeries(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartSerie/{chartSeries}")]
        public async Task<bool> AddChartSeries(ChartSeries chartSeries)
        {
            bool result = true;
            try
            {
                result = this.blChartSeries.AddChartSeries(chartSeries);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartSeries/{idChart}")]
        public async Task<IList<ChartSeries>> GetChartSeries(int? idChart = null)
        {
            IList<ChartSeries> lstChartSerie = new List<ChartSeries>();
            try
            {
                lstChartSerie = this.blChartSeries.GetChartSeries(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartSerie;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartSerie/{idChartSerie}")]
        public async Task<ChartSeries> GetChartSerie(int idChartSerie)
        {
            ChartSeries chartSerie = new ChartSeries();
            try
            {
                chartSerie = this.blChartSeries.GetChartSerie(idChartSerie);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartSerie;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetStrips/{idSerie}")]
        public async Task<IList<ChartStrip>> GetStrips(int idSerie)
        {
            IList<ChartStrip> lstStrip = new List<ChartStrip>();
            try
            {
                lstStrip = this.blChartSeries.GetStrips(idSerie);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstStrip;
        }

      
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartConstantLine/{idSerie}")]
        public async Task<IList<ChartConstantLine>> GetChartConstantLine(int idSerie)
        {
            IList<ChartConstantLine> lstChartConstantLine = new List<ChartConstantLine>();
            try
            {
                lstChartConstantLine = this.blChartSeries.GetChartConstantLine(idSerie);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartConstantLine;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartSeries/{chartSeries}")]
        public async Task<bool> UpdateChartSeries(ChartSeries chartSeries)
        {
            bool result = true;
            try
            {
                result = this.blChartSeries.UpdateChartSeries(chartSeries);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartSerie/{chartSerie}")]
        public async Task<bool> DeleteChartSerie(ChartSeries chartSerie)
        {
            bool result = true;
            try
            {
                result = this.blChartSeries.DeleteChartSerie(chartSerie);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAnimations/{idChart}")]
        public async Task<IList<ChartAnimation>> GetChartAnimations(int idChart)
        {
            IList<ChartAnimation> lstChartAnimation = new List<ChartAnimation>();
            try
            {
                lstChartAnimation = this.blChartSeries.GetChartAnimations(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartAnimation;
        }
    }
}