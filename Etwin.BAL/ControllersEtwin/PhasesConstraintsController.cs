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
    
    public class PhasesConstraintsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<PhasesConstraintsController> _logger;
        private readonly BlPhaseConstraints blPhaseConstraints = null;

        #endregion

        public PhasesConstraintsController(ILogger<PhasesConstraintsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blPhaseConstraints = new BlPhaseConstraints(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetPhaseConstraint/{idPhase}")]
        public async Task<IList<PhasesConstraint>> GetPhaseConstraint(int idPhase)
        {
            IList<PhasesConstraint> lstPhaseConstraint = new List<PhasesConstraint>();
            try
            {
                lstPhaseConstraint = this.blPhaseConstraints.GetPhaseConstraint(idPhase);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPhaseConstraint;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetPhasesConditions/{idPhaseConstraint}")]
        public async Task<IList<ConstraintCondition>> GetPhasesConditions(int idPhaseConstraint)
        {
            IList<ConstraintCondition> lstConditions = new List<ConstraintCondition>();
            try
            {
                lstConditions = this.blPhaseConstraints.GetPhasesConditions(idPhaseConstraint);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstConditions;
        }

        //[HttpGet]
        //[AcceptVerbs("GET")]
        //[Route("api/GetOutputActions/{idPhaseCondition}")]
        //public async Task<PhasesOutputAction> GetOutputActions(int idPhaseCondition)
        //{
        //    PhasesOutputAction actions = new PhasesOutputAction();
        //    try
        //    {
        //        actions = this.blPhaseConstraints.GetOutputActions(idPhaseCondition);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return actions;
        //}
    }
}