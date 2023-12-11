using Etwin.BAL.BusinnessLogic;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class ToolTipController : ControllerBase
    {
        #region VARS

        private readonly IConfiguration _config;
        private readonly ILogger<ToolTipController> _logger;
        private readonly BlToolTipControl blToolTip;

        #endregion

        public ToolTipController(ILogger<ToolTipController> logger, IConfiguration config)
        {
            this._logger = logger;
            this._config = config;
            this.blToolTip = new BlToolTipControl();
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetToolTipGrids/{idGrid}")]
        public async Task<IList<GridTooltip>> GetToolTipGrids(int idGrid)
        {
            IList<GridTooltip> lstToolTipGrid = new List<GridTooltip>();
            try
            {
                lstToolTipGrid = this.blToolTip.GetToolTipGrids(idGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            
            return lstToolTipGrid;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetToolTipGrids/{idToolTipGrid}")]
        public async Task<GridTooltip> GetToolTipGrid(int idToolTipGrid)
        {
            GridTooltip toolTipGrid = new GridTooltip();
            try
            {
                toolTipGrid = this.blToolTip.GetToolTipGrid(idToolTipGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return toolTipGrid;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetToolTipCharts/{idChart}")]
        public async Task<IList<ChartCrosshair>> GetToolTipCharts(int idChart)
        {
            IList<ChartCrosshair> lstToolTipChart = new List<ChartCrosshair>();
            try
            {
                lstToolTipChart = this.blToolTip.GetToolTipCharts(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstToolTipChart;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetToolTipChart/{idToolTipChart}")]
        public async Task<ChartCrosshair> GetToolTipChart(int idToolTipChart)
        {
            ChartCrosshair toolTipChart = new ChartCrosshair();
            try
            {
                toolTipChart = this.blToolTip.GetToolTipChart(idToolTipChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return toolTipChart;
        }
    }
}