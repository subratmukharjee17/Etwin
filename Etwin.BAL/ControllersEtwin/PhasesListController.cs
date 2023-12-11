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
    
    public class PhasesListController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<PhasesListController> _logger;
        private readonly BlPhasesList blPhasesList = null;

        #endregion

        public PhasesListController(ILogger<PhasesListController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blPhasesList = new BlPhasesList(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetPhasePerIdProcessList/{idPhasesList}")]
        public async Task<IList<PhasesList>> GetPhasePerIdProcessList(int idPhasesList)
        {
            IList<PhasesList> lstPhasesList = new List<PhasesList>();
            try
            {
                lstPhasesList = this.blPhasesList.GetPhasePerIdProcessList(idPhasesList);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPhasesList;
        }
    }
}