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
    
    public class ChartTitleController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartTitleController> _logger;
        private readonly BlChartTitle blChartTitle = null;

        #endregion

        public ChartTitleController(ILogger<ChartTitleController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartTitle = new BlChartTitle(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartTitles/{chartTitles}")]
        public async Task<bool> AddChartTitle(ChartTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartTitle.AddChartTitles(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartTitles/")]
        public async Task<IList<ChartTitle>> GetChartTitles()
        {
            IList<ChartTitle> lstChartTitles = new List<ChartTitle>();
            try
            {
                lstChartTitles = this.blChartTitle.GetChartTitles();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartTitles;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartTitle/{IdChart}")]
        public async Task<IList<ChartTitle>> GetChartTitle(int IdChart)
        {
            IList<ChartTitle> lstChartTitles = new List<ChartTitle>();
            try
            {
                //lstChartTitles = this.blChartTitle.GetChartTitle(IdChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartTitles;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartTitle/{IdChartTitles}")]
        public async Task<ChartTitle> GetChartTitles(int IdChartTitles)
        {
            ChartTitle chartTitles = new ChartTitle();
            try
            {
                chartTitles = this.blChartTitle.GetChartTitles(IdChartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartTitles;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartTitles/{chartTitles}")]
        public async Task<bool> UpdateChartTitles(ChartTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartTitle.UpdateChartTitles(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartTitles/{chartTitles}")]
        public async Task<bool> DeleteChartTitles(ChartTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartTitle.DeleteChartTitles(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}