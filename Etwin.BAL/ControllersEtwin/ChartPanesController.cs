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
    
    public class ChartPanesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartPanesController> _logger;
        private readonly BlChartPanes blChartPanes = null;

        #endregion

        public ChartPanesController(ILogger<ChartPanesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartPanes = new BlChartPanes(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddChartPane/{chartPanes}")]
        public async Task<bool> AddChartPanes(ChartPane chartPanes)
        {
            bool result = true;
            try
            {
                result = this.blChartPanes.AddChartPane(chartPanes);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartPane/")]
        public async Task<IList<ChartPane>> GetChartPane()
        {
            IList<ChartPane> lstChartPane = new List<ChartPane>();
            try
            {
                lstChartPane = this.blChartPanes.GetChartPane();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstChartPane;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetChartPane/{idChartPane}")]
        public async Task<ChartPane> GetChartPane(int idChartPane)
        {
            ChartPane chartPane = new ChartPane();
            try
            {
                chartPane = this.blChartPanes.GetChartPane(idChartPane);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chartPane;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateChartPane/{chartPane}")]
        public async Task<bool> UpdateChartPane(ChartPane chartPane)
        {
            bool result = true;
            try
            {
                result = this.blChartPanes.UpdateChartPane(chartPane);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteChartPane/{chartPane}")]
        public async Task<bool> DeleteChartPane(ChartPane chartPane)
        {
            bool result = true;
            try
            {
                result = this.blChartPanes.DeleteChartPane(chartPane);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}