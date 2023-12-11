using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class ChartConstantLineController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ChartConstantLineController> _logger;
        private readonly BlChartConstantLine blChartConstantLine = null;

        #endregion

        public ChartConstantLineController(ILogger<ChartConstantLineController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blChartConstantLine = new BlChartConstantLine(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("Get")]
        [Route("api/GetConstantLine/{idConstantLine}")]
        public async Task<BindingList<ChartConstantLine>> GetConstantLine(int idConstantLine)
        {
            BindingList<ChartConstantLine> bindingListChartConstantLine = new BindingList<ChartConstantLine>();
            try
            {
                bindingListChartConstantLine = this.blChartConstantLine.GetConstantLine(idConstantLine);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListChartConstantLine;
        }
    }
}