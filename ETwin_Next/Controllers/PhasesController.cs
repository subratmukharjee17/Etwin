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
using ETwin.BAL;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class PhasesController : Controller
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<PhasesController> _logger;
        private readonly BlPhasesCompany blPhasesCompany = null;

        #endregion

        public PhasesController(ILogger<PhasesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blPhasesCompany = new BlPhasesCompany(this._config.GetSection("ConnectionStrings").GetSection("CsCust").Value);
        }

        //[HttpGet]
        //[AcceptVerbs("GET")]
        //[Route("api/GetPhase/{idPhase}")]
        //public async Task<BindingList<Phase>> GetPhase(int idPhase)
        //{
        //    BindingList<Phase> bindingListPhase = new BindingList<Phase>();
        //    try
        //    {
        //        bindingListPhase = this.blPhases.GetPhase(idPhase);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return bindingListPhase;
        //}

        //[HttpGet]
        //[AcceptVerbs("GET")]
        //[Route("api/GetPhasePerAmbito/{idAmbito}")]
        //public async Task<IList<Phase>> GetPhasePerAmbito(int idAmbito)
        //{
        //    IList<Phase> lstPhase = new List<Phase>();
        //    try
        //    {
        //        lstPhase = this.blPhases.GetPhasePerAmbito(idAmbito);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return lstPhase;
        //}


        public int GetIdPhaseFromCode(string Code)
        {
            int idPhase = 0;
            PhasesCompany pc = new PhasesCompany();
            try
            {
                pc = this.blPhasesCompany.GetPhaseFromCode(Code);
                idPhase = pc.Id;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return idPhase;
        }
    }
}