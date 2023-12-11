using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Etwin.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class AssignmentsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<AssignmentsController> _logger;
        private readonly BlAssignments blAssignments = null;

        #endregion

        public AssignmentsController(ILogger<AssignmentsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blAssignments = new BlAssignments(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAssignmentOrder/{operatore}/{ordine}/{fase}")]
        public async Task<int> GetAssignmentOrder(string operatore, string ordine, string fase)
        {
            int index = 0;
            try
            {
                index = this.blAssignments.GetAssignmentOrder(operatore, ordine, fase);

            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return index;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetNewPriority/{operatore}/{newIndex}/{oldIndex}")]
        public async Task<IList<Assignment>> GetNewPriority(string operatore, int newIndex, int oldIndex)
        {
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                lstAssignment = this.blAssignments.GetNewPriority(operatore, newIndex, oldIndex);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstAssignment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetNewPriorityDifferentGroup/{operatore}/{oldIndex}")]
        public async Task<IList<Assignment>> GetNewPriorityDifferentGroup(string operatore, int oldIndex)
        {
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                lstAssignment = this.blAssignments.GetNewPriorityDifferentGroup(operatore, oldIndex);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstAssignment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetNewAssignment/{operatore}/{oldIndex}")]
        public async Task<Assignment> GetNewAssignment(string operatore, string ordine, string fase, int Index)
        {
            Assignment assignment = new Assignment();
            try
            {
                assignment = this.blAssignments.GetNewAssignment(operatore, ordine, fase, Index);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return assignment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetNewPriorityNewColumn/{operatore}/{oldIndex}")]
        public async Task<IList<Assignment>> GetNewPriorityNewColumn(string operatore, int newIndex, int oldIndex)
        {
            IList<Assignment> assignment = new List<Assignment>();
            try
            {
                assignment = this.blAssignments.GetNewPriorityNewColumn(operatore, newIndex, oldIndex);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return assignment;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetCaptionByName/{operatore}/{oldIndex}")]
        public async Task<string> GetCaptionByName(string Name)
        {
            string assignment = "";
            try
            {
                assignment = this.blAssignments.GetCaptionByName(Name);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return assignment;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdatePriorita/")]
        public async Task UpdatePriorita(Assignment a)
        {
            try
            {
                this.blAssignments.UpdatePriorita(a);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}