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
    
    public class KPIController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<KPIController> _logger;
        private readonly BlKPI blkpi = null;

        #endregion

        public KPIController(ILogger<KPIController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blkpi = new BlKPI(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetKpiById/{id}")]
        public async Task<Kpi> GetKpiById(int id)
        {
            Kpi kpi = new Kpi();
            try
            {
                kpi = this.blkpi.GetKpiById(id);
                
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return kpi;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetKpiParametersList/{id}")]
        public async Task<IList<KpiParameter>> GetKpiParametersList(int id)
        {
            IList<KpiParameter> kpi = new List<KpiParameter>();
            try
            {
                kpi = this.blkpi.GetKpiParametersList(id);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return kpi;
        }
    }
}