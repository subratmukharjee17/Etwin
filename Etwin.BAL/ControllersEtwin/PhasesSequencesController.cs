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
    
    public class PhasesSequencesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<PhasesSequencesController> _logger;
        private readonly BlPhasesSequences blPhasesSequences = null;

        #endregion

        public PhasesSequencesController(ILogger<PhasesSequencesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blPhasesSequences = new BlPhasesSequences(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetPhasesSequence/{idPhasesSequences}")]
        public async Task<BindingList<PhasesSequence>> GetPhasesSequence(int idPhasesSequences)
        {
            BindingList<PhasesSequence> bindingListPhasesSequences = new BindingList<PhasesSequence>();
            try
            {
                bindingListPhasesSequences = this.blPhasesSequences.GetPhasesSequence(idPhasesSequences);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListPhasesSequences;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetPhasesSequenceByPhase/{idPhase}")]
        public async Task<IList<PhasesSequence>> GetPhasesSequenceByPhase(int idPhase)
        {
            IList<PhasesSequence> lstPhasesSequences = new List<PhasesSequence>();
            try
            {
                lstPhasesSequences = this.blPhasesSequences.GetPhasesSequenceByPhase(idPhase);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPhasesSequences;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAllPhasesSequence/")]
        public async Task<IList<PhasesSequence>> GetAllPhasesSequence()
        {
            IList<PhasesSequence> lstPhasesSequences = new List<PhasesSequence>();
            try
            {
                lstPhasesSequences = this.blPhasesSequences.GetAllPhasesSequence();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPhasesSequences;
        }
    }
}