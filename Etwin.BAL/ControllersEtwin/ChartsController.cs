using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class ChartsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartsController> _logger;
        private readonly BlCharts blCharts = null;

        #endregion

        public ChartsController(ILogger<ChartsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blCharts = new BlCharts(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChart/{chart}")]
        public async Task<bool> AddChart(Chart chart)
        {
            bool result = true;
            try
            {
                result = this.blCharts.AddChart(chart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetCharts/")]
        public async Task<IList<Chart>> GetCharts()
        {
            IList<Chart> lstCharts = new List<Chart>();
            try
            {
                lstCharts = this.blCharts.GetCharts();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstCharts;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartByName/{caption}")]
        public async Task<Chart> GetChartByName(string caption)
        {
            Chart chart = new Chart();
            try
            {
                chart = this.blCharts.GetChartByName(caption);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chart;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChart/{chartName}")]
        public async Task<BindingList<Chart>> GetChart(string chartName)
        {
            BindingList<Chart> bindingList = new BindingList<Chart>();
            try
            {
                bindingList = this.blCharts.GetChart(chartName);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingList;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChart/{idChart}")]
        public async Task<Chart> GetChart(int idChart)
        {
            Chart chart = new Chart();
            try
            {
                chart = this.blCharts.GetChart(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chart;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChart/{chart}")]
        public async Task<bool> UpdateChart(Chart chart)
        {
            bool result = true;
            try
            {
                result = this.blCharts.UpdateChart(chart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChart/{chart}")]
        public async Task<bool> DeleteChart(Chart chart)
        {
            bool result = true;
            try
            {
                result = this.blCharts.DeleteChart(chart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}