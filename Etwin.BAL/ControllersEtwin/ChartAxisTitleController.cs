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
    
    public class ChartAxisTitleController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartAxisTitleController> _logger;
        private readonly BlChartAxisTitle blChartAxisTitle = null;

        #endregion

        public ChartAxisTitleController(ILogger<ChartAxisTitleController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartAxisTitle = new BlChartAxisTitle(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartAxisTitle/{chartTitles}")]
        public async Task<bool> AddChartAxisTitle(ChartAxisTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartAxisTitle.AddChartAxisTitle(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAxisTitle/")]
        public async Task<IList<ChartAxisTitle>> GetChartAxisTitle()
        {
            IList<ChartAxisTitle> lstChartAxisTitle = new List<ChartAxisTitle>();
            try
            {
                lstChartAxisTitle = this.blChartAxisTitle.GetChartAxisTitle();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartAxisTitle;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAxisTitle/{idChart}")]
        public async Task<IList<ChartAxisTitle>> GetChartAxisTitle(int idChart)
        {
            IList<ChartAxisTitle> lstChartAxisTitle = new List<ChartAxisTitle>();
            try
            {
                lstChartAxisTitle = this.blChartAxisTitle.GetChartAxisTitle(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartAxisTitle;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartAxisTitle/{idChartTitles}")]
        public async Task<ChartAxisTitle> GetChartAxisTitles(int idChartTitles)
        {
            ChartAxisTitle chartAxisTitle = new ChartAxisTitle();
            try
            {
                chartAxisTitle = this.blChartAxisTitle.GetChartAxisTitles(idChartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartAxisTitle;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartAxisTitle/{chartTitles}")]
        public async Task<bool> UpdateChartAxisTitle(ChartAxisTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartAxisTitle.UpdateChartAxisTitle(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartAxisTitle/{chartTitles}")]
        public async Task<bool> DeleteChartAxisTitle(ChartAxisTitle chartTitles)
        {
            bool result = true;
            try
            {
                result = this.blChartAxisTitle.DeleteChartAxisTitle(chartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}